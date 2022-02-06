using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    class ColumnInfo
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public DataKind ThisDataKind { get; set; }
        public bool IsLabel { get; set; }

        public TextLoader.Column GetTextLoaderColumn()
        {
            return new TextLoader.Column(Name,ThisDataKind,Index);
        }
        public DatabaseLoader.Column GetDatabaseLoaderColumn()
        {
            return new DatabaseLoader.Column(Name, DataKindTranslator(), Index);
        }

        private DbType DataKindTranslator()
        {
            switch (ThisDataKind)
            {
                case DataKind.SByte:
                    return DbType.SByte;
                case DataKind.Byte:
                    return DbType.Byte;
                case DataKind.Int16:
                    return DbType.Int16;
                case DataKind.UInt16:
                    return DbType.UInt16;
                case DataKind.Int32:
                    return DbType.Int32;
                case DataKind.UInt32:
                    return DbType.UInt32;
                case DataKind.Int64:
                    return DbType.Int64;
                case DataKind.UInt64:
                    return DbType.UInt64;
                case DataKind.Single:
                    return DbType.Single;
                case DataKind.Double:
                    return DbType.Double;
                case DataKind.String:
                    return DbType.String;
                case DataKind.Boolean:
                    return DbType.Boolean;
                case DataKind.TimeSpan:
                    return DbType.String;
                case DataKind.DateTime:
                    return DbType.DateTime;
                case DataKind.DateTimeOffset:
                    return DbType.DateTimeOffset;
                default:
                    break;
            }
            return DbType.String;
        }
    }
}
