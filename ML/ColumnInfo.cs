using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ML.Data.TextLoader;

namespace ML
{
    class ColumnInfo
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public DataKind ThisDataKind { get; set; }
        public bool IsLabel { get; set; }

        public Column GetColumn()
        {
            return new Column(Name,ThisDataKind,Index);
        }
    }
}
