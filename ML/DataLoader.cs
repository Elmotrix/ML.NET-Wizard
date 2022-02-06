using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    interface iDataLoader
    {
        public List<ColumnInfo> ColumnInfos { get; }
        public IDataView LoadData(MLContext mlContext);
        public DataTable LoadDataSchema();
    }
    class BaseDataLoader
    {
        protected List<ColumnInfo> columnInfos = new List<ColumnInfo>();
        public List<ColumnInfo> ColumnInfos { get { return columnInfos; } }

        protected void ParseColumnInfo(DataTable dt)
        {
            columnInfos = new List<ColumnInfo>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataKind dataKind = DataKind.String;
                bool tryBoolValue = false;
                float tryFloatValue = 0;
                if (bool.TryParse(dt.Rows[0].ItemArray[i].ToString(), out tryBoolValue))
                {
                    dataKind = DataKind.Boolean;
                }
                else if (Single.TryParse(dt.Rows[0].ItemArray[i].ToString(), out tryFloatValue))
                {
                    dataKind = DataKind.Single;
                }
                else if (Single.TryParse(dt.Rows[0].ItemArray[i].ToString().Replace('.', ','), out tryFloatValue))
                {
                    dataKind = DataKind.Single;
                }
                columnInfos.Add(new ColumnInfo()
                {
                    Index = i,
                    Name = dt.Columns[i].ColumnName,
                    ThisDataKind = dataKind
                });
            }
        }
    }
    class FileDataLoader: BaseDataLoader,iDataLoader
    {
        public FileDataLoader(string filePath, char separator = ',', bool hasHeader = true)
        {
            FilePath = filePath;
            Separator = separator;
            HasHeader = hasHeader;
        }
        string FilePath;
        char Separator;
        bool HasHeader;
        public DataTable LoadDataSchema()
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(FilePath))
            {
                string[] headers = null;
                if (HasHeader)
                {
                    headers = sr.ReadLine().Split(Separator);
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                }
                int j = 0;
                while (!sr.EndOfStream && j < 20)
                {
                    j++;
                    string[] rows = sr.ReadLine().Split(Separator);
                    if (headers == null)
                    {
                        headers = new string[rows.Length];
                        for (int i = 0; i < rows.Length; i++)
                        {
                            headers[i] = "#" + i;
                            dt.Columns.Add(headers[i]);
                        }
                    }
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < rows.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            ParseColumnInfo(dt);

            return dt;
        }
        public IDataView LoadData(MLContext mlContext)
        {
            TextLoader.Column[] columns = new TextLoader.Column[columnInfos.Count];
            for (int i = 0; i < columnInfos.Count; i++)
            {
                columns[i] = columnInfos[i].GetTextLoaderColumn();
            }

            TextLoader textLoader = mlContext.Data.CreateTextLoader(columns, hasHeader: HasHeader, separatorChar: Separator);
            return textLoader.Load(FilePath);
        }
    }

    class DbDataLoader: BaseDataLoader, iDataLoader
    {
        public DbDataLoader(string connectionString, string commandText)
        {
            ConnectionString = connectionString;
            CommandText = commandText;
        }
        string ConnectionString;
        string CommandText;

        public DataTable LoadDataSchema()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(CommandText.ToUpper().Replace("SELECT ", "SELECT TOP 20 "), conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            conn.Close();
            da.Dispose();
            ParseColumnInfo(dt);
            return dt;
        }
        public IDataView LoadData(MLContext mlContext)
        {
            DatabaseSource source = new DatabaseSource(SqlClientFactory.Instance, ConnectionString, CommandText);

            DatabaseLoader.Column[] columns = new DatabaseLoader.Column[columnInfos.Count];
            for (int i = 0; i < columnInfos.Count; i++)
            {
                columns[i] = columnInfos[i].GetDatabaseLoaderColumn();
            }

            DatabaseLoader dbLoader = mlContext.Data.CreateDatabaseLoader(columns);
            return dbLoader.Load(source);
        }
    }
}
