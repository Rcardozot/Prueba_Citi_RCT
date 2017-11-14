using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public string name;
        public Form2(string Usuario)
        {
            name = Usuario;
            InitializeComponent();
        }
        Form3 fr;
        Form4 F4;
        ExportForm ExpForm;
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fr = new Form1();
            fr.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
        
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //fr = new Form3(name);
            /*if (fr == null)
            {*/
            if (fr != null)
            {
                fr.Close();
            }
            
                fr = new Form3(name);
                fr.MdiParent = this;
                fr.Dock = DockStyle.Fill;
                this.Size = new Size(690, 620);
                this.CenterToScreen();
                label1.Hide();
            //Form2.
                fr.FormClosed += new FormClosedEventHandler(fr_FormClosed);
                fr.Show();
                
           /* }
            else
            {
                fr.Activate();
                
            }*/
        }
        private void fr_FormClosed(object sender, FormClosedEventArgs e)
        {
            fr = null;
            //throw new NotImplementedException();
        }

       

       private void Form2_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            String Session = "Usuario: " + name;
            label1.Text = Session;

            
        }

               

        private void CargarClientes_Click(object sender, EventArgs e)
        {
            //this.Close();
            //Form4 F4 = new Form4(name);
            //F4.Show();
            if (F4 != null)
            {
                F4.Close();
            }
            F4 = new Form4(name);
            F4.MdiParent = this;
            F4.Dock = DockStyle.Fill;
            this.Size = new Size(670, 490);
            this.CenterToScreen();
            label1.Hide();
            F4.FormClosed += new FormClosedEventHandler(F4_FormClosed);
            F4.Show();
        }
        private void F4_FormClosed(object sender, FormClosedEventArgs e)
        {
            F4 = null;
            //throw new NotImplementedException();
        }

        private void exportarCLientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //ExportForm ExpForm = new ExportForm();
            //ExpForm.Show();
            if (ExpForm != null)
            {
                ExpForm.Close();
            }
            ExpForm = new ExportForm(name);
            ExpForm.MdiParent = this;
            ExpForm.Dock = DockStyle.Fill;
            this.Size = new Size(643, 450);
            this.CenterToScreen();
            label1.Hide();
            ExpForm.FormClosed += new FormClosedEventHandler(ExpForm_FormClosed);
            ExpForm.Show();
        }
        private void ExpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExpForm = null;
            //throw new NotImplementedException();
        }
    }
}
