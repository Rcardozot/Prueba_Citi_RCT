using System.Data.OleDb;
namespace WindowsFormsApplication2
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataSet1 = new System.Data.DataSet();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importarDesdeExcelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importarDesdeTxtCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccioneSeparadorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.importarDesdeXMLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importarDesdeJSONToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(618, 318);
            this.dataGridView1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(642, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Cargar";
            this.toolStripLabel1.Click += new System.EventHandler(this.CargarClientes_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarDesdeExcelToolStripMenuItem1,
            this.importarDesdeTxtCsvToolStripMenuItem,
            this.importarDesdeXMLToolStripMenuItem1,
            this.importarDesdeJSONToolStripMenuItem1});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(66, 22);
            this.toolStripDropDownButton1.Text = "Importar";
            // 
            // importarDesdeExcelToolStripMenuItem1
            // 
            this.importarDesdeExcelToolStripMenuItem1.Name = "importarDesdeExcelToolStripMenuItem1";
            this.importarDesdeExcelToolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.importarDesdeExcelToolStripMenuItem1.Text = "Importar desde Excel";
            this.importarDesdeExcelToolStripMenuItem1.Click += new System.EventHandler(this.importarDesdeExcelToolStripMenuItem_Click);
            // 
            // importarDesdeTxtCsvToolStripMenuItem
            // 
            this.importarDesdeTxtCsvToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccioneSeparadorToolStripMenuItem1,
            this.toolStripSeparator2,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7});
            this.importarDesdeTxtCsvToolStripMenuItem.Name = "importarDesdeTxtCsvToolStripMenuItem";
            this.importarDesdeTxtCsvToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.importarDesdeTxtCsvToolStripMenuItem.Text = "Importar desde Txt / Csv";
            // 
            // seleccioneSeparadorToolStripMenuItem1
            // 
            this.seleccioneSeparadorToolStripMenuItem1.Enabled = false;
            this.seleccioneSeparadorToolStripMenuItem1.Name = "seleccioneSeparadorToolStripMenuItem1";
            this.seleccioneSeparadorToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.seleccioneSeparadorToolStripMenuItem1.Text = "Seleccione Separador";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem5.Text = "\" | \"";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem6.Text = "\" , \"";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem7.Text = "\" ; \"";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // importarDesdeXMLToolStripMenuItem1
            // 
            this.importarDesdeXMLToolStripMenuItem1.Name = "importarDesdeXMLToolStripMenuItem1";
            this.importarDesdeXMLToolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.importarDesdeXMLToolStripMenuItem1.Text = "Importar desde XML";
            this.importarDesdeXMLToolStripMenuItem1.Click += new System.EventHandler(this.importarDesdeXMLToolStripMenuItem_Click);
            // 
            // importarDesdeJSONToolStripMenuItem1
            // 
            this.importarDesdeJSONToolStripMenuItem1.Name = "importarDesdeJSONToolStripMenuItem1";
            this.importarDesdeJSONToolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.importarDesdeJSONToolStripMenuItem1.Text = "Importar desde JSON";
            this.importarDesdeJSONToolStripMenuItem1.Click += new System.EventHandler(this.importarDesdeJSONToolStripMenuItem_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 419);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.Text = "Importar";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem importarDesdeExcelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importarDesdeTxtCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccioneSeparadorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem importarDesdeXMLToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importarDesdeJSONToolStripMenuItem1;
    }
}