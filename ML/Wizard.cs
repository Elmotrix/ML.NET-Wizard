using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ML;
using Microsoft.ML.AutoML;
using Microsoft.ML.Data;

namespace ML
{
    public partial class Wizard : Form
    {
        List<Panel> scenePanels = new List<Panel>();
        int CurrentScene;
        bool disableUpdates;
        AutoMLHandler mlHolder = new AutoMLHandler();
        int bestIndex = -1;
        public Wizard()
        {
            InitializeComponent();
            scenePanels.Add(pnlSelectData);
            scenePanels.Add(pnlSelectOutput);
            scenePanels.Add(pnlSelectMLtype);
            scenePanels.Add(pnlConfig);
            scenePanels.Add(pnlWaiting);
            scenePanels.Add(pnlResault);

            SetScene(0);
            lbDataKinds.Items.Add("Single");
            lbDataKinds.Items.Add("String");
            lbDataKinds.Items.Add("Boolean");
            mlHolder.TrainingComplete += btnNext_Click;
            mlHolder.AutoMLLog += MlHolder_AutoMLLog;
        }

        private void MlHolder_AutoMLLog(object sender, LoggingEventArgs e)
        {

        }

        private void SetScene(int Scene)
        {
            foreach (Panel item in scenePanels)
            {
                item.Visible = false;
            }
            scenePanels[Scene].Visible = true;
            scenePanels[Scene].Dock = DockStyle.Fill;
            CurrentScene = Scene;
            btnPrev.Enabled = (Scene != 0);
            if (pnlSelectOutput.Visible)
            {
                LoadDataPreview();
            }
            btnTrainModel.Visible = pnlConfig.Visible;
            btnFinish.Visible = pnlResault.Visible;
            btnSaveModel.Visible = pnlResault.Visible;
            btnPrev.Visible = !pnlResault.Visible;
            btnNext.Visible = !(pnlResault.Visible || pnlConfig.Visible);
            pnlNavigation.Visible = !pnlWaiting.Visible;
            if (pnlResault.Visible)
            {
                ShowResults();
            }
            tmr1sec.Enabled = pnlWaiting.Visible;
            if (pnlWaiting.Visible)
            {
                pbTrainingProgress.Value = 0;
                pbTrainingProgress.Maximum = (int)numTimeout.Value;
            }
        }
        private void ShowResults()
        {
            ShallowExperimentResult[] results = mlHolder.ShallowExperimentResults;
            DataTable dt = new DataTable();
            dt.Columns.Add("Index",typeof(int));
            dt.Columns.Add("Algorithm",typeof(string));
            foreach (ShallowExperimentScore item in results[0].Scores)
            {
                dt.Columns.Add(item.Name, typeof(double));
            }
            for (int i = 0; i < results.Length; i++)
            {
                if (results[i].IsBest)
                {
                    bestIndex = results[i].Index;
                }
                object[] row = new object[dt.Columns.Count];
                row[0] = results[i].Index;
                row[1] = results[i].Algorithm;
                for (int j = 0; j < results[0].Scores.Length; j++)
                {
                    row[j+2] = results[i].Scores[j].Score;
                }
                dt.Rows.Add(row);
            }
            dgvResults.DataSource = dt;

            dgvResults_Sorted(this, new EventArgs());
        }
        private void LoadDataPreview()
        {
            dgvDataPreview.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dgvDataPreview.DataSource = mlHolder.LoadData(tbxFileName.Text, tbxSeparator.Text[0], cbHasHeader.Checked);
            foreach (DataGridViewColumn column in dgvDataPreview.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvDataPreview.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
        }

        private void SetAlgorithms(string[] algorithms)
        {
            cblModels.Items.Clear();
            cblModels.Items.AddRange(algorithms);
            for (int i = 0; i < cblModels.Items.Count; i++)
            {
                cblModels.SetItemChecked(i,true);
            }
        }

        private void btnBinClas_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene + 1);
            SetAlgorithms(mlHolder.SetExperiment<BinaryExperimentSettings>());
        }

        private void btnMultiClas_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene + 1);
            SetAlgorithms(mlHolder.SetExperiment<MulticlassExperimentSettings>());
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene + 1);
            SetAlgorithms(mlHolder.SetExperiment<RegressionExperimentSettings>());
        }

        private void btnRecommendation_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene + 1);
            SetAlgorithms(mlHolder.SetExperiment<RecommendationExperimentSettings>());
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene + 1);
            SetAlgorithms(mlHolder.SetExperiment<RankingExperimentSettings>());
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => SetScene(CurrentScene + 1)));
                return;
            }
            SetScene(CurrentScene + 1);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene - 1);
        }
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblSelectedFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbxFileName.Text = openFileDialog1.FileName;
            }
        }

        private void dgvDataPreview_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDataPreview.SelectedColumns.Count == 0)
            {
                return;
            }
            disableUpdates = true;
            int selectedIndex = dgvDataPreview.SelectedColumns[0].Index;
            ColumnInfo columnInfo = mlHolder.ColumnInfos[selectedIndex];

            cbIsLabel.Checked = columnInfo.IsLabel;
            foreach (string item in lbDataKinds.Items)
            {
                if (columnInfo.ThisDataKind.ToString() == item)
                {
                    lbDataKinds.SelectedItem = item;
                    break;
                }
            }
            disableUpdates = false;
        }

        private void DataSettingChanged(object sender, EventArgs e)
        {
            if (dgvDataPreview.SelectedColumns.Count == 0 || lbDataKinds.SelectedItems.Count == 0 || disableUpdates)
            {
                return;
            }
            int selectedIndex = dgvDataPreview.SelectedColumns[0].Index;
            ColumnInfo columnInfo = mlHolder.ColumnInfos[selectedIndex];
            DataKind dataKind = DataKind.String;
            Enum.TryParse<DataKind>(lbDataKinds.SelectedItem.ToString(), out dataKind);
            columnInfo.ThisDataKind = dataKind;
            columnInfo.IsLabel = cbIsLabel.Checked;
        }

        private void btnTrainModel_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene + 1);
            List<string> excludedAgorithmsList = new List<string>();
            for (int i = 0; i < cblModels.Items.Count; i++)
            {
                if (cblModels.GetItemCheckState(i) == CheckState.Unchecked)
                {
                    excludedAgorithmsList.Add(cblModels.GetItemText(cblModels.Items[i]));
                }
            }
            mlHolder.TrainModel(excludedAgorithmsList.ToArray(), (uint)numTimeout.Value, folderBrowserDialog1.SelectedPath);
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0)
            {
                return;
            }
            DialogResult dialogResult = saveFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                int selectedIndex = Convert.ToInt32(dgvResults.SelectedRows[0].Cells[0].Value);
                foreach (var item in mlHolder.ShallowExperimentResults)
                {
                    if (item.Index == selectedIndex)
                    {
                        mlHolder.SaveModel(item, saveFileDialog1.FileName);
                        return;
                    }
                }
            }
        }

        private void tmr1sec_Tick(object sender, EventArgs e)
        {
            if (pbTrainingProgress.Value < pbTrainingProgress.Maximum)
            {
                pbTrainingProgress.Value += 1;
            }
        }

        private void dgvResults_Sorted(object sender, EventArgs e)
        {
            if (bestIndex >= 0)
            {
                for (int i = 0; i < dgvResults.Rows.Count; i++)
                {
                    if (bestIndex == Convert.ToInt32(dgvResults[0,i].Value))
                    {
                        dgvResults.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                    }
                }
            }
        }
    }
}
