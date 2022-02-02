
namespace ML
{
    partial class AddData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFromFile = new System.Windows.Forms.Button();
            this.btnFromDatabase = new System.Windows.Forms.Button();
            this.pnlSelectSource = new System.Windows.Forms.Panel();
            this.pnlManageFiles = new System.Windows.Forms.Panel();
            this.pnlMultiFile = new System.Windows.Forms.Panel();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbCronological = new System.Windows.Forms.CheckBox();
            this.cbPararell = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLoadFiles = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.LableStaticDelimitor = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlSelectSource.SuspendLayout();
            this.pnlManageFiles.SuspendLayout();
            this.pnlMultiFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFromFile
            // 
            this.btnFromFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFromFile.Location = new System.Drawing.Point(0, 22);
            this.btnFromFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFromFile.Name = "btnFromFile";
            this.btnFromFile.Size = new System.Drawing.Size(219, 22);
            this.btnFromFile.TabIndex = 0;
            this.btnFromFile.Text = "From file";
            this.btnFromFile.UseVisualStyleBackColor = true;
            this.btnFromFile.Click += new System.EventHandler(this.btnFromFile_Click);
            // 
            // btnFromDatabase
            // 
            this.btnFromDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFromDatabase.Location = new System.Drawing.Point(0, 0);
            this.btnFromDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFromDatabase.Name = "btnFromDatabase";
            this.btnFromDatabase.Size = new System.Drawing.Size(219, 22);
            this.btnFromDatabase.TabIndex = 1;
            this.btnFromDatabase.Text = "From database";
            this.btnFromDatabase.UseVisualStyleBackColor = true;
            // 
            // pnlSelectSource
            // 
            this.pnlSelectSource.Controls.Add(this.btnFromFile);
            this.pnlSelectSource.Controls.Add(this.btnFromDatabase);
            this.pnlSelectSource.Location = new System.Drawing.Point(133, 52);
            this.pnlSelectSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSelectSource.Name = "pnlSelectSource";
            this.pnlSelectSource.Size = new System.Drawing.Size(219, 94);
            this.pnlSelectSource.TabIndex = 2;
            // 
            // pnlManageFiles
            // 
            this.pnlManageFiles.Controls.Add(this.pnlMultiFile);
            this.pnlManageFiles.Controls.Add(this.panel2);
            this.pnlManageFiles.Controls.Add(this.panel1);
            this.pnlManageFiles.Location = new System.Drawing.Point(181, 150);
            this.pnlManageFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlManageFiles.Name = "pnlManageFiles";
            this.pnlManageFiles.Size = new System.Drawing.Size(437, 183);
            this.pnlManageFiles.TabIndex = 3;
            // 
            // pnlMultiFile
            // 
            this.pnlMultiFile.Controls.Add(this.dgvFiles);
            this.pnlMultiFile.Controls.Add(this.panel3);
            this.pnlMultiFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMultiFile.Location = new System.Drawing.Point(0, 21);
            this.pnlMultiFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMultiFile.Name = "pnlMultiFile";
            this.pnlMultiFile.Size = new System.Drawing.Size(437, 132);
            this.pnlMultiFile.TabIndex = 1;
            // 
            // dgvFiles
            // 
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiles.Location = new System.Drawing.Point(100, 0);
            this.dgvFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.RowHeadersWidth = 51;
            this.dgvFiles.RowTemplate.Height = 29;
            this.dgvFiles.Size = new System.Drawing.Size(337, 132);
            this.dgvFiles.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbCronological);
            this.panel3.Controls.Add(this.cbPararell);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 132);
            this.panel3.TabIndex = 0;
            // 
            // cbCronological
            // 
            this.cbCronological.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbCronological.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbCronological.Location = new System.Drawing.Point(0, 78);
            this.cbCronological.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCronological.Name = "cbCronological";
            this.cbCronological.Size = new System.Drawing.Size(100, 78);
            this.cbCronological.TabIndex = 2;
            this.cbCronological.Text = "Cronological";
            this.cbCronological.UseVisualStyleBackColor = true;
            // 
            // cbPararell
            // 
            this.cbPararell.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbPararell.Checked = true;
            this.cbPararell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPararell.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbPararell.Location = new System.Drawing.Point(0, 0);
            this.cbPararell.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPararell.Name = "cbPararell";
            this.cbPararell.Size = new System.Drawing.Size(100, 78);
            this.cbPararell.TabIndex = 1;
            this.cbPararell.Text = "Prararell";
            this.cbPararell.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLoadFiles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 153);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 30);
            this.panel2.TabIndex = 2;
            // 
            // btnLoadFiles
            // 
            this.btnLoadFiles.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLoadFiles.Location = new System.Drawing.Point(279, 0);
            this.btnLoadFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadFiles.Name = "btnLoadFiles";
            this.btnLoadFiles.Size = new System.Drawing.Size(158, 30);
            this.btnLoadFiles.TabIndex = 0;
            this.btnLoadFiles.Text = "Load File(s)";
            this.btnLoadFiles.UseVisualStyleBackColor = true;
            this.btnLoadFiles.Click += new System.EventHandler(this.btnLoadFiles_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDelimiter);
            this.panel1.Controls.Add(this.LableStaticDelimitor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 21);
            this.panel1.TabIndex = 0;
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDelimiter.Location = new System.Drawing.Point(59, 0);
            this.txtDelimiter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(35, 23);
            this.txtDelimiter.TabIndex = 1;
            this.txtDelimiter.Text = ",";
            this.txtDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LableStaticDelimitor
            // 
            this.LableStaticDelimitor.AutoSize = true;
            this.LableStaticDelimitor.Dock = System.Windows.Forms.DockStyle.Left;
            this.LableStaticDelimitor.Location = new System.Drawing.Point(0, 0);
            this.LableStaticDelimitor.Name = "LableStaticDelimitor";
            this.LableStaticDelimitor.Size = new System.Drawing.Size(59, 15);
            this.LableStaticDelimitor.TabIndex = 0;
            this.LableStaticDelimitor.Text = "Delimitor:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Datafile.csv";
            this.openFileDialog1.Multiselect = true;
            // 
            // AddData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.pnlManageFiles);
            this.Controls.Add(this.pnlSelectSource);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddData";
            this.Text = "AddData";
            this.Load += new System.EventHandler(this.AddData_Load);
            this.pnlSelectSource.ResumeLayout(false);
            this.pnlManageFiles.ResumeLayout(false);
            this.pnlMultiFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFromFile;
        private System.Windows.Forms.Button btnFromDatabase;
        private System.Windows.Forms.Panel pnlSelectSource;
        private System.Windows.Forms.Panel pnlManageFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel pnlMultiFile;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox cbCronological;
        private System.Windows.Forms.CheckBox cbPararell;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.Label LableStaticDelimitor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLoadFiles;
        private System.Windows.Forms.DataGridView dgvFiles;
    }
}