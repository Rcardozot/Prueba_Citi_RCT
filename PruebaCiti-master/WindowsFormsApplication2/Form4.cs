using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;  
using System.Data.OleDb;
using System.IO;
using DAO = Microsoft.Office.Interop.Access.Dao;
using NuGet;
using Newtonsoft.Json;
using Microsoft.Office.Interop.Access.Dao;
using Newtonsoft.Json.Linq;
using System.Reflection;


namespace WindowsFormsApplication2
{
    public partial class Form4 : Form
    {
       
        public string filePath;
        public string name;
        public char Separador;
        public int D = 0;
        public int A = 0;
        public string[] array = new string[5];
        public string[] array2 = new string[5];
        public string ErrorNombre;
        public StreamWriter sw;
        public int Log2;
        public string Date;
        int Problem;
        public int f;
        public Form4(string Lab)
        {
            name = Lab;
            InitializeComponent();
        }
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        OleDbConnection con;
        OleDbCommand command;
        OleDbDataAdapter adapter;
        DataTable dt;

        //Leer archivo Excel
        private void importarDesdeExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos Excel(*.xls, *.xlsx)|*.xls;*.xlsx";
            openFileDialog1.FileName = "Excel";
            DialogResult res = openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;
            string extension = Path.GetExtension(filePath);
            string header = "YES";
            string conStr, sheetName;

            conStr = string.Empty;
            if (res == DialogResult.OK)
            {
                switch (extension)
                {

                    case ".xls": //Excel 97-03
                        conStr = string.Format(Excel03ConString, filePath, header);
                        break;

                    case ".xlsx": //Excel 07
                        conStr = string.Format(Excel07ConString, filePath, header);
                        break;
                }

                //Get the name of the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        con.Close();
                    }
                }

