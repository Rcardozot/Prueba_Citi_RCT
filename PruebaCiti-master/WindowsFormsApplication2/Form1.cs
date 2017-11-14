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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ultraLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ultraLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void ultraTextEditor1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Contr_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dn12153\Documents\Access\UsuariosM.accdb;");
            OleDbDataAdapter DataAdapt = new OleDbDataAdapter("Select Count(*) From Login where UserName='" + User.Text + "'and Contrase ='" + Contra.Text + "'", con);
            DataTable Dt = new DataTable();
            DataAdapt.Fill(Dt);
            if (Dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form2 ss = new Form2(User.Text+"\nInformacion de Sesion:\n"+DateTime.Now.ToString());
                ss.Show();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();
        }
    }
}
