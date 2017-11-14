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
using System.Drawing.Imaging;

namespace WindowsFormsApplication2
{    
    public partial class Form3 : Form
    {

        public string Ather;
        int ID = 0;
        public Form3(string makio)
        {
            Ather = makio;
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataSet ds;
        int rno = 0;
        MemoryStream ms;
        byte[] photo_aray;



        //Cambiar propiedades del campo numero de identificacion segun seleccion del comboBox

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.KeyPress -= TXTB_ONLY_NUMBER_KeyPress;
            textBox3.KeyPress -= TXTB_CHAR_AND_NUMBER_KeyPress;
            if (comboBox1.Text == "C.C")
            {
                textBox3.KeyPress += TXTB_ONLY_NUMBER_KeyPress;
            }
            else if (comboBox1.Text == "TI")
            {
                textBox3.KeyPress += TXTB_ONLY_NUMBER_KeyPress;
            }
            else if (comboBox1.Text == "C.E")
            {
                textBox3.KeyPress += TXTB_CHAR_AND_NUMBER_KeyPress;
            }
        }
        private void TXTB_ONLY_CHAR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TXTB_ONLY_NUMBER_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TXTB_CHAR_AND_NUMBER_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allow digit + char + white space
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        
        //Boton Volver
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fr = new Form2(Ather);
            fr.Show();
        }



        //Boton Guardar
        private void button1_Click(object sender, EventArgs e)
        {
            String Cmand;
            if (pictureBox1.Image != null)
            {
                Cmand = @"INSERT INTO Clientes (Nombres, Apellidos, TipoID, NoIdentificacion, FechaNacimiento, Imagen) VALUES (@Nombres, @Apellidos, @TipoID, @NoIdentificacion, @FechaNacimiento, @Imagen)";
            }
            else
            {
                Cmand = @"INSERT INTO Clientes (Nombres, Apellidos, TipoID, NoIdentificacion, FechaNacimiento) VALUES (@Nombres, @Apellidos, @TipoID, @NoIdentificacion, @FechaNacimiento)";
            }
            cmd = new OleDbCommand(Cmand, con);
            //int MAster=Convert.ToInt32(textBox3.Text);
            cmd.Parameters.AddWithValue("@Nombres", TxbNombre.Text);
            cmd.Parameters.AddWithValue("@Apellidos", TxbApellido.Text);
            cmd.Parameters.AddWithValue("@TipoID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@NoIdentificacion", textBox3.Text);
            cmd.Parameters.AddWithValue("@FechaNacimiento", dateTimePicker1.Text);
            
            conv_photo();//Convertir foto a arreglo de bytes
            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();
              
            if (n > 0)
            {
                MessageBox.Show("Datos Agregados");                
                ClearData();
                rno++;
            }
            else
            {
                MessageBox.Show("Ocurrio un problema");
            }
                
            DisplayData();
        }
        
        //Convertir foto a arreglo de bytes
        void conv_photo()
        {
            //converting photo to binary data
            if (pictureBox1.Image != null)
            {
                //using MemoryStream:
                ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                cmd.Parameters.AddWithValue("@Imagen", photo_aray);
            }
        }

        //Limpiar campos
        private void ClearData()
        {
            TxbNombre.Text = "";
            TxbApellido.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            pictureBox1.Image = null;
            
        }

        //Llenar DataGridview1
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapter = new OleDbDataAdapter("select ID, Nombres, Apellidos, TipoID, NoIdentificacion, FechaNacimiento from Clientes", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        //Seleccionar un registro en DataGridView1
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) 
        {
            pictureBox1.Image = null;
            string Date = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxbNombre.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxbApellido.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(Date);

                        
                cmd = new OleDbCommand("select Imagen from Clientes where ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int R = ds.Tables[0].Columns.Count;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Imagen"].ToString() != "")
                    {
                        MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Imagen"]);
                        pictureBox1.Image = new Bitmap(ms);
                    }

                }      
                   
        } 
        
        

        private void Form3_Load(object sender, EventArgs e)
        {
            
            String Session = "Usuario: " + Ather;
            label6.Text = Session;
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dn12153\Documents\Access\ClientesM.accdb");
            DisplayData();
            
        }
       
        //Cargar imagen al pictureBox
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        //Boton Actualizar
        private void Update_Click(object sender, EventArgs e)
        {
            if (TxbNombre.Text != "" && TxbApellido.Text != "" && textBox3.Text !="")
            {
                /*int MAster = Convert.ToInt32(textBox3.Text);*/
                String Cmand;
                if (pictureBox1.Image != null)
                {
                    Cmand = "update Clientes set Nombres='" + TxbNombre.Text + "', Apellidos='" + TxbApellido.Text + "', TipoID='" + comboBox1.Text + "', NoIdentificacion='" + textBox3.Text + "', FechaNacimiento='" + dateTimePicker1.Text + "', Imagen=@Imagen  where ID=" + ID;
                }
                else
                {
                    Cmand = "update Clientes set Nombres='" + TxbNombre.Text + "', Apellidos='" + TxbApellido.Text + "', TipoID='" + comboBox1.Text + "', NoIdentificacion='" + textBox3.Text + "', FechaNacimiento='" + dateTimePicker1.Text + "' where ID=" + ID;
                }
                
                cmd = new OleDbCommand(Cmand, con);
                con.Open();
                conv_photo();                             
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos Actualizados");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un cliente");
            }
        }

        //Boton Borrar
        private void Borrar_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new OleDbCommand("delete from Clientes where ID=@ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registro Eliminado");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un registro");
            }  
        }

        //Validar si es mayor de edad al modificar valor en dataTimePicker
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaIng = dateTimePicker1.Value;
            DateTime fechaHoy = DateTime.Now;

            TimeSpan ts = fechaHoy - fechaIng;

            int Ano = ts.Days;
            if (Ano >= 6575)
            {

            }
            else
            {
                MessageBox.Show("La parsona no es mayor de edad, por favor verifique la informacion");
            }
        }
       
        }
    }
