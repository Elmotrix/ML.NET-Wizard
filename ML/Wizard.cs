using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        ExperimentSettings experimentSettings;
        public MLContext mlContext = new MLContext();
        List<Panel> scenePanels = new List<Panel>();
        int CurrentScene;
        string[] algorithms;
        public Wizard()
        {
            InitializeComponent();
            scenePanels.Add(pnlSelectData);
            scenePanels.Add(pnlSelectMLtype);
            scenePanels.Add(pnlConfig);

            SetScene(0);
        }

        private void SetScene(int Scene)
        {
            pnlResault.Visible = false;
            foreach (Panel item in scenePanels)
            {
                item.Visible = false;
            }
            scenePanels[Scene].Visible = true;
            scenePanels[Scene].Dock = DockStyle.Fill;
            CurrentScene = Scene;
            btnPrev.Enabled = (Scene != 0);
            btnNext.Visible = (Scene < scenePanels.Count-1);
            btnFinish.Visible = !(btnNext.Visible);
        }
        private void SetAlgorithms()
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
            experimentSettings = new BinaryExperimentSettings();
            SetScene(CurrentScene + 1);
            algorithms = System.Enum.GetNames(typeof(BinaryClassificationTrainer));
            SetAlgorithms();
        }

        private void btnMultiClas_Click(object sender, EventArgs e)
        {
            experimentSettings = new MulticlassExperimentSettings();
            SetScene(CurrentScene + 1);
            algorithms = System.Enum.GetNames(typeof(MulticlassClassificationTrainer));
            SetAlgorithms();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            experimentSettings = new RegressionExperimentSettings();
            SetScene(CurrentScene + 1);
            algorithms = System.Enum.GetNames(typeof(RegressionTrainer));
            SetAlgorithms();
        }

        private void btnRecommendation_Click(object sender, EventArgs e)
        {
            experimentSettings = new RecommendationExperimentSettings();
            SetScene(CurrentScene + 1);
            algorithms = System.Enum.GetNames(typeof(RecommendationTrainer));
            SetAlgorithms();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            experimentSettings = new RankingExperimentSettings();
            SetScene(CurrentScene + 1);
            algorithms = System.Enum.GetNames(typeof(RankingTrainer));
            SetAlgorithms();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene + 1);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SetScene(CurrentScene - 1);
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            AddData addData = new AddData(this);
            addData.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            foreach (Panel item in scenePanels)
            {
                item.Visible = false;
            }
            rtbResault.Text = "";
            pnlResault.Visible = true;
            pnlResault.Dock = DockStyle.Fill;
            Microsoft.ML.Data.TextLoader.Options options = new Microsoft.ML.Data.TextLoader.Options();
            options.DecimalMarker = tbxDecimalMarker.Text[0];
            options.HasHeader = cbHasHeader.Checked;
            options.Separators = new char[] { tbxSeparator.Text[0] };
            IDataView dataView = mlContext.Data.LoadFromTextFile(tbxFileName.Text,options:options);

            rtbResault.Text += dataView.Schema;
            rtbResault.Text += "\r\n";
            rtbResault.Text += dataView.Preview();
            rtbResault.Text += "\r\n";
            DataDebuggerPreview debuggerPreview = dataView.Preview();
            Type trainerType = experimentSettings.GetType();
            experimentSettings.MaxExperimentTimeInSeconds = (uint)numTimeout.Value;
            if (lblSelectedFolder.Text != "[no folder selected]")
            {
                experimentSettings.CacheDirectoryName = lblSelectedFolder.Text;
            }
            if (trainerType == typeof(BinaryExperimentSettings))
            {
            }
            if (trainerType == typeof(MulticlassExperimentSettings))
            {

            }
            if (trainerType == typeof(RegressionExperimentSettings))
            {
                RegressionExperimentSettings experimentSetting = (RegressionExperimentSettings)experimentSettings;
                for (int i = 0; i < cblModels.Items.Count; i++)
                {
                    if (cblModels.GetItemCheckState(i) == CheckState.Unchecked)
                    {
                        experimentSetting.Trainers.Remove((RegressionTrainer)Enum.Parse(typeof(RegressionTrainer), cblModels.GetItemText(cblModels.Items[i])));
                    }
                }
                var labelColumnInfo = new ColumnInformation()
                {
                    LabelColumnName = "fare_amount"
                };
                RegressionExperiment experiment = mlContext.Auto().CreateRegressionExperiment(experimentSetting);
                ExperimentResult<RegressionMetrics> experimentResult = experiment.Execute(dataView, labelColumnInfo);
                foreach (var item in experimentResult.RunDetails.ToArray())
                {
                    rtbResault.Text += item.TrainerName;
                    rtbResault.Text += "\r\n";
                    rtbResault.Text += item.ValidationMetrics;
                    rtbResault.Text += "\r\n";
                }
            }
            if (trainerType == typeof(RecommendationExperimentSettings))
            {

            }
            if (trainerType == typeof(RankingExperimentSettings))
            {

            }
        }


        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbxFileName.Text = openFileDialog1.FileName;
            }
        }
    }
}
