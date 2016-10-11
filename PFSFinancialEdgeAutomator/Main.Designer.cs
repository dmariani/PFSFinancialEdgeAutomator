namespace PFSFinancialEdgeAutomator
{
    partial class Main
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
            this.go = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.labelDirectoryOutputDir = new System.Windows.Forms.Label();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.chooseOutputDir = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDirectoryCatMappingDir = new System.Windows.Forms.Label();
            this.textBoxCatMappingDir = new System.Windows.Forms.TextBox();
            this.chooseCatMappingDir = new System.Windows.Forms.Button();
            this.labelExpenseFileDir = new System.Windows.Forms.Label();
            this.textBoxExpenseFileDir = new System.Windows.Forms.TextBox();
            this.chooseExpenseFileDir = new System.Windows.Forms.Button();
            this.openFileDialogCSV = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogExcel = new System.Windows.Forms.OpenFileDialog();
            this.labelDirectoryTagsMappingDir = new System.Windows.Forms.Label();
            this.textBoxTagsMappingDir = new System.Windows.Forms.TextBox();
            this.chooseTagsMappingDir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerPostingDate = new System.Windows.Forms.DateTimePicker();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(196, 264);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 14;
            this.go.Text = "&Go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(327, 264);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 15;
            this.close.Text = "&Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // labelDirectoryOutputDir
            // 
            this.labelDirectoryOutputDir.AutoSize = true;
            this.labelDirectoryOutputDir.Location = new System.Drawing.Point(23, 170);
            this.labelDirectoryOutputDir.Name = "labelDirectoryOutputDir";
            this.labelDirectoryOutputDir.Size = new System.Drawing.Size(132, 13);
            this.labelDirectoryOutputDir.TabIndex = 10;
            this.labelDirectoryOutputDir.Text = "FE Output CSV File Name:";
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(219, 167);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(292, 20);
            this.textBoxDir.TabIndex = 11;
            this.textBoxDir.Text = "c:\\";
            // 
            // chooseOutputDir
            // 
            this.chooseOutputDir.Location = new System.Drawing.Point(517, 165);
            this.chooseOutputDir.Name = "chooseOutputDir";
            this.chooseOutputDir.Size = new System.Drawing.Size(40, 23);
            this.chooseOutputDir.TabIndex = 12;
            this.chooseOutputDir.Text = "...";
            this.chooseOutputDir.UseVisualStyleBackColor = true;
            this.chooseOutputDir.Click += new System.EventHandler(this.chooseDir_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 290);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(599, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "Status";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // labelDirectoryCatMappingDir
            // 
            this.labelDirectoryCatMappingDir.AutoSize = true;
            this.labelDirectoryCatMappingDir.Location = new System.Drawing.Point(23, 37);
            this.labelDirectoryCatMappingDir.Name = "labelDirectoryCatMappingDir";
            this.labelDirectoryCatMappingDir.Size = new System.Drawing.Size(178, 13);
            this.labelDirectoryCatMappingDir.TabIndex = 1;
            this.labelDirectoryCatMappingDir.Text = "Categories Mapping CSV File Name:";
            // 
            // textBoxCatMappingDir
            // 
            this.textBoxCatMappingDir.Location = new System.Drawing.Point(219, 35);
            this.textBoxCatMappingDir.Name = "textBoxCatMappingDir";
            this.textBoxCatMappingDir.Size = new System.Drawing.Size(292, 20);
            this.textBoxCatMappingDir.TabIndex = 2;
            this.textBoxCatMappingDir.Text = "c:\\";
            // 
            // chooseCatMappingDir
            // 
            this.chooseCatMappingDir.Location = new System.Drawing.Point(517, 34);
            this.chooseCatMappingDir.Name = "chooseCatMappingDir";
            this.chooseCatMappingDir.Size = new System.Drawing.Size(40, 23);
            this.chooseCatMappingDir.TabIndex = 3;
            this.chooseCatMappingDir.Text = "...";
            this.chooseCatMappingDir.UseVisualStyleBackColor = true;
            this.chooseCatMappingDir.Click += new System.EventHandler(this.chooseMappingDir_Click);
            // 
            // labelExpenseFileDir
            // 
            this.labelExpenseFileDir.AutoSize = true;
            this.labelExpenseFileDir.Location = new System.Drawing.Point(23, 117);
            this.labelExpenseFileDir.Name = "labelExpenseFileDir";
            this.labelExpenseFileDir.Size = new System.Drawing.Size(167, 13);
            this.labelExpenseFileDir.TabIndex = 7;
            this.labelExpenseFileDir.Text = "Expensify Export Excel File Name:";
            // 
            // textBoxExpenseFileDir
            // 
            this.textBoxExpenseFileDir.Location = new System.Drawing.Point(219, 116);
            this.textBoxExpenseFileDir.Name = "textBoxExpenseFileDir";
            this.textBoxExpenseFileDir.Size = new System.Drawing.Size(292, 20);
            this.textBoxExpenseFileDir.TabIndex = 8;
            this.textBoxExpenseFileDir.Text = "c:\\";
            // 
            // chooseExpenseFileDir
            // 
            this.chooseExpenseFileDir.Location = new System.Drawing.Point(517, 114);
            this.chooseExpenseFileDir.Name = "chooseExpenseFileDir";
            this.chooseExpenseFileDir.Size = new System.Drawing.Size(40, 23);
            this.chooseExpenseFileDir.TabIndex = 9;
            this.chooseExpenseFileDir.Text = "...";
            this.chooseExpenseFileDir.UseVisualStyleBackColor = true;
            this.chooseExpenseFileDir.Click += new System.EventHandler(this.chooseExpenseFileDir_Click);
            // 
            // openFileDialogCSV
            // 
            this.openFileDialogCSV.DefaultExt = "xlsx";
            this.openFileDialogCSV.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*\"";
            this.openFileDialogCSV.ReadOnlyChecked = true;
            this.openFileDialogCSV.Title = "Choose the Mapping CSV File";
            // 
            // openFileDialogExcel
            // 
            this.openFileDialogExcel.DefaultExt = "csv";
            this.openFileDialogExcel.Filter = "Excel xls Files (.xls)|*.xls|Excel xlsx Files (.xlsx)|*.xlsx|All Files (*.*)|*.*\"" +
    "";
            this.openFileDialogExcel.ReadOnlyChecked = true;
            this.openFileDialogExcel.Title = "Choose the Expense Excel File";
            // 
            // labelDirectoryTagsMappingDir
            // 
            this.labelDirectoryTagsMappingDir.AutoSize = true;
            this.labelDirectoryTagsMappingDir.Location = new System.Drawing.Point(23, 77);
            this.labelDirectoryTagsMappingDir.Name = "labelDirectoryTagsMappingDir";
            this.labelDirectoryTagsMappingDir.Size = new System.Drawing.Size(152, 13);
            this.labelDirectoryTagsMappingDir.TabIndex = 4;
            this.labelDirectoryTagsMappingDir.Text = "Tags Mapping CSV File Name:";
            // 
            // textBoxTagsMappingDir
            // 
            this.textBoxTagsMappingDir.Location = new System.Drawing.Point(219, 74);
            this.textBoxTagsMappingDir.Name = "textBoxTagsMappingDir";
            this.textBoxTagsMappingDir.Size = new System.Drawing.Size(292, 20);
            this.textBoxTagsMappingDir.TabIndex = 5;
            this.textBoxTagsMappingDir.Text = "c:\\";
            // 
            // chooseTagsMappingDir
            // 
            this.chooseTagsMappingDir.Location = new System.Drawing.Point(517, 73);
            this.chooseTagsMappingDir.Name = "chooseTagsMappingDir";
            this.chooseTagsMappingDir.Size = new System.Drawing.Size(40, 23);
            this.chooseTagsMappingDir.TabIndex = 6;
            this.chooseTagsMappingDir.Text = "...";
            this.chooseTagsMappingDir.UseVisualStyleBackColor = true;
            this.chooseTagsMappingDir.Click += new System.EventHandler(this.chooseTagsMappingDir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 135);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input FIles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Posting Date:";
            // 
            // dateTimePickerPostingDate
            // 
            this.dateTimePickerPostingDate.CustomFormat = "MM/dd/yy";
            this.dateTimePickerPostingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPostingDate.Location = new System.Drawing.Point(219, 213);
            this.dateTimePickerPostingDate.Name = "dateTimePickerPostingDate";
            this.dateTimePickerPostingDate.Size = new System.Drawing.Size(97, 20);
            this.dateTimePickerPostingDate.TabIndex = 13;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 312);
            this.Controls.Add(this.dateTimePickerPostingDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseTagsMappingDir);
            this.Controls.Add(this.textBoxTagsMappingDir);
            this.Controls.Add(this.labelDirectoryTagsMappingDir);
            this.Controls.Add(this.chooseExpenseFileDir);
            this.Controls.Add(this.textBoxExpenseFileDir);
            this.Controls.Add(this.labelExpenseFileDir);
            this.Controls.Add(this.chooseCatMappingDir);
            this.Controls.Add(this.textBoxCatMappingDir);
            this.Controls.Add(this.labelDirectoryCatMappingDir);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.chooseOutputDir);
            this.Controls.Add(this.textBoxDir);
            this.Controls.Add(this.labelDirectoryOutputDir);
            this.Controls.Add(this.close);
            this.Controls.Add(this.go);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PFS Financial Edge Automator";
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button go;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label labelDirectoryOutputDir;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Button chooseOutputDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label labelDirectoryCatMappingDir;
        private System.Windows.Forms.TextBox textBoxCatMappingDir;
        private System.Windows.Forms.Button chooseCatMappingDir;
        private System.Windows.Forms.Label labelExpenseFileDir;
        private System.Windows.Forms.TextBox textBoxExpenseFileDir;
        private System.Windows.Forms.Button chooseExpenseFileDir;
        private System.Windows.Forms.OpenFileDialog openFileDialogCSV;
        private System.Windows.Forms.OpenFileDialog openFileDialogExcel;
        private System.Windows.Forms.Label labelDirectoryTagsMappingDir;
        private System.Windows.Forms.TextBox textBoxTagsMappingDir;
        private System.Windows.Forms.Button chooseTagsMappingDir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerPostingDate;
    }
}

