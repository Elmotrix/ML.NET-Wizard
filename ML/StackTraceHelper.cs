using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

public class StackTraceHelper
{
    private readonly Process _process;
    private readonly IntPtr _hProcess;
    private readonly string _symbolSearchPath;
    private bool _symbolsInitialized;

    // Delegates must be kept alive or they'll be garbage collected during stack walk
    private readonly FunctionTableAccessRoutine64Delegate _functionTableAccess;
    private readonly GetModuleBaseRoutine64Delegate _getModuleBase;

    public StackTraceHelper(Process process, IEnumerable<string> pdbFolders)
    {
        _process = process ?? throw new ArgumentNullException(nameof(process));

        if (!HasAccessToTargetProcess(process))
            throw new UnauthorizedAccessException("Insufficient privileges to access the target process.");

        _hProcess = OpenProcess(ProcessAccessFlags.All, false, _process.Id);
        if (_hProcess == IntPtr.Zero)
            throw new InvalidOperationException("Failed to open target process.");

        _symbolSearchPath = BuildSymbolSearchPath(pdbFolders);
        _functionTableAccess = new FunctionTableAccessRoutine64Delegate(SymFunctionTableAccess64);
        _getModuleBase = new GetModuleBaseRoutine64Delegate(SymGetModuleBase64);

        InitializeSymbols();
    }

    public static bool HasAccessToTargetProcess(Process target)
    {
        IntPtr handle = OpenProcess(ProcessAccessFlags.All, false, target.Id);
        if (handle != IntPtr.Zero)
        {
            CloseHandle(handle);
            return true;
        }
        return false;
    }

    private string BuildSymbolSearchPath(IEnumerable<string> folders)
    {
        var paths = new List<string>();

        if (folders != null)
        {
            foreach (var folder in folders)
            {
                if (!string.IsNullOrWhiteSpace(folder))
                    paths.Add(folder.Trim());
            }
        }

        paths.Add("srv*https://msdl.microsoft.com/download/symbols");
        return string.Join(";", paths);
    }

    private void InitializeSymbols()
    {
        if (_symbolsInitialized) return;

        if (!SymInitialize(_hProcess, _symbolSearchPath, true))
            throw new InvalidOperationException("SymInitialize failed");

        _symbolsInitialized = true;
    }

    public string GetStackTrace()
    {
        var sb = new StringBuilder();

        IntPtr funcAccessPtr = Marshal.GetFunctionPointerForDelegate(_functionTableAccess);
        IntPtr moduleBasePtr = Marshal.GetFunctionPointerForDelegate(_getModuleBase);

        foreach (ProcessThread thread in _process.Threads)
        {
            IntPtr hThread = OpenThread(ThreadAccess.SUSPEND_RESUME | ThreadAccess.GET_CONTEXT | ThreadAccess.QUERY_INFORMATION, false, (uint)thread.Id);
            if (hThread == IntPtr.Zero)
                continue;

            SuspendThread(hThread);

            CONTEXT64 context = new CONTEXT64
            {
                ContextFlags = CONTEXT_FLAGS.CONTEXT_FULL
            };

            if (!GetThreadContext(hThread, ref context))
            {
                ResumeThread(hThread);
                CloseHandle(hThread);
                continue;
            }

            STACKFRAME64 stack = new STACKFRAME64
            {
                AddrPC = new ADDRESS64 { Offset = context.Rip, Mode = ADDRESS_MODE.AddrModeFlat },
                AddrFrame = new ADDRESS64 { Offset = context.Rbp, Mode = ADDRESS_MODE.AddrModeFlat },
                AddrStack = new ADDRESS64 { Offset = context.Rsp, Mode = ADDRESS_MODE.AddrModeFlat }
            };

            sb.AppendLine($"Thread {thread.Id:X}:");

            while (StackWalk64(
                IMAGE_FILE_MACHINE_AMD64,
                _hProcess,
                hThread,
                ref stack,
                ref context,
                IntPtr.Zero,
                funcAccessPtr,
                moduleBasePtr,
                IntPtr.Zero))
            {
                ulong addr = stack.AddrPC.Offset;
                if (addr == 0) break;

                byte[] symbolBuffer = new byte[Marshal.SizeOf<SYMBOL_INFO>() + 256];
                GCHandle handle = GCHandle.Alloc(symbolBuffer, GCHandleType.Pinned);
                IntPtr symbolPtr = handle.AddrOfPinnedObject();

                Marshal.WriteInt32(symbolPtr, Marshal.SizeOf<SYMBOL_INFO>()); // SizeOfStruct
                Marshal.WriteInt32(symbolPtr + 4, 255); // MaxNameLen

                if (SymFromAddr(_hProcess, addr, out ulong displacement, symbolPtr))
                {
                    IntPtr namePtr = symbolPtr + Marshal.OffsetOf<SYMBOL_INFO>("Name").ToInt32();
                    string name = Marshal.PtrToStringAnsi(namePtr);
                    sb.AppendLine($"   {name} [0x{addr:X}]");
                }
                else
                {
                    sb.AppendLine($"   0x{addr:X}");
                }

                handle.Free();
            }

            ResumeThread(hThread);
            CloseHandle(hThread);
        }

        return sb.ToString();
    }

    #region Win32 Interop and Structs

    private const int IMAGE_FILE_MACHINE_AMD64 = 0x8664;

    [Flags]
    private enum ProcessAccessFlags : uint
    {
        All = 0x001F0FFF
    }

    [Flags]
    private enum ThreadAccess : uint
    {
        SUSPEND_RESUME = 0x0002,
        GET_CONTEXT = 0x0008,
        QUERY_INFORMATION = 0x0040
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct CONTEXT64
    {
        public CONTEXT_FLAGS ContextFlags;
        public ulong P1Home, P2Home, P3Home, P4Home, P5Home, P6Home;
        public uint MxCsr;
        public ushort SegCs, SegDs, SegEs, SegFs, SegGs, SegSs;
        public uint EFlags;
        public ulong Dr0, Dr1, Dr2, Dr3, Dr6, Dr7;
        public ulong Rax, Rcx, Rdx, Rbx, Rsp, Rbp, Rsi, Rdi;
        public ulong R8, R9, R10, R11, R12, R13, R14, R15;
        public ulong Rip;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] ExtendedRegisters;
    }

    [Flags]
    private enum CONTEXT_FLAGS : uint
    {
        CONTEXT_FULL = 0x00010007
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct STACKFRAME64
    {
        public ADDRESS64 AddrPC;
        public ADDRESS64 AddrReturn;
        public ADDRESS64 AddrFrame;
        public ADDRESS64 AddrStack;
        public ADDRESS64 AddrBStore;
        public IntPtr FuncTableEntry;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public ulong[] Params;
        public bool Far;
        public bool Virtual;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public ulong[] Reserved;
        public KDHELP64 KdHelp;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct ADDRESS64
    {
        public ulong Offset;
        public ushort Segment;
        public ADDRESS_MODE Mode;
    }

    private enum ADDRESS_MODE : uint
    {
        AddrModeFlat = 0
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct KDHELP64
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public ulong[] Reserved;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    private struct SYMBOL_INFO
    {
        public uint SizeOfStruct;
        public uint TypeIndex;
        public ulong Reserved1;
        public ulong Reserved2;
        public uint Index;
        public uint Size;
        public ulong ModBase;
        public uint Flags;
        public ulong Value;
        public ulong Address;
        public uint Register;
        public uint Scope;
        public uint Tag;
        public uint NameLen;
        public uint MaxNameLen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Name;
    }

    // Delegate types
    private delegate IntPtr FunctionTableAccessRoutine64Delegate(IntPtr hProcess, ulong AddrBase);
    private delegate ulong GetModuleBaseRoutine64Delegate(IntPtr hProcess, ulong Address);

    [DllImport("dbghelp.dll", SetLastError = true)]
    private static extern bool SymInitialize(IntPtr hProcess, string UserSearchPath, bool fInvadeProcess);

    [DllImport("dbghelp.dll", SetLastError = true)]
    private static extern bool SymFromAddr(IntPtr hProcess, ulong Address, out ulong Displacement, IntPtr Symbol);

    [DllImport("dbghelp.dll")]
    private static extern IntPtr SymFunctionTableAccess64(IntPtr hProcess, ulong AddrBase);

    [DllImport("dbghelp.dll")]
    private static extern ulong SymGetModuleBase64(IntPtr hProcess, ulong Address);

    [DllImport("dbghelp.dll", SetLastError = true)]
    private static extern bool StackWalk64(
        uint MachineType,
        IntPtr hProcess,
        IntPtr hThread,
        ref STACKFRAME64 StackFrame,
        ref CONTEXT64 ContextRecord,
        IntPtr ReadMemoryRoutine,
        IntPtr FunctionTableAccessRoutine,
        IntPtr GetModuleBaseRoutine,
        IntPtr TranslateAddress
    );

    [DllImport("kernel32.dll")]
    private static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

    [DllImport("kernel32.dll")]
    private static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

    [DllImport("kernel32.dll")]
    private static extern uint SuspendThread(IntPtr hThread);

    [DllImport("kernel32.dll")]
    private static extern int ResumeThread(IntPtr hThread);

    [DllImport("kernel32.dll")]
    private static extern bool GetThreadContext(IntPtr hThread, ref CONTEXT64 context);

    [DllImport("kernel32.dll")]
    private static extern bool CloseHandle(IntPtr hObject);

    #endregion
}