                //Read Data from the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        using (OleDbDataAdapter oda = new OleDbDataAdapter())
                        {
                            dt = new DataTable();
                            cmd.CommandText = "SELECT * From [" + sheetName + "]";
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();

                            //Populate DataGridView.
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }


        }

        //Cargar desde DataGridView1 a Access
        private void CargarClientes_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {

                validar();

                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dn12153\Documents\Access\ClientesM.accdb");

                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "true")
                    {
                        using (command = new OleDbCommand("SELECT COUNT(*) from Clientes where Nombres like @Nombres AND Apellidos like @Apellidos AND TipoID like @TipoID AND NoIdentificacion like @NoIdentificacion AND FechaNacimiento like @FechaNacimiento", con))
                        {
                            con.Open();
                            command.Parameters.AddWithValue("@Nombres", dataGridView1.Rows[i].Cells[0].Value);
                            command.Parameters.AddWithValue("@Apellidos", dataGridView1.Rows[i].Cells[1].Value);
                            command.Parameters.AddWithValue("@TipoID", dataGridView1.Rows[i].Cells[2].Value);
                            command.Parameters.AddWithValue("@NoIdentificacion", dataGridView1.Rows[i].Cells[3].Value);
                            command.Parameters.AddWithValue("@FechaNacimiento", dataGridView1.Rows[i].Cells[4].Value);
                            int userCount = (int)command.ExecuteScalar();
                            Log2 = i;
                            con.Close();
                            if (userCount > 0)
                            {
                                Date = DateTime.Now.ToString();
                                sw.Write("\r\n***********************************************************************************************************************************************************");
                                sw.Write("\r\n" + Date + "\t|| \t\t\t|| ");
                                f = i + 1;
                                sw.Write("\t" + f + "\t");
                                sw.Write("||\tEl registro ya existe en la base de datos");
                                Problem = 1;
                                                               
                            }
                            else
                            {
                                command = new OleDbCommand(@"INSERT INTO Clientes (Nombres, Apellidos, TipoID, NoIdentificacion, FechaNacimiento)  VALUES (@Nombres, @Apellidos, @TipoID, @NoIdentificacion, @FechaNacimiento)", con);
                                command.Parameters.AddWithValue("@Nombres", dataGridView1.Rows[i].Cells[0].Value);
                                command.Parameters.AddWithValue("@Apellidos", dataGridView1.Rows[i].Cells[1].Value);
                                command.Parameters.AddWithValue("@TipoID", dataGridView1.Rows[i].Cells[2].Value);
                                command.Parameters.AddWithValue("@NoIdentificacion", dataGridView1.Rows[i].Cells[3].Value);
                                command.Parameters.AddWithValue("@FechaNacimiento", dataGridView1.Rows[i].Cells[4].Value);
                                con.Open();
                                command.ExecuteNonQuery();
                                con.Close();          
                            }
                        }
                       
                                                  
                                               
                                               
                    }
                    

                }
                if (Problem != 1)
                {
                    sw.Write("\r\n***********************************************************************************************************************************************************");
                    sw.Write("\r\nSin Errores");
                }
                sw.Close();
                if (Problem == 1)
                {
                    MessageBox.Show("No se han cargado algunos registros, se genero un archivo Log, por favor selecciona donde guardarlo.");

                    string path = @"C:\Users\Public\Documents\ProgLog\Log.txt";
                    saveFileDialog1.Filter = "Archivo de Texto(*.txt)|*.txt";
                    saveFileDialog1.FileName = "Log.txt";
                    DialogResult res = saveFileDialog1.ShowDialog();
                    string path2 = saveFileDialog1.FileName;
                    if (res == DialogResult.OK)
                    {
                        if (File.Exists(path2))
                        {
                            File.Delete(path2);
                            File.Move(path, path2);
                        }
                        else
                        {
                            File.Move(path, path2);
                        }
                    }
                }
                                
                MessageBox.Show("Terminado");
                
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
            }
        }

        //Boton Volver
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 ss = new Form2(name);
            ss.Show();
        }

        //Validacion de campos DataGridView1
        public void validar()
        {
            

            Problem = 0;
            sw = new StreamWriter("C:\\Users\\Public\\Documents\\ProgLog\\Log.txt");
            sw.WriteLine("Archivo Log ");
            sw.WriteLine("***********************************************************************************************************************************************************");
            sw.Write("\tFecha\t\t||\tColumna\t\t||   Registro   ||\t Mensaje");
            sw.Write("\r\n***********************************************************************************************************************************************************");



            dataGridView1.Columns.Add("Valido", "Valido");
            dataGridView1.Columns[5].Visible = false;

            
            

            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                    
                
                string Nombre = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string Apellido = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string TipoID = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string NumID = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string FechaNaci = dataGridView1.Rows[i].Cells[4].Value.ToString();

                


                int Er = 0;
                A = 0;
                D = 0;
                //Validacion campo nombre                
                if (Nombre != "" && Nombre.Length > 2)
                {

                    num1 = 1;

                }
                else
                {
                    array[D] = "Nombre esta vacio o es menor a 3 caracteres; ";
                    D = D + 1;
                    array2[A] = "Nombre\t\t";
                    A = A + 1;
                    Er = 1;

                }

                //validacion campo Apellido
                if (Apellido != "" && Apellido.Length > 2)
                {
                    num2 = 1;
                }
                else
                {
                    array[D] = "Apellido esta vacio o es menor a 3 caracteres; ";
                    D = D + 1;
                    array2[A] = "Apellido\t\t";
                    A = A + 1;
                    Er = 1;
                }

                //validacion campo TipoID
                if (TipoID == "C.C" || TipoID == "T.I" || TipoID == "C.E")
                {
                    num3 = 1;
                }
                else
                {
                    array[D] = "TipoID no coincide con ninguna de las opciones preestablecidas; ";
                    D = D + 1;
                    array2[A] = "TipoID\t\t";
                    A = A + 1;
                    Er = 1;
                }

                //Validacion campo NoIdentificacion dependiendo de TipoID
                if (TipoID == "C.C")
                {
                    long number;
                    if (long.TryParse(NumID, out number))
                    {
                        num4 = 1;
                    }
                    else
                    {
                        array[D] = "Identificacion invalida o no concuerda con el TipoID; ";
                        D = D + 1;
                        array2[A] = "NoIdentificacion\t";
                        A = A + 1;
                        Er = 1;
                    }

                }
                else if (TipoID == "T.I")
                {
                    long number;
                    if (long.TryParse(NumID, out number))
                    {
                        num4 = 1;
                    }
                    else
                    {
                        array[D] = "Identificacion invalida o no concuerda con el TipoID; ";
                        D = D + 1;
                        array2[A] = "NoIdentificacion\t";
                        A = A + 1;
                        Er = 1;
                    }
                }
                else if (TipoID == "C.E")
                {
                    long number;
                    if (long.TryParse(NumID, out number))
                    {
                        array[D] = "Identificacion invalida o no concuerda con el TipoID; ";
                        D = D + 1;
                        array2[A] = "NoIdentificacion\t";
                        A = A + 1;
                        Er = 1;

                    }
                    else
                    {
                        num4 = 1;
                    }
                }
                else
                {
                    array[D] = "Identificacion invalida o no concuerda con el TipoID; ";
                    D = D + 1;
                    array2[A] = "NoIdentificacion\t";
                    A = A + 1;
                    Er = 1;
                }


                //Validacion campo Fecha
                DateTime fecha;

                if (DateTime.TryParse(FechaNaci, out fecha))
                {
                    num5 = 1;

                    //Validacion si es mayor de edad
                    DateTime fechaIng = fecha;
                    DateTime fechaHoy = DateTime.Now;
                    TimeSpan ts = fechaHoy - fechaIng;

                    int Ano = ts.Days;
                    if (Ano >= 6575)
                    {
                        num6 = 1;
                    }
                    else
                    {
                        array[D] = "Fecha Invalida o la persona no es mayor de edad; ";
                        D = D + 1;
                        array2[A] = "FechaNacimiento\t";
                        A = A + 1;
                        Er = 1;
                    }

                }
                else
                {

                    array[D] = "Fecha Invalida o la persona no es mayor de edad; ";
                    D = D + 1;
                    array2[A] = "FechaNacimiento\t";
                    A = A + 1;
                    Er = 1;
                }


                if (num1 == 1 && num2 == 1 && num3 == 1 && num4 == 1 && num5 == 1 && num6 == 1 /*&& num7 == 1*/)
                {
                    dataGridView1.Rows[i].Cells[5].Value = "true";
                }
                else
                {
                    dataGridView1.Rows[i].Cells[5].Value = "false";
                }

                if (Er == 1)
                {

                    int U = 0;
                    for (int Q = 0; Q < D; Q++)
                    {

                        Date = DateTime.Now.ToString();
                        sw.Write("\r\n***********************************************************************************************************************************************************");
                        //Escribir Fecha
                        sw.Write("\r\n" + Date + "\t");
                        sw.Write("||");
                        //Escribir Columna
                        sw.Write(array2[U]);

                        sw.Write("||");
                        f = i + 1;
                        //Escribir numero de Registro
                        sw.Write("\t" + f + "\t");
                        sw.Write("||\t");
                        Problem = 1;
                        //Escribir Descripcion detallada de error 
                        sw.Write(array[U]);
                        //Para el ciclo:                            
                        U = U + 1;

                    }

                }

            }        
            
       
                                
        }

        private void Form4_Load(object sender, System.EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dn12153\Documents\Access\ClientesM.accdb");
        }

        //Llenar DataTable con excel
        public class Helper
        {
            public static DataTable DataTableFromTextFile(string location, char delimiter = ',')
            {
                DataTable result;

                string[] LineArray = File.ReadAllLines(location);

                result = FormDataTable(LineArray, delimiter);

                return result;
            }

            private static DataTable FormDataTable(string[] LineArray, char delimiter)
            {
                DataTable dt = new DataTable();

                AddColumnToTable(LineArray, delimiter, ref dt);

                AddRowToTable(LineArray, delimiter, ref dt);

                return dt;
            }

            private static void AddRowToTable(string[] valueCollection, char delimiter, ref DataTable dt)
            {

                for (int i = 1; i < valueCollection.Length; i++)
                {
                    string[] values = valueCollection[i].Split(delimiter);
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < values.Length; j++)
                    {
                        dr[j] = values[j];
                    }
                    dt.Rows.Add(dr);
                }
            }

            private static void AddColumnToTable(string[] columnCollection, char delimiter, ref DataTable dt)
            {
                string[] columns = columnCollection[0].Split(delimiter);
                foreach (string columnName in columns)
                {
                    DataColumn dc = new DataColumn(columnName, typeof(string));
                    dt.Columns.Add(dc);
                }
            }



        }
        //Seleccion de Separador para txt/csv
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Separador = '|';
            Importar();
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Separador = ',';
            Importar();
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Separador = ';';
            Importar();
        }

        //Importar txt/csv segun separador
        private void Importar()
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Abrir Archivo";
            fdlg.FileName = "Txt/CSV";
            
            fdlg.Filter = "Text and CSV Files(*.txt, *.csv)|*.txt;*.csv|Text Files(*.txt)|*.txt|CSV Files(*.csv)|*.csv|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            DialogResult res = fdlg.ShowDialog();
            String filePath = fdlg.FileName;
            if (res == DialogResult.OK)
            {
                dataGridView1.DataSource = Helper.DataTableFromTextFile(filePath, Separador);
                Application.DoEvents();
            }
        }

        //Importar Xml
        private void importarDesdeXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos XML(*.xml)|*.xml";
            openFileDialog1.FileName = "xml";
            DialogResult res = openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;
            if (res == DialogResult.OK)
            {
                dataSet1.ReadXml(filePath);
                dataGridView1.DataSource = dataSet1;
                dataGridView1.DataMember = "Cliente";
            }


        }

        public void importarDesdeJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos Json(*.json)|*.json";
            openFileDialog1.FileName = "json";
            DialogResult res = openFileDialog1.ShowDialog();
            filePath = openFileDialog1.FileName;
            
            if (res == DialogResult.OK)
            {
                
                //TestClass.Test();
                string fileJSON = File.ReadAllText(filePath);
                var result = JsonConvert.DeserializeObject<List<Cliente>>(fileJSON);
                dataGridView1.DataSource = result;
                //string MK = result.Cliente;
                               
                //DataTable dt = result.Cliente.ToDataTable();
            }
            

        }
        
       
        public class Cliente
        {
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string TipoID { get; set; }
            public string NoIdentificacion { get; set; }
            public string FechaNacimiento { get; set; }
        }
              

    }

}
