using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class DataSource
    {
        public int Attributes { get { return Data.Columns.Count; } }
        public string SourcePath { get; set; }
        public string Delimitor { get; set; }
        public bool HasHeader { get; set; }
        public bool HasRowIndex { get; set; }
        public DataTable Data { get; set; }
    }
}
