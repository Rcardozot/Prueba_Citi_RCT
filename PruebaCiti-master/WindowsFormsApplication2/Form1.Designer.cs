namespace WindowsFormsApplication2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.User = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.IniciarSesion = new Infragistics.Win.Misc.UltraLabel();
            this.Usuario = new Infragistics.Win.Misc.UltraLabel();
            this.Contraseña = new Infragistics.Win.Misc.UltraLabel();
            this.Contra = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.BtnIniciar = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contra)).BeginInit();
            this.SuspendLayout();
            // 
            // User
            // 
            this.User.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.User.Location = new System.Drawing.Point(69, 76);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(145, 21);
            this.User.TabIndex = 0;
            this.User.ValueChanged += new System.EventHandler(this.Contr_ValueChanged);
            // 
            // IniciarSesion
            // 
            this.IniciarSesion.Location = new System.Drawing.Point(13, 13);
            this.IniciarSesion.Name = "IniciarSesion";
            this.IniciarSesion.TabIndex = 1;
            this.IniciarSesion.Text = "Iniciar Sesión";
            this.IniciarSesion.Click += new System.EventHandler(this.ultraLabel1_Click);
            // 
            // Usuario
            // 
            this.Usuario.Location = new System.Drawing.Point(69, 55);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(93, 15);
            this.Usuario.TabIndex = 2;
            this.Usuario.Text = "Usuario";
            this.Usuario.Click += new System.EventHandler(this.ultraLabel1_Click_1);
            // 
            // Contraseña
            // 
            this.Contraseña.Location = new System.Drawing.Point(69, 103);
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.Size = new System.Drawing.Size(93, 15);
            this.Contraseña.TabIndex = 3;
            this.Contraseña.Text = "Contraseña";
            // 
            // Contra
            // 
            this.Contra.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.Contra.Location = new System.Drawing.Point(69, 126);
            this.Contra.Name = "Contra";
            this.Contra.PasswordChar = '*';
            this.Contra.Size = new System.Drawing.Size(145, 21);
            this.Contra.TabIndex = 4;
            this.Contra.ValueChanged += new System.EventHandler(this.ultraTextEditor1_ValueChanged);
            // 
            // BtnIniciar
            // 
            this.BtnIniciar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Windows8Button;
            this.BtnIniciar.Location = new System.Drawing.Point(105, 153);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.TabIndex = 5;
            this.BtnIniciar.Text = "Iniciar";
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.BtnIniciar);
            this.Controls.Add(this.Contra);
            this.Controls.Add(this.Contraseña);
            this.Controls.Add(this.Usuario);
            this.Controls.Add(this.IniciarSesion);
            this.Controls.Add(this.User);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Iniciar Sesion";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel IniciarSesion;
        private Infragistics.Win.Misc.UltraLabel Usuario;
        private Infragistics.Win.Misc.UltraLabel Contraseña;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor Contra;
        private Infragistics.Win.Misc.UltraButton BtnIniciar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor User;
    }
}

