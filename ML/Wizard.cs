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
        int PredictPanelStartIndex;
        public Wizard()
        {
            InitializeComponent();
            //scenePanels.Add(pnlWelcome);
            pnlWelcome.Visible = false;
            scenePanels.Add(pnlSelectData);
            scenePanels.Add(pnlSelectOutput);
            scenePanels.Add(pnlSelectMLtype);
            scenePanels.Add(pnlConfig);
            scenePanels.Add(pnlWaiting);
            scenePanels.Add(pnlResault);
            PredictPanelStartIndex = scenePanels.Count;
            scenePanels.Add(pnlSelectData);
            scenePanels.Add(pnlResault);

            foreach (Panel item in scenePanels)
            {
                item.Visible = false;
                item.Dock = DockStyle.Fill;
            }

            SetScene(0);
            lbDataKinds.Items.Add("Single");
            lbDataKinds.Items.Add("String");
            lbDataKinds.Items.Add("Boolean");
            mlHolder.TrainingComplete += btnNext_Click;
            mlHolder.AutoMLLog += MlHolder_AutoMLLog;
            pnlMultiFile.Visible = false;
        }

        private void MlHolder_AutoMLLog(object sender, LoggingEventArgs e)
        {

        }

        private void SetScene(int Scene)
        {
            scenePanels[CurrentScene].Visible = false;
            scenePanels[Scene].Visible = true;
            CurrentScene = Scene;
            btnPrev.Enabled = !(Scene == 0 || Scene == PredictPanelStartIndex);
            btnTrainModel.Visible = scenePanels[Scene] == pnlConfig;
            btnFinish.Visible = scenePanels[Scene] == pnlResault;
            btnSaveModel.Visible = scenePanels[Scene] == pnlResault;
            btnExportResults.Visible = scenePanels[Scene] == pnlResault;
            btnPrev.Visible = !(scenePanels[Scene] == pnlResault);
            btnNext.Visible = !(scenePanels[Scene] == pnlResault || scenePanels[Scene] == pnlConfig);
            btnUseModel.Visible = false; // scenePanels[Scene] == pnlResault;
            btnUseModel.BringToFront();
            pnlNavigation.Visible = !(scenePanels[Scene] == pnlWaiting || scenePanels[Scene] == pnlWelcome);
            tmr1sec.Enabled = scenePanels[Scene] == pnlWaiting;
            if (scenePanels[Scene] == pnlWaiting)
            {
                pbTrainingProgress.Value = 0;
                pbTrainingProgress.Maximum = (int)numTimeout.Value+5;
            }

            if (Scene >= PredictPanelStartIndex)
            {
                if (scenePanels[Scene] == pnlResault)
                {
                    LoadDataPreview();
                }
            }
            else
            {
                if (scenePanels[Scene] == pnlSelectOutput)
                {
                    LoadDataPreview();
                }
                if (scenePanels[Scene] == pnlResault)
                {
                    ShowResults();
                }
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
                    if (j < results[i].Scores.Length)
                    {
                        row[j+2] = results[i].Scores[j].Score;
                    }
                }
                dt.Rows.Add(row);
            }
            dgvResults.DataSource = dt;

            dgvResults_Sorted(this, new EventArgs());
        }
        private void LoadDataPreview()
        {
            string[] Files = new string[lbFiles.Items.Count];
            for (int i = 0; i < lbFiles.Items.Count; i++)
            {
                Files[i] = lbFiles.Items[i].ToString();
            }
            if (Files.Length == 0)
            {
                Files = new string[] { tbxFileName.Text };
            }
            dgvDataPreview.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            if (tabcrDataSources.SelectedTab == tabDataFromFile)
            {
                dgvDataPreview.DataSource = mlHolder.LoadDataSchemaFromFile(Files, tbxSeparator.Text[0], cbHasHeader.Checked);
            }
            else if (tabcrDataSources.SelectedTab == tabDataFromFile)
            {
                dgvDataPreview.DataSource = mlHolder.LoadDataSchemaFromDb(txtConnString.Text, txtQuerry.Text);
            }
            else
            {
                dgvDataPreview.DataSource = null;
            }
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
            SetAlgorithms(mlHolder.SetExperimentType(ModelType.Binary));
        }

        private void btnMultiClas_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene + 1);
            SetAlgorithms(mlHolder.SetExperimentType(ModelType.Multiclass));
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene + 1);
            SetAlgorithms(mlHolder.SetExperimentType(ModelType.Regression));
        }

        private void btnRecommendation_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene + 1);
            SetAlgorithms(mlHolder.SetExperimentType(ModelType.Recommendation));
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene + 1);
            SetAlgorithms(mlHolder.SetExperimentType(ModelType.Ranking));
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
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                lbFiles.Items.Clear();
                lbFiles.Items.AddRange(openFileDialog1.FileNames);
                if (openFileDialog1.FileNames.Length == 1)
                {
                    tbxFileName.Text = openFileDialog1.FileName;
                }
                else if (openFileDialog1.FileNames.Length > 1)
                {
                    tbxFileName.Text = openFileDialog1.FileNames.ToString();
                    pnlMultiFile.Visible = true;
                }
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
            ColumnInfo columnInfo = mlHolder.DataLoader.ColumnInfos[selectedIndex];

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
            ColumnInfo columnInfo = mlHolder.DataLoader.ColumnInfos[selectedIndex];
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
            if (dgvResults.SelectedRows.Count == 1)
            {
                saveFileDialog1.FileName = "onnx_model";
                saveFileDialog1.DefaultExt = "onnx";
                DialogResult dialogResult = saveFileDialog1.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    int selectedIndex = Convert.ToInt32(dgvResults.SelectedRows[0].Cells[0].Value);
                    SaveOnnxModel(selectedIndex, saveFileDialog1.FileName);
                }
            }
            else
            {
                DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    for (int i = 0; i < dgvResults.SelectedRows.Count; i++)
                    {
                        int selectedIndex = Convert.ToInt32(dgvResults.SelectedRows[i].Cells[0].Value);
                        string fileName = folderBrowserDialog1.SelectedPath + "\\Model_" + selectedIndex + "_" + dgvResults.SelectedRows[i].Cells[1].Value + ".onnx";
                        SaveOnnxModel(selectedIndex, fileName);
                    }
                }
            }
        }
        private void SaveOnnxModel(int index, string filePath)
        {
            foreach (var item in mlHolder.ShallowExperimentResults)
            {
                if (item.Index == index)
                {
                    mlHolder.SaveModel(item, filePath);
                    return;
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

        private void btnExportResults_Click(object sender, EventArgs e)
        {
            char sep = ',';
            char des = '.';
            saveFileDialog1.FileName = "AutoMLResaultsReport";
            saveFileDialog1.DefaultExt = "csv";
            DialogResult dialogResult = saveFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                using StreamWriter file = new(saveFileDialog1.FileName, append: false);
                for (int i = -1; i < dgvResults.Rows.Count; i++)
                {
                    string thisLine = "";
                    for (int j = 0; j < dgvResults.Columns.Count; j++)
                    {
                        if (i >= 0)
                        {
                            thisLine += dgvResults[j, i].Value.ToString().Replace(',', des) + sep;
                        }
                        else
                        {
                            thisLine += dgvResults.Columns[j].HeaderText + sep;
                        }
                    }
                    file.WriteLine(thisLine.TrimEnd(sep));
                }
            }
        }

        private void btnMultiFileUp_Click(object sender, EventArgs e)
        {
            OrderChange(-1);
        }

        private void btnMultiFileDown_Click(object sender, EventArgs e)
        {
            OrderChange(1);
        }

        private void OrderChange(int Shift)
        {
            int[] selection = new int[lbFiles.SelectedItems.Count];
            if (selection.Length == 0)
            {
                return;
            }
            for (int i = 0; i < selection.Length; i++)
            {
                selection[i] = lbFiles.Items.IndexOf(lbFiles.SelectedItems[i]);
            }
            string[] newArray = new string[lbFiles.Items.Count];
            foreach (int item in selection)
            {
                if (item + Shift >= 0 && item + Shift < lbFiles.Items.Count)
                {
                    newArray[item+Shift] = lbFiles.Items[item].ToString();
                }
                else
                {
                    return;
                }
            }
            int jStart = 0;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i] == null)
                {
                    for (int j = jStart; j < lbFiles.Items.Count; j++)
                    {
                        if (!selection.Contains(j))
                        {
                            jStart = j+1;
                            newArray[i] = lbFiles.Items[j].ToString();
                            break;
                        }
                    }
                }
            }
            lbFiles.Items.Clear();
            lbFiles.Items.AddRange(newArray);
            foreach (int item in selection)
            {
                lbFiles.SetSelected(item + Shift, true);
            }
        }

        private void btnAscending_Click(object sender, EventArgs e)
        {
            lbFiles.Sorted = true;
            lbFiles.Sorted = false;
        }

        private void btnDecending_Click(object sender, EventArgs e)
        {
            lbFiles.Sorted = true;
            lbFiles.Sorted = false;
            for (int i = 0; i < lbFiles.Items.Count; i++)
            {
                lbFiles.Items[i] = lbFiles.Items.Count - i + lbFiles.Items[i].ToString();
            }
            lbFiles.Sorted = true;
            lbFiles.Sorted = false;
            for (int i = 0; i < lbFiles.Items.Count; i++)
            {
                lbFiles.Items[i] = lbFiles.Items[i].ToString().Substring((lbFiles.Items.Count - i).ToString().Length);
            }
        }

        private void pnlWelcome_SizeChanged(object sender, EventArgs e)
        {
            pnlWelcome.Padding = new Padding(0, pnlWelcome.Height / 2 - btnStartModelTrainer.Height, 0, 0);
        }

        private void btnStartModelTrainer_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene + 1);
        }

        private void btnStartPredicter_Click(object sender, EventArgs e)
        {

            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Model|*.onnx;*.zip";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    mlHolder.LoadModel(openFileDialog1.FileName);
                }
                catch (Exception Error)
                {
                    MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            SetScene(PredictPanelStartIndex);
        }
    }
}
