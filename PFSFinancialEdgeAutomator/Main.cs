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
                // X(FUND)-XX(DIVISION)-XXX(PROGRAM)-XXXXX(PROJECT ID)
                Dictionary<String, String> dictionaryTagsMappings = ReadMappings(inputTagsMappingFileName);

                // Open the Expense File
                toolStripStatusLabel.Text = "Reading: " + inputExpenseFileName + " ...";
                statusStrip.Refresh();

                DataTable ExpenseData = GetDataTabletFromCSVFile(inputExpenseFileName, ",");
                Console.WriteLine("Rows count:" + ExpenseData.Rows.Count);

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
                        // Parse Amount
                        if (!row.Table.Columns.Contains("Amount"))
                        {
                            throw new Exception("Can't find the required field 'Amount' in the Expensify Export File named: " + inputExpenseFileName);
                        }

                        String Amt = row["Amount"].ToString().Replace("(", "-").Replace(")", "").Trim();
                        double dblAmt = Convert.ToDouble(Amt);

                        // Parse Category
                        //
                        if (!row.Table.Columns.Contains("Category"))
                        {
                            throw new Exception("Can't find the required field 'Category' in the Expensify Export File named: " + inputExpenseFileName);
                        }

                        String catExpensify = row["Category"].ToString().ToUpper().Trim();

                        // Now lookup Expensify Cat in our Map
                        if (!dictionaryCatMappings.ContainsKey(catExpensify))
                        {
                            throw new Exception("Can't find mapping code for Category: " + catExpensify + " in file: " + inputCatMappingFileName);
                        }

                        String catGLCode = dictionaryCatMappings[catExpensify];

                        // Parse Tag
                        //
                        if (!row.Table.Columns.Contains("Tag"))
                        {
                            throw new Exception("Can't find the required field 'Tag' in the Expensify Export File named: " + inputExpenseFileName);
                        }

                        String tagExpensify = row["Tag"].ToString().ToUpper().Trim();

                        // Now lookup Expensify Tab in our Map
                        if (!dictionaryTagsMappings.ContainsKey(tagExpensify))
                        {
                            throw new Exception("Can't find mapping code for Tag: " + tagExpensify + " in file: " + inputTagsMappingFileName);
                        }

                        String tagsGLCode = dictionaryTagsMappings[tagExpensify];

                        // Now split out the GL Code into its parts
                        // Tags = X(FUND):XX(DIVISION):XXX(PROGRAM):XXXXX(PROJECT ID)
                        string[] tagArray = tagsGLCode.Split(':');
                        if (tagArray.Length != 4)
                        {
                            throw new Exception("The GL Code for the Tag: " + tagExpensify + " doesn't have the required 4 parts of X(FUND)-XX(DIVISION)-XXX(PROGRAM)-XXXXX(PROJECT ID) in file: " + inputExpenseFileName);
                        }

                        String Fund = tagArray[0];
                        String Division = tagArray[1];
                        String Program = tagArray[2];
                        String Project = tagArray[3];

                        // Add delimiter
                        if (i > 0)
                            body.Append(",");

                        // We need to calculate fields that don't match directly
                        string fieldOut = fields[i,0].ToString();
                        string fieldIn = fields[i,1].ToString();
                        if (fieldIn.Length == 0)
                        {
                            if (fieldOut == "AccountNumber")
                            {
                                // Tags PLUS Categories MINUS Project ID
                                body.Append(Fund + "-" + Division + "-" + Program + "-" + catGLCode);
                            }
                            else if (fieldOut == "Type")
                            {
                                // If negative, absolute value and make it a "C", else "D"
                                if (dblAmt < 0)
                                    body.Append("C");
                                else
                                    body.Append("D");
                            }
                            else if (fieldOut == "Journal")
                            {
                                body.Append("Journal Entry");
                            }
                            else if (fieldOut == "ProjectID")
                            {
                                // If 00000, blank out
                                if (Project == "00000")
                                    body.Append("");
                                else
                                    body.Append(Project);
                            }
                            else if (fieldOut == "EncumbranceStatus")
                            {
                                body.Append("R");
                            }
                        }
                        else
                        {
                            if (!row.Table.Columns.Contains(fieldIn))
                            {
                                throw new Exception("The required field: '" + fieldIn + "' is missing from the expense file: " + inputExpenseFileName);
                            }
                            
                            string value = row[fieldIn].ToString();
                            
                            if (fieldIn == "Timestamp")
                            {
                                DateTime result = DateTime.ParseExact(value, "yyyy-MM-dd H:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                                value = result.ToString("MM/dd/yy");
                            }
                            else if (fieldIn == "Amount")
                            {
                                // Make Amount the absolute value
                                value = Math.Abs(dblAmt).ToString();
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

                dictionaryMappings.Add(row["name"].ToString().ToUpper().Trim(), row["glcode"].ToString());
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
