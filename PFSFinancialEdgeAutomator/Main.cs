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
using Microsoft.VisualBasic.FileIO;
using System.Globalization;

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

            textBoxCatMappingDir.Text = Properties.Settings.Default["inputCatMappingDir"].ToString();
            textBoxTagsMappingDir.Text = Properties.Settings.Default["inputTagsMappingDir"].ToString();
            textBoxExpenseFileDir.Text = Properties.Settings.Default["inputExpenseDir"].ToString();
            textBoxDir.Text = Properties.Settings.Default["outputDir"].ToString();
        }

        private void SaveOptions()
        {
            Properties.Settings.Default["inputCatMappingDir"] = textBoxCatMappingDir.Text;
            Properties.Settings.Default["inputTagsMappingDir"] = textBoxTagsMappingDir.Text;
            Properties.Settings.Default["inputExpenseDir"] = textBoxExpenseFileDir.Text;
            Properties.Settings.Default["outputDir"] = textBoxDir.Text;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
        }

        private void go_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to begin the expense processing?", "Confirm Export", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                String inputCatMappingFileName = textBoxCatMappingDir.Text;
                String inputTagsMappingFileName = textBoxTagsMappingDir.Text;
                String inputExpenseFileName = textBoxExpenseFileDir.Text;
                String outputFileName = textBoxDir.Text;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    long rowsExported = ProcessExpenseFile(inputCatMappingFileName, inputTagsMappingFileName, inputExpenseFileName, outputFileName);

                    toolStripStatusLabel.Text = "Export succeeded.";
                    statusStrip.Refresh();
                    SaveOptions();
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

        private void chooseMappingDir_Click(object sender, EventArgs e)
        {
            openFileDialogCSV.Title = "Choose the Categories Mapping CSV File";

            if (openFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                textBoxCatMappingDir.Text = openFileDialogCSV.FileName;
            }
        }

        private void chooseTagsMappingDir_Click(object sender, EventArgs e)
        {
            openFileDialogCSV.Title = "Choose the Tags Mapping CSV File";

            if (openFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                textBoxTagsMappingDir.Text = openFileDialogCSV.FileName;
            }
        }

        private void chooseExpenseFileDir_Click(object sender, EventArgs e)
        {
            if (openFileDialogTXT.ShowDialog() == DialogResult.OK)
            {
                textBoxExpenseFileDir.Text = openFileDialogTXT.FileName;
            }
        }

        private long ProcessExpenseFile(String inputCatMappingFileName, String inputTagsMappingFileName, String inputExpenseFileName, String outputFileName)
        {
            long rowsExported = 0;

            try
            {
                // Remove the output file
                System.IO.File.Delete(outputFileName);

                // Load the Category Mapping File
                toolStripStatusLabel.Text = "Reading: " + inputCatMappingFileName + " ...";
                statusStrip.Refresh();

                // Category = Expense Type
                Dictionary<String, String> dictionaryCatMappings = ReadMappings(inputCatMappingFileName);

                // Load the Tags Mapping File
                toolStripStatusLabel.Text = "Reading: " + inputTagsMappingFileName + " ...";
                statusStrip.Refresh();

                // Tag = Location/Program
                Dictionary<String, String> dictionaryTagsMappings = ReadMappings(inputTagsMappingFileName);

                // Open the Expense File
                toolStripStatusLabel.Text = "Reading: " + inputExpenseFileName + " ...";
                statusStrip.Refresh();

                DataTable ExpenseData = GetDataTabletFromCSVFile(inputExpenseFileName, "\t");
                Console.WriteLine("Rows count:" + ExpenseData.Rows.Count);

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
                foreach (DataRow row in ExpenseData.Rows)
                {                    
                    for (int i = 0; i < fields.GetLength(0); i++)
                    {
                        if (i > 0)
                            body.Append(",");

                        // We need to calculate fields that don't match directly
                        if (fields[i,1].Length == 0)
                        {

                        }
                        else
                        {
                            string field = fields[i,1].ToString();
                            if (!row.Table.Columns.Contains(field))
                            {
                                throw new Exception("The required field: '" + field + "' is missing from the expense file: " + inputExpenseFileName);
                            }
                            
                            string value = row[field].ToString();
                            
                            if (field == "Timestamp")
                            {
                                DateTime result = DateTime.ParseExact(value, "M/d/yy H:mm", System.Globalization.CultureInfo.CurrentCulture);
                                value = result.ToString("MM/dd/yy");
                            }
                            
                            body.Append(value);
                        }
                    }

                    rowsExported++;
                    body.AppendLine();
                }


                // Write to the Output File
                toolStripStatusLabel.Text = "Writing to: " + outputFileName + " ...";
                statusStrip.Refresh();

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

        private static Dictionary<String, String> ReadMappings(String inputTagsMappingFileName)
        {
            Dictionary<String, String> dictionaryMappings = new Dictionary<String, String>();

            DataTable MappingData = GetDataTabletFromCSVFile(inputTagsMappingFileName, ",");
            Console.WriteLine("Rows count for " + inputTagsMappingFileName + ": " + MappingData.Rows.Count);

            foreach (DataRow row in MappingData.Rows)
            {
                if (!row.Table.Columns.Contains("name"))
                {
                    throw new Exception("The required field: '" + "name" + "' is missing from the mappings file: " + inputTagsMappingFileName);
                }

                if (!row.Table.Columns.Contains("glcode"))
                {
                    throw new Exception("The required field: '" + "glcode" + "' is missing from the mappings file: " + inputTagsMappingFileName);
                }

                dictionaryMappings.Add(row["name"].ToString(), row["glcode"].ToString());
            }  

            return dictionaryMappings;
        }

        private static DataTable GetDataTabletFromCSVFile(string csv_file_path, string delimiter)
        {
            DataTable csvData = new DataTable();

            try
            {

                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { delimiter });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return csvData;
        }
    }
}
