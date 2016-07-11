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
            this.labelDirectoryMappingDir = new System.Windows.Forms.Label();
            this.textBoxMappingDir = new System.Windows.Forms.TextBox();
            this.chooseMappingDir = new System.Windows.Forms.Button();
            this.labelExpenseFileDir = new System.Windows.Forms.Label();
            this.textBoxExpenseFileDir = new System.Windows.Forms.TextBox();
            this.chooseExpenseFileDir = new System.Windows.Forms.Button();
            this.openFileDialogExcel = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogCSV = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(176, 154);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 10;
            this.go.Text = "&Go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(307, 154);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 11;
            this.close.Text = "&Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // labelDirectoryOutputDir
            // 
            this.labelDirectoryOutputDir.AutoSize = true;
            this.labelDirectoryOutputDir.Location = new System.Drawing.Point(23, 114);
            this.labelDirectoryOutputDir.Name = "labelDirectoryOutputDir";
            this.labelDirectoryOutputDir.Size = new System.Drawing.Size(132, 13);
            this.labelDirectoryOutputDir.TabIndex = 7;
            this.labelDirectoryOutputDir.Text = "FE Output CSV File Name:";
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(192, 111);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(292, 20);
            this.textBoxDir.TabIndex = 8;
            this.textBoxDir.Text = "c:\\";
            // 
            // chooseOutputDir
            // 
            this.chooseOutputDir.Location = new System.Drawing.Point(490, 109);
            this.chooseOutputDir.Name = "chooseOutputDir";
            this.chooseOutputDir.Size = new System.Drawing.Size(40, 23);
            this.chooseOutputDir.TabIndex = 9;
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
            this.statusStrip.Location = new System.Drawing.Point(0, 192);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(558, 22);
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
            // labelDirectoryMappingDir
            // 
            this.labelDirectoryMappingDir.AutoSize = true;
            this.labelDirectoryMappingDir.Location = new System.Drawing.Point(23, 33);
            this.labelDirectoryMappingDir.Name = "labelDirectoryMappingDir";
            this.labelDirectoryMappingDir.Size = new System.Drawing.Size(165, 13);
            this.labelDirectoryMappingDir.TabIndex = 1;
            this.labelDirectoryMappingDir.Text = "Mapping Input EXCEL File Name:";
            // 
            // textBoxMappingDir
            // 
            this.textBoxMappingDir.Location = new System.Drawing.Point(192, 31);
            this.textBoxMappingDir.Name = "textBoxMappingDir";
            this.textBoxMappingDir.Size = new System.Drawing.Size(292, 20);
            this.textBoxMappingDir.TabIndex = 2;
            this.textBoxMappingDir.Text = "c:\\";
            // 
            // chooseMappingDir
            // 
            this.chooseMappingDir.Location = new System.Drawing.Point(490, 30);
            this.chooseMappingDir.Name = "chooseMappingDir";
            this.chooseMappingDir.Size = new System.Drawing.Size(40, 23);
            this.chooseMappingDir.TabIndex = 3;
            this.chooseMappingDir.Text = "...";
            this.chooseMappingDir.UseVisualStyleBackColor = true;
            this.chooseMappingDir.Click += new System.EventHandler(this.chooseMappingDir_Click);
            // 
            // labelExpenseFileDir
            // 
            this.labelExpenseFileDir.AutoSize = true;
            this.labelExpenseFileDir.Location = new System.Drawing.Point(23, 71);
            this.labelExpenseFileDir.Name = "labelExpenseFileDir";
            this.labelExpenseFileDir.Size = new System.Drawing.Size(152, 13);
            this.labelExpenseFileDir.TabIndex = 4;
            this.labelExpenseFileDir.Text = "Expense Input CSV File Name:";
            // 
            // textBoxExpenseFileDir
            // 
            this.textBoxExpenseFileDir.Location = new System.Drawing.Point(192, 70);
            this.textBoxExpenseFileDir.Name = "textBoxExpenseFileDir";
            this.textBoxExpenseFileDir.Size = new System.Drawing.Size(292, 20);
            this.textBoxExpenseFileDir.TabIndex = 5;
            this.textBoxExpenseFileDir.Text = "c:\\";
            // 
            // chooseExpenseFileDir
            // 
            this.chooseExpenseFileDir.Location = new System.Drawing.Point(490, 68);
            this.chooseExpenseFileDir.Name = "chooseExpenseFileDir";
            this.chooseExpenseFileDir.Size = new System.Drawing.Size(40, 23);
            this.chooseExpenseFileDir.TabIndex = 6;
            this.chooseExpenseFileDir.Text = "...";
            this.chooseExpenseFileDir.UseVisualStyleBackColor = true;
            this.chooseExpenseFileDir.Click += new System.EventHandler(this.chooseExpenseFileDir_Click);
            // 
            // openFileDialogExcel
            // 
            this.openFileDialogExcel.DefaultExt = "xlsx";
            this.openFileDialogExcel.Filter = "Excel Files (.xlsx)|*.xlsx|All Files (*.*)|*.*\"";
            this.openFileDialogExcel.ReadOnlyChecked = true;
            this.openFileDialogExcel.Title = "Choose the Mapping Excel File";
            // 
            // openFileDialogCSV
            // 
            this.openFileDialogCSV.DefaultExt = "csv";
            this.openFileDialogCSV.Filter = "Text Files (.txt)|*.txt|CSV Files (.csv)|*.csv|All Files (*.*)|*.*\"";
            this.openFileDialogCSV.ReadOnlyChecked = true;
            this.openFileDialogCSV.Title = "Choose the Expense CSV File";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 214);
            this.Controls.Add(this.chooseExpenseFileDir);
            this.Controls.Add(this.textBoxExpenseFileDir);
            this.Controls.Add(this.labelExpenseFileDir);
            this.Controls.Add(this.chooseMappingDir);
            this.Controls.Add(this.textBoxMappingDir);
            this.Controls.Add(this.labelDirectoryMappingDir);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.chooseOutputDir);
            this.Controls.Add(this.textBoxDir);
            this.Controls.Add(this.labelDirectoryOutputDir);
            this.Controls.Add(this.close);
            this.Controls.Add(this.go);
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
        private System.Windows.Forms.Label labelDirectoryMappingDir;
        private System.Windows.Forms.TextBox textBoxMappingDir;
        private System.Windows.Forms.Button chooseMappingDir;
        private System.Windows.Forms.Label labelExpenseFileDir;
        private System.Windows.Forms.TextBox textBoxExpenseFileDir;
        private System.Windows.Forms.Button chooseExpenseFileDir;
        private System.Windows.Forms.OpenFileDialog openFileDialogExcel;
        private System.Windows.Forms.OpenFileDialog openFileDialogCSV;
    }
}

