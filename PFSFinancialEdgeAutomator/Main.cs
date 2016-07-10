using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace PFSFinancialEdgeAutomator
{
    public partial class Main : Form
    {
        Boolean bExportWasRunSuccessfully = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }

        private void LoadOptions()
        {
            Properties.Settings.Default.Reload(); // Loads settings in application configuration file

            textBoxMappingDir.Text = Properties.Settings.Default["inputMappingDir"].ToString();
            textBoxExpenseFileDir.Text = Properties.Settings.Default["inputExpenseDir"].ToString();
            textBoxDir.Text = Properties.Settings.Default["outputDir"].ToString();
        }

        private void SaveOptions()
        {
            Properties.Settings.Default["inputMappingDir"] = textBoxMappingDir.Text;
            Properties.Settings.Default["inputExpenseDir"] = textBoxExpenseFileDir.Text;
            Properties.Settings.Default["outputDir"] = textBoxDir.Text;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
        }

        private void go_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to begin the expense processing?", "Confirm Export", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                String inputMappingFileName = textBoxMappingDir.Text;
                String inputExpenseFileName = textBoxExpenseFileDir.Text;
                String outputFileName = textBoxDir.Text;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    // Remove the output file
                    System.IO.File.Delete(outputFileName);

                    // Ceeate the Output File
                    toolStripStatusLabel.Text = "Creating: " + outputFileName + " ...";
                    statusStrip.Refresh();

                    // Load the Mapping File
                    toolStripStatusLabel.Text = "Reading: " + inputMappingFileName + " ...";
                    statusStrip.Refresh();

                    // Open the Expense File
                    toolStripStatusLabel.Text = "Opening: " + inputExpenseFileName + " ...";
                    statusStrip.Refresh();

                    long rowsExported = ProcessExpenseFile(inputMappingFileName, inputExpenseFileName, outputFileName);

                    toolStripStatusLabel.Text = "Export succeeded.";
                    statusStrip.Refresh();

                    bExportWasRunSuccessfully = true;

                    MessageBox.Show("Success!  Exported " + rowsExported.ToString() + " and wrote files to: " + textBoxDir.Text, "Export Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel.Text = "Export failed.";
                    statusStrip.Refresh();

                    MessageBox.Show("Error: " + ex.Message, "Export Results", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Cursor.Current = Cursors.Default;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            SaveOptions();
            this.Close();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void chooseDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private long ProcessExpenseFile(String inputMappingFileName, String inputExpenseFileName, String outputFileName)
        {
            long rowsExported = 0;

            try
            {
                // Category = Expense Type
                Dictionary<String, String> dictionaryCatMappings = new Dictionary<String, String>();
                dictionaryCatMappings.Add("ExpensifyCategory", "GLCode");

                // Tag = Location/Program
                Dictionary<String, String> dictionaryTagMappings = new Dictionary<String, String>();
                dictionaryTagMappings.Add("ExpensifyTag", "GLCode");

//                if (dictionaryCatMappings.ContainsKey("School"))
//                {
//                    String value = dictionaryCatMappings["School"];
//                    body.Append(value);
//                }


                toolStripStatusLabel.Text = "Writing data to files...";
                statusStrip.Refresh();

                string[,] fields = new string[8,2] { 
                { "AccountNumber", "" },
                { "PostDate", "Timestamp" },
                { "Type", "" }, 
                { "Amount", "Amount" },
                { "Journal", "" },
                { "JournalReference", "Comment" },
                { "ProjectID", "" },
                { "EncumbranceStatus", "" },
                };

                StringBuilder body = new StringBuilder();
                StringBuilder header = new StringBuilder();
                    
                // Write headers for main info
                for (int i = 0; i < fields.GetLength(0); i++)
                {
                    if (header.Length > 0)
                        header.Append(",");

                    header.Append(fields[i, 0]);
                }

                header.AppendLine();
                body.Append(header);

                // Loop through expense file
                //
                    body.AppendLine();

                // Now write the files
                System.IO.File.WriteAllText(outputFileName, body.ToString());

                return rowsExported;
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void directory_Click(object sender, EventArgs e)
        {

        }
    }
}
