
namespace ML
{
    partial class Wizard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wizard));
            this.pnlSelectMLtype = new System.Windows.Forms.Panel();
            this.btnRanking = new System.Windows.Forms.Button();
            this.btnRecommendation = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnMultiClas = new System.Windows.Forms.Button();
            this.btnBinClas = new System.Windows.Forms.Button();
            this.lblHeaderSelectModel = new System.Windows.Forms.Label();
            this.pnlSelectData = new System.Windows.Forms.Panel();
            this.tabcrDataSources = new System.Windows.Forms.TabControl();
            this.tabDataFromFile = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbxSeparator = new System.Windows.Forms.TextBox();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.cbHasHeader = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbxFileName = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.tabDataFromSQL = new System.Windows.Forms.TabPage();
            this.pnlQuerryHolder = new System.Windows.Forms.Panel();
            this.txtQuerry = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlConStringHolder = new System.Windows.Forms.Panel();
            this.txtConnString = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.btnExportResults = new System.Windows.Forms.Button();
            this.btnSaveModel = new System.Windows.Forms.Button();
            this.btnTrainModel = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlSelectOutput = new System.Windows.Forms.Panel();
            this.dgvDataPreview = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbDataKinds = new System.Windows.Forms.ListBox();
            this.cbIsLabel = new System.Windows.Forms.CheckBox();
            this.lblHeaderSelectOutput = new System.Windows.Forms.Label();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cblModels = new System.Windows.Forms.CheckedListBox();
            this.pnlSaveFolder = new System.Windows.Forms.Panel();
            this.lblSelectedFolder = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.pnlTimeout = new System.Windows.Forms.Panel();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblHeaderConfig = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlResault = new System.Windows.Forms.Panel();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.lblResault = new System.Windows.Forms.Label();
            this.pnlWaiting = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbTrainingProgress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tmr1sec = new System.Windows.Forms.Timer(this.components);
            this.pnlSelectMLtype.SuspendLayout();
            this.pnlSelectData.SuspendLayout();
            this.tabcrDataSources.SuspendLayout();
            this.tabDataFromFile.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabDataFromSQL.SuspendLayout();
            this.pnlQuerryHolder.SuspendLayout();
            this.pnlConStringHolder.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.pnlSelectOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPreview)).BeginInit();
            this.panel5.SuspendLayout();
            this.pnlConfig.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlSaveFolder.SuspendLayout();
            this.pnlTimeout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            this.pnlResault.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.pnlWaiting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSelectMLtype
            // 
            this.pnlSelectMLtype.Controls.Add(this.btnRanking);
            this.pnlSelectMLtype.Controls.Add(this.btnRecommendation);
            this.pnlSelectMLtype.Controls.Add(this.btnReg);
            this.pnlSelectMLtype.Controls.Add(this.btnMultiClas);
            this.pnlSelectMLtype.Controls.Add(this.btnBinClas);
            this.pnlSelectMLtype.Controls.Add(this.lblHeaderSelectModel);
            this.pnlSelectMLtype.Location = new System.Drawing.Point(0, 0);
            this.pnlSelectMLtype.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSelectMLtype.Name = "pnlSelectMLtype";
            this.pnlSelectMLtype.Size = new System.Drawing.Size(172, 104);
            this.pnlSelectMLtype.TabIndex = 1;
            // 
            // btnRanking
            // 
            this.btnRanking.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRanking.Location = new System.Drawing.Point(0, 199);
            this.btnRanking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRanking.Name = "btnRanking";
            this.btnRanking.Size = new System.Drawing.Size(172, 46);
            this.btnRanking.TabIndex = 4;
            this.btnRanking.Text = "Ranking";
            this.btnRanking.UseVisualStyleBackColor = true;
            this.btnRanking.Click += new System.EventHandler(this.btnRanking_Click);
            // 
            // btnRecommendation
            // 
            this.btnRecommendation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRecommendation.Location = new System.Drawing.Point(0, 153);
            this.btnRecommendation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRecommendation.Name = "btnRecommendation";
            this.btnRecommendation.Size = new System.Drawing.Size(172, 46);
            this.btnRecommendation.TabIndex = 3;
            this.btnRecommendation.Text = "Recommendation";
            this.btnRecommendation.UseVisualStyleBackColor = true;
            this.btnRecommendation.Click += new System.EventHandler(this.btnRecommendation_Click);
            // 
            // btnReg
            // 
            this.btnReg.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReg.Location = new System.Drawing.Point(0, 107);
            this.btnReg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(172, 46);
            this.btnReg.TabIndex = 2;
            this.btnReg.Text = "Regression";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnMultiClas
            // 
            this.btnMultiClas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMultiClas.Location = new System.Drawing.Point(0, 61);
            this.btnMultiClas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMultiClas.Name = "btnMultiClas";
            this.btnMultiClas.Size = new System.Drawing.Size(172, 46);
            this.btnMultiClas.TabIndex = 1;
            this.btnMultiClas.Text = "Multiclass Classification";
            this.btnMultiClas.UseVisualStyleBackColor = true;
            this.btnMultiClas.Click += new System.EventHandler(this.btnMultiClas_Click);
            // 
            // btnBinClas
            // 
            this.btnBinClas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBinClas.Location = new System.Drawing.Point(0, 15);
            this.btnBinClas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBinClas.Name = "btnBinClas";
            this.btnBinClas.Size = new System.Drawing.Size(172, 46);
            this.btnBinClas.TabIndex = 0;
            this.btnBinClas.Text = "Binary Classification";
            this.btnBinClas.UseVisualStyleBackColor = true;
            this.btnBinClas.Click += new System.EventHandler(this.btnBinClas_Click);
            // 
            // lblHeaderSelectModel
            // 
            this.lblHeaderSelectModel.AutoSize = true;
            this.lblHeaderSelectModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderSelectModel.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderSelectModel.Name = "lblHeaderSelectModel";
            this.lblHeaderSelectModel.Size = new System.Drawing.Size(78, 15);
            this.lblHeaderSelectModel.TabIndex = 5;
            this.lblHeaderSelectModel.Text = "Select Model:";
            // 
            // pnlSelectData
            // 
            this.pnlSelectData.Controls.Add(this.tabcrDataSources);
            this.pnlSelectData.Location = new System.Drawing.Point(32, 153);
            this.pnlSelectData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSelectData.Name = "pnlSelectData";
            this.pnlSelectData.Size = new System.Drawing.Size(770, 337);
            this.pnlSelectData.TabIndex = 2;
            // 
            // tabcrDataSources
            // 
            this.tabcrDataSources.Controls.Add(this.tabDataFromFile);
            this.tabcrDataSources.Controls.Add(this.tabDataFromSQL);
            this.tabcrDataSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcrDataSources.Location = new System.Drawing.Point(0, 0);
            this.tabcrDataSources.Name = "tabcrDataSources";
            this.tabcrDataSources.SelectedIndex = 0;
            this.tabcrDataSources.Size = new System.Drawing.Size(770, 337);
            this.tabcrDataSources.TabIndex = 9;
            // 
            // tabDataFromFile
            // 
            this.tabDataFromFile.Controls.Add(this.panel4);
            this.tabDataFromFile.Controls.Add(this.panel3);
            this.tabDataFromFile.Location = new System.Drawing.Point(4, 24);
            this.tabDataFromFile.Name = "tabDataFromFile";
            this.tabDataFromFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataFromFile.Size = new System.Drawing.Size(762, 309);
            this.tabDataFromFile.TabIndex = 0;
            this.tabDataFromFile.Text = "Data from file";
            this.tabDataFromFile.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbxSeparator);
            this.panel4.Controls.Add(this.lblSeparator);
            this.panel4.Controls.Add(this.cbHasHeader);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 26);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(756, 23);
            this.panel4.TabIndex = 8;
            // 
            // tbxSeparator
            // 
            this.tbxSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbxSeparator.Location = new System.Drawing.Point(203, 0);
            this.tbxSeparator.Name = "tbxSeparator";
            this.tbxSeparator.Size = new System.Drawing.Size(23, 23);
            this.tbxSeparator.TabIndex = 1;
            this.tbxSeparator.Text = ",";
            // 
            // lblSeparator
            // 
            this.lblSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSeparator.Location = new System.Drawing.Point(87, 0);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(116, 23);
            this.lblSeparator.TabIndex = 3;
            this.lblSeparator.Text = "Separator:";
            this.lblSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbHasHeader
            // 
            this.cbHasHeader.Checked = true;
            this.cbHasHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHasHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbHasHeader.Location = new System.Drawing.Point(0, 0);
            this.cbHasHeader.Name = "cbHasHeader";
            this.cbHasHeader.Size = new System.Drawing.Size(87, 23);
            this.cbHasHeader.TabIndex = 0;
            this.cbHasHeader.Text = "Has Header";
            this.cbHasHeader.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbxFileName);
            this.panel3.Controls.Add(this.btnSelectFile);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(756, 23);
            this.panel3.TabIndex = 7;
            // 
            // tbxFileName
            // 
            this.tbxFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxFileName.Location = new System.Drawing.Point(75, 0);
            this.tbxFileName.Name = "tbxFileName";
            this.tbxFileName.Size = new System.Drawing.Size(681, 23);
            this.tbxFileName.TabIndex = 1;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelectFile.Location = new System.Drawing.Point(0, 0);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // tabDataFromSQL
            // 
            this.tabDataFromSQL.Controls.Add(this.pnlQuerryHolder);
            this.tabDataFromSQL.Controls.Add(this.pnlConStringHolder);
            this.tabDataFromSQL.Location = new System.Drawing.Point(4, 24);
            this.tabDataFromSQL.Name = "tabDataFromSQL";
            this.tabDataFromSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataFromSQL.Size = new System.Drawing.Size(762, 309);
            this.tabDataFromSQL.TabIndex = 1;
            this.tabDataFromSQL.Text = "Data from database";
            this.tabDataFromSQL.UseVisualStyleBackColor = true;
            // 
            // pnlQuerryHolder
            // 
            this.pnlQuerryHolder.Controls.Add(this.txtQuerry);
            this.pnlQuerryHolder.Controls.Add(this.label2);
            this.pnlQuerryHolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuerryHolder.Location = new System.Drawing.Point(3, 68);
            this.pnlQuerryHolder.Name = "pnlQuerryHolder";
            this.pnlQuerryHolder.Size = new System.Drawing.Size(756, 100);
            this.pnlQuerryHolder.TabIndex = 1;
            // 
            // txtQuerry
            // 
            this.txtQuerry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuerry.Location = new System.Drawing.Point(106, 0);
            this.txtQuerry.Multiline = true;
            this.txtQuerry.Name = "txtQuerry";
            this.txtQuerry.Size = new System.Drawing.Size(650, 100);
            this.txtQuerry.TabIndex = 1;
            this.txtQuerry.Text = "SELECT * FROM table";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 100);
            this.label2.TabIndex = 0;
            this.label2.Text = "Querry:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlConStringHolder
            // 
            this.pnlConStringHolder.Controls.Add(this.txtConnString);
            this.pnlConStringHolder.Controls.Add(this.label3);
            this.pnlConStringHolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConStringHolder.Location = new System.Drawing.Point(3, 3);
            this.pnlConStringHolder.Name = "pnlConStringHolder";
            this.pnlConStringHolder.Size = new System.Drawing.Size(756, 65);
            this.pnlConStringHolder.TabIndex = 0;
            // 
            // txtConnString
            // 
            this.txtConnString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnString.Location = new System.Drawing.Point(106, 0);
            this.txtConnString.Multiline = true;
            this.txtConnString.Name = "txtConnString";
            this.txtConnString.Size = new System.Drawing.Size(650, 65);
            this.txtConnString.TabIndex = 1;
            this.txtConnString.Text = "Data Source=ServerName;\r\nInitial Catalog=DataBaseName;\r\nIntegrated Security=SSPI;" +
    "";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 65);
            this.label3.TabIndex = 0;
            this.label3.Text = "Connection String:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.Controls.Add(this.btnExportResults);
            this.pnlNavigation.Controls.Add(this.btnSaveModel);
            this.pnlNavigation.Controls.Add(this.btnTrainModel);
            this.pnlNavigation.Controls.Add(this.btnFinish);
            this.pnlNavigation.Controls.Add(this.btnPrev);
            this.pnlNavigation.Controls.Add(this.btnNext);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 516);
            this.pnlNavigation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(1118, 34);
            this.pnlNavigation.TabIndex = 3;
            // 
            // btnExportResults
            // 
            this.btnExportResults.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExportResults.Location = new System.Drawing.Point(316, 0);
            this.btnExportResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportResults.Name = "btnExportResults";
            this.btnExportResults.Size = new System.Drawing.Size(158, 34);
            this.btnExportResults.TabIndex = 5;
            this.btnExportResults.Text = "Export to csv";
            this.btnExportResults.UseVisualStyleBackColor = true;
            this.btnExportResults.Visible = false;
            this.btnExportResults.Click += new System.EventHandler(this.btnExportResults_Click);
            // 
            // btnSaveModel
            // 
            this.btnSaveModel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaveModel.Location = new System.Drawing.Point(158, 0);
            this.btnSaveModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveModel.Name = "btnSaveModel";
            this.btnSaveModel.Size = new System.Drawing.Size(158, 34);
            this.btnSaveModel.TabIndex = 4;
            this.btnSaveModel.Text = "Save Selected Model";
            this.btnSaveModel.UseVisualStyleBackColor = true;
            this.btnSaveModel.Visible = false;
            this.btnSaveModel.Click += new System.EventHandler(this.btnSaveModel_Click);
            // 
            // btnTrainModel
            // 
            this.btnTrainModel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTrainModel.Location = new System.Drawing.Point(644, 0);
            this.btnTrainModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTrainModel.Name = "btnTrainModel";
            this.btnTrainModel.Size = new System.Drawing.Size(158, 34);
            this.btnTrainModel.TabIndex = 3;
            this.btnTrainModel.Text = "Train Model";
            this.btnTrainModel.UseVisualStyleBackColor = true;
            this.btnTrainModel.Visible = false;
            this.btnTrainModel.Click += new System.EventHandler(this.btnTrainModel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFinish.Location = new System.Drawing.Point(802, 0);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(158, 34);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrev.Location = new System.Drawing.Point(0, 0);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(158, 34);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.Location = new System.Drawing.Point(960, 0);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(158, 34);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pnlSelectOutput
            // 
            this.pnlSelectOutput.Controls.Add(this.dgvDataPreview);
            this.pnlSelectOutput.Controls.Add(this.panel5);
            this.pnlSelectOutput.Controls.Add(this.lblHeaderSelectOutput);
            this.pnlSelectOutput.Location = new System.Drawing.Point(666, 30);
            this.pnlSelectOutput.Name = "pnlSelectOutput";
            this.pnlSelectOutput.Size = new System.Drawing.Size(183, 142);
            this.pnlSelectOutput.TabIndex = 5;
            this.pnlSelectOutput.Visible = false;
            // 
            // dgvDataPreview
            // 
            this.dgvDataPreview.AllowUserToAddRows = false;
            this.dgvDataPreview.AllowUserToDeleteRows = false;
            this.dgvDataPreview.AllowUserToResizeRows = false;
            this.dgvDataPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataPreview.Location = new System.Drawing.Point(0, 15);
            this.dgvDataPreview.MultiSelect = false;
            this.dgvDataPreview.Name = "dgvDataPreview";
            this.dgvDataPreview.ReadOnly = true;
            this.dgvDataPreview.RowHeadersVisible = false;
            this.dgvDataPreview.RowTemplate.Height = 25;
            this.dgvDataPreview.Size = new System.Drawing.Size(7, 127);
            this.dgvDataPreview.TabIndex = 2;
            this.dgvDataPreview.SelectionChanged += new System.EventHandler(this.dgvDataPreview_SelectionChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbDataKinds);
            this.panel5.Controls.Add(this.cbIsLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(7, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(176, 127);
            this.panel5.TabIndex = 1;
            // 
            // lbDataKinds
            // 
            this.lbDataKinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDataKinds.FormattingEnabled = true;
            this.lbDataKinds.ItemHeight = 15;
            this.lbDataKinds.Location = new System.Drawing.Point(0, 24);
            this.lbDataKinds.Name = "lbDataKinds";
            this.lbDataKinds.Size = new System.Drawing.Size(176, 103);
            this.lbDataKinds.TabIndex = 1;
            this.lbDataKinds.SelectedIndexChanged += new System.EventHandler(this.DataSettingChanged);
            // 
            // cbIsLabel
            // 
            this.cbIsLabel.AutoSize = true;
            this.cbIsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbIsLabel.Location = new System.Drawing.Point(0, 0);
            this.cbIsLabel.Name = "cbIsLabel";
            this.cbIsLabel.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.cbIsLabel.Size = new System.Drawing.Size(176, 24);
            this.cbIsLabel.TabIndex = 0;
            this.cbIsLabel.Text = "Is Output";
            this.cbIsLabel.UseVisualStyleBackColor = true;
            this.cbIsLabel.CheckedChanged += new System.EventHandler(this.DataSettingChanged);
            // 
            // lblHeaderSelectOutput
            // 
            this.lblHeaderSelectOutput.AutoSize = true;
            this.lblHeaderSelectOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderSelectOutput.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderSelectOutput.Name = "lblHeaderSelectOutput";
            this.lblHeaderSelectOutput.Size = new System.Drawing.Size(212, 15);
            this.lblHeaderSelectOutput.TabIndex = 0;
            this.lblHeaderSelectOutput.Text = "Select Output and/or check data types:";
            // 
            // pnlConfig
            // 
            this.pnlConfig.Controls.Add(this.panel2);
            this.pnlConfig.Controls.Add(this.pnlTimeout);
            this.pnlConfig.Controls.Add(this.lblHeaderConfig);
            this.pnlConfig.Location = new System.Drawing.Point(839, 334);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(249, 156);
            this.pnlConfig.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cblModels);
            this.panel2.Controls.Add(this.pnlSaveFolder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 117);
            this.panel2.TabIndex = 2;
            // 
            // cblModels
            // 
            this.cblModels.Dock = System.Windows.Forms.DockStyle.Left;
            this.cblModels.FormattingEnabled = true;
            this.cblModels.Location = new System.Drawing.Point(0, 34);
            this.cblModels.Name = "cblModels";
            this.cblModels.Size = new System.Drawing.Size(179, 83);
            this.cblModels.TabIndex = 0;
            // 
            // pnlSaveFolder
            // 
            this.pnlSaveFolder.Controls.Add(this.lblSelectedFolder);
            this.pnlSaveFolder.Controls.Add(this.btnSelectFolder);
            this.pnlSaveFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSaveFolder.Location = new System.Drawing.Point(0, 0);
            this.pnlSaveFolder.Name = "pnlSaveFolder";
            this.pnlSaveFolder.Size = new System.Drawing.Size(249, 34);
            this.pnlSaveFolder.TabIndex = 1;
            // 
            // lblSelectedFolder
            // 
            this.lblSelectedFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectedFolder.Location = new System.Drawing.Point(179, 0);
            this.lblSelectedFolder.Name = "lblSelectedFolder";
            this.lblSelectedFolder.Size = new System.Drawing.Size(70, 34);
            this.lblSelectedFolder.TabIndex = 1;
            this.lblSelectedFolder.Text = "[no folder selected]";
            this.lblSelectedFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelectFolder.Location = new System.Drawing.Point(0, 0);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(179, 34);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // pnlTimeout
            // 
            this.pnlTimeout.Controls.Add(this.lblTimeout);
            this.pnlTimeout.Controls.Add(this.numTimeout);
            this.pnlTimeout.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimeout.Location = new System.Drawing.Point(0, 15);
            this.pnlTimeout.Name = "pnlTimeout";
            this.pnlTimeout.Size = new System.Drawing.Size(249, 24);
            this.pnlTimeout.TabIndex = 1;
            // 
            // lblTimeout
            // 
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimeout.Location = new System.Drawing.Point(130, 0);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(113, 15);
            this.lblTimeout.TabIndex = 1;
            this.lblTimeout.Text = "Timeout (Secounds)";
            // 
            // numTimeout
            // 
            this.numTimeout.Dock = System.Windows.Forms.DockStyle.Left;
            this.numTimeout.Location = new System.Drawing.Point(0, 0);
            this.numTimeout.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.Size = new System.Drawing.Size(130, 23);
            this.numTimeout.TabIndex = 0;
            this.numTimeout.Value = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            // 
            // lblHeaderConfig
            // 
            this.lblHeaderConfig.AutoSize = true;
            this.lblHeaderConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderConfig.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderConfig.Name = "lblHeaderConfig";
            this.lblHeaderConfig.Size = new System.Drawing.Size(43, 15);
            this.lblHeaderConfig.TabIndex = 0;
            this.lblHeaderConfig.Text = "Config";
            // 
            // pnlResault
            // 
            this.pnlResault.Controls.Add(this.dgvResults);
            this.pnlResault.Controls.Add(this.lblResault);
            this.pnlResault.Location = new System.Drawing.Point(946, 26);
            this.pnlResault.Name = "pnlResault";
            this.pnlResault.Size = new System.Drawing.Size(94, 78);
            this.pnlResault.TabIndex = 7;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(0, 15);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowTemplate.Height = 25;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.ShowEditingIcon = false;
            this.dgvResults.Size = new System.Drawing.Size(94, 63);
            this.dgvResults.TabIndex = 1;
            this.dgvResults.Sorted += new System.EventHandler(this.dgvResults_Sorted);
            // 
            // lblResault
            // 
            this.lblResault.AutoSize = true;
            this.lblResault.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResault.Location = new System.Drawing.Point(0, 0);
            this.lblResault.Name = "lblResault";
            this.lblResault.Size = new System.Drawing.Size(48, 15);
            this.lblResault.TabIndex = 0;
            this.lblResault.Text = "Resault:";
            // 
            // pnlWaiting
            // 
            this.pnlWaiting.Controls.Add(this.pictureBox1);
            this.pnlWaiting.Controls.Add(this.pbTrainingProgress);
            this.pnlWaiting.Controls.Add(this.label1);
            this.pnlWaiting.Location = new System.Drawing.Point(311, 12);
            this.pnlWaiting.Name = "pnlWaiting";
            this.pnlWaiting.Size = new System.Drawing.Size(164, 115);
            this.pnlWaiting.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pbTrainingProgress
            // 
            this.pbTrainingProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbTrainingProgress.Location = new System.Drawing.Point(0, 92);
            this.pbTrainingProgress.Name = "pbTrainingProgress";
            this.pbTrainingProgress.Size = new System.Drawing.Size(164, 23);
            this.pbTrainingProgress.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Wait: TrainingModel";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "onnx";
            this.saveFileDialog1.FileName = "onnx_model";
            // 
            // tmr1sec
            // 
            this.tmr1sec.Interval = 1000;
            this.tmr1sec.Tick += new System.EventHandler(this.tmr1sec_Tick);
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 550);
            this.Controls.Add(this.pnlWaiting);
            this.Controls.Add(this.pnlResault);
            this.Controls.Add(this.pnlConfig);
            this.Controls.Add(this.pnlSelectOutput);
            this.Controls.Add(this.pnlSelectData);
            this.Controls.Add(this.pnlSelectMLtype);
            this.Controls.Add(this.pnlNavigation);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Wizard";
            this.Text = "AutoML Wizard";
            this.pnlSelectMLtype.ResumeLayout(false);
            this.pnlSelectMLtype.PerformLayout();
            this.pnlSelectData.ResumeLayout(false);
            this.tabcrDataSources.ResumeLayout(false);
            this.tabDataFromFile.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabDataFromSQL.ResumeLayout(false);
            this.pnlQuerryHolder.ResumeLayout(false);
            this.pnlQuerryHolder.PerformLayout();
            this.pnlConStringHolder.ResumeLayout(false);
            this.pnlConStringHolder.PerformLayout();
            this.pnlNavigation.ResumeLayout(false);
            this.pnlSelectOutput.ResumeLayout(false);
            this.pnlSelectOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPreview)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlSaveFolder.ResumeLayout(false);
            this.pnlTimeout.ResumeLayout(false);
            this.pnlTimeout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            this.pnlResault.ResumeLayout(false);
            this.pnlResault.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.pnlWaiting.ResumeLayout(false);
            this.pnlWaiting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSelectMLtype;
        private System.Windows.Forms.Button btnRecommendation;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnMultiClas;
        private System.Windows.Forms.Button btnBinClas;
        private System.Windows.Forms.Button btnRanking;
        private System.Windows.Forms.Label lblHeaderSelectModel;
        private System.Windows.Forms.Panel pnlSelectData;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel pnlSelectOutput;
        private System.Windows.Forms.Label lblHeaderSelectOutput;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Label lblHeaderConfig;
        private System.Windows.Forms.Panel pnlTimeout;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlSaveFolder;
        private System.Windows.Forms.Label lblSelectedFolder;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.CheckedListBox cblModels;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbxFileName;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox cbHasHeader;
        private System.Windows.Forms.TextBox tbxSeparator;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.Panel pnlResault;
        private System.Windows.Forms.Label lblResault;
        private System.Windows.Forms.DataGridView dgvDataPreview;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListBox lbDataKinds;
        private System.Windows.Forms.CheckBox cbIsLabel;
        private System.Windows.Forms.Button btnTrainModel;
        private System.Windows.Forms.Panel pnlWaiting;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveModel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ProgressBar pbTrainingProgress;
        private System.Windows.Forms.Timer tmr1sec;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.TabControl tabcrDataSources;
        private System.Windows.Forms.TabPage tabDataFromFile;
        private System.Windows.Forms.TabPage tabDataFromSQL;
        private System.Windows.Forms.Panel pnlQuerryHolder;
        private System.Windows.Forms.TextBox txtQuerry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlConStringHolder;
        private System.Windows.Forms.TextBox txtConnString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExportResults;
    }
}

