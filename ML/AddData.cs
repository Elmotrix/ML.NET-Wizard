using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ML
{
    public partial class AddData : Form
    {
        List<Panel> scenePanels = new List<Panel>();
        List<DataSource> dataSourceList = new List<DataSource>();
        public Wizard Parent { get; set; }
        public AddData(Wizard Parent)
        {
            this.Parent = Parent;
            InitializeComponent();
            scenePanels.Add(pnlSelectSource);
            scenePanels.Add(pnlManageFiles);

            SetScene(pnlSelectSource);
        }
        private void SetScene(Panel Scene)
        {
            foreach (Panel item in scenePanels)
            {
                item.Visible = false;
            }
            Scene.Visible = true;
            Scene.Dock = DockStyle.Fill;
        }
        private void AddData_Load(object sender, EventArgs e)
        {

        }

        private void btnFromFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pnlMultiFile.Visible = openFileDialog1.FileNames.Length > 1;
                foreach (string item in openFileDialog1.FileNames)
                {
                    dataSourceList.Add(new DataSource() { SourcePath = item, Delimitor = txtDelimiter.Text});
                }
                dgvFiles.DataSource = dataSourceList;
                SetScene(pnlManageFiles);
            }
        }

        private void btnLoadFiles_Click(object sender, EventArgs e)
        {
            foreach (DataSource item in dataSourceList)
            {
                DataTable dt = new DataTable();
                using (StreamReader sr = new StreamReader(item.SourcePath))
                {
                    string[] headers = null;
                    if (item.HasHeader)
                    {
                        headers = sr.ReadLine().Split(',');
                        foreach (string header in headers)
                        {
                            dt.Columns.Add(header);
                        }
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        if (headers == null)
                        {
                            headers = new string[rows.Length];
                            for (int i = 0; i < rows.Length; i++)
                            {
                                headers[i] = "#" + i + " " + item.SourcePath;
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
                item.Data = dt;
            }
            //Parent.AddDataSource(dataSourceList);
            if (cbCronological.Checked)
            {
// Parent.mlContext.Data.l
            }
            else if (cbPararell.Checked)
            {

            }

        }
    }
}
