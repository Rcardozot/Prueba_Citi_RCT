using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class ExportForm : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        public string FileFilter;
        public ExportForm(string name)
        {
            this.Name = name;
            InitializeComponent();
        }


        private void ExportForm_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dn12153\Documents\Access\ClientesM.accdb");
            DisplayData();
        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapter = new OleDbDataAdapter("select ID, Nombres, Apellidos, TipoID, NoIdentificacion, FechaNacimiento from Clientes", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            con.Close();
        }

        private void ComboFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboFile.SelectedItem == "Excel")
            {
                Combo2.Items.Clear();
                Combo2.Items.Add(".xls");
                Combo2.Items.Add(".xlsx");
                Combo2.Enabled = true;
            }
            else
            {
                Combo2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ComboFile.SelectedItem != "")
            {
                if (ComboFile.SelectedItem == "Excel")
                {
                    if (Combo2.SelectedItem == ".xls")
                    {
                        FileFilter = "Archivos Excel (*.xls)|*.xls";
                        ExportExcel2();
                    }
                    else if (Combo2.SelectedItem == ".xlsx")
                    {
                        FileFilter = "Archivos Excel (*.xlsx)|*.xlsx";
                        ExportExcel();
                    }
                }
                else if (ComboFile.SelectedItem == "Csv")
                {
                    saveFileDialog1.Filter = "Archivos CSV(*.csv)|*.csv";
                    saveFileDialog1.FileName = "CSV-ExportClientes.csv";
                    saveFileDialog1.ShowDialog();
                    SaveDataGridViewToCSV(saveFileDialog1.FileName);
                }
                else if (ComboFile.SelectedItem == "Txt")
                {

                }
                else if (ComboFile.SelectedItem == "XML")
                {

                }
                else if (ComboFile.SelectedItem == "Json")
                {

                }
                else
                {
                    MessageBox.Show("Informacion Introducida no valida.");
                }

            }
            else
            {
                MessageBox.Show("Por favor seleccione todos los campos.");
            }
        }
        private void ExportExcel()
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "Exportado";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = FileFilter;
                //saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }
        private void ExportExcel2()
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = false;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivos Excel (*.xls)|*.xls";
            //saveDialog.FilterIndex = 2;

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workbook.SaveAs(saveDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show("Export Successful");
            }
            // save the application  
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
        }
        private void ToCSV()
        {
            string CsvFpath = @"C:\scanner\CSV-EXPORT.csv";
            try
            {
                System.IO.StreamWriter csvFileWriter = new StreamWriter(CsvFpath, false);

                string columnHeaderText = "";

                int countColumn = dataGridView1.ColumnCount - 1;

                if (countColumn >= 0)
                {
                    columnHeaderText = dataGridView1.Columns[0].HeaderText;
                }

                for (int i = 1; i <= countColumn; i++)
                {
                    columnHeaderText = columnHeaderText + ',' + dataGridView1.Columns[i].HeaderText;
                }


                csvFileWriter.WriteLine(columnHeaderText);

                foreach (DataGridViewRow dataRowObject in dataGridView1.Rows)
                {
                    if (!dataRowObject.IsNewRow)
                    {
                        string dataFromGrid = "";

                        dataFromGrid = dataRowObject.Cells[0].Value.ToString();

                        for (int i = 1; i <= countColumn; i++)
                        {
                            dataFromGrid = dataFromGrid + ',' + dataRowObject.Cells[i].Value.ToString();

                            csvFileWriter.WriteLine(dataFromGrid);
                        }
                    }
                }


                csvFileWriter.Flush();
                csvFileWriter.Close();
            }
            catch (Exception exceptionObject)
            {
                MessageBox.Show(exceptionObject.ToString());
            }
        }
        void SaveDataGridViewToCSV(string filename)
        {
            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            // Select all the cells
            dataGridView1.SelectAll();
            // Copy selected cells to DataObject
            DataObject dataObject = dataGridView1.GetClipboardContent();
            // Get the text of the DataObject, and serialize it to a file
            File.WriteAllText(filename, dataObject.GetText(TextDataFormat.CommaSeparatedValue));
        }
    }
}
