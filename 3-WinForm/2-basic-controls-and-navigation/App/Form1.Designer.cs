
namespace App
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lvElementos = new System.Windows.Forms.ListView();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.ckbComida = new System.Windows.Forms.CheckBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.rbtWizard = new System.Windows.Forms.RadioButton();
            this.rbtSquibs = new System.Windows.Forms.RadioButton();
            this.rbtMuggle = new System.Windows.Forms.RadioButton();
            this.gbTipo = new System.Windows.Forms.GroupBox();
            this.cboColorFavorito = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.numNumeroFavorito = new System.Windows.Forms.NumericUpDown();
            this.lblNumeroFavorito = new System.Windows.Forms.Label();
            this.btnVerPerfil = new System.Windows.Forms.Button();
            this.gbTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroFavorito)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(187, 415);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(129, 46);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lvElementos
            // 
            this.lvElementos.HideSelection = false;
            this.lvElementos.Location = new System.Drawing.Point(61, 341);
            this.lvElementos.Name = "lvElementos";
            this.lvElementos.Size = new System.Drawing.Size(121, 97);
            this.lvElementos.TabIndex = 2;
            this.lvElementos.UseCompatibleStateImageBehavior = false;
            this.lvElementos.View = System.Windows.Forms.View.List;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(74, 53);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 95);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(109, 13);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha de nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(140, 95);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaNacimiento.TabIndex = 5;
            // 
            // ckbComida
            // 
            this.ckbComida.AutoSize = true;
            this.ckbComida.Location = new System.Drawing.Point(140, 131);
            this.ckbComida.Name = "ckbComida";
            this.ckbComida.Size = new System.Drawing.Size(122, 17);
            this.ckbComida.TabIndex = 6;
            this.ckbComida.Text = "Te gusta la comida?";
            this.ckbComida.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(41, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(91, 31);
            this.lblTitulo.TabIndex = 7;
            this.lblTitulo.Text = "Perfil: ";
            // 
            // rbtWizard
            // 
            this.rbtWizard.AutoSize = true;
            this.rbtWizard.Checked = true;
            this.rbtWizard.Location = new System.Drawing.Point(31, 19);
            this.rbtWizard.Name = "rbtWizard";
            this.rbtWizard.Size = new System.Drawing.Size(58, 17);
            this.rbtWizard.TabIndex = 8;
            this.rbtWizard.TabStop = true;
            this.rbtWizard.Text = "Wizard";
            this.rbtWizard.UseVisualStyleBackColor = true;
            // 
            // rbtSquibs
            // 
            this.rbtSquibs.AutoSize = true;
            this.rbtSquibs.Location = new System.Drawing.Point(271, 19);
            this.rbtSquibs.Name = "rbtSquibs";
            this.rbtSquibs.Size = new System.Drawing.Size(57, 17);
            this.rbtSquibs.TabIndex = 10;
            this.rbtSquibs.Text = "Squibs";
            this.rbtSquibs.UseVisualStyleBackColor = true;
            // 
            // rbtMuggle
            // 
            this.rbtMuggle.AutoSize = true;
            this.rbtMuggle.Location = new System.Drawing.Point(146, 19);
            this.rbtMuggle.Name = "rbtMuggle";
            this.rbtMuggle.Size = new System.Drawing.Size(60, 17);
            this.rbtMuggle.TabIndex = 11;
            this.rbtMuggle.Text = "Muggle";
            this.rbtMuggle.UseVisualStyleBackColor = true;
            // 
            // gbTipo
            // 
            this.gbTipo.Controls.Add(this.rbtWizard);
            this.gbTipo.Controls.Add(this.rbtMuggle);
            this.gbTipo.Controls.Add(this.rbtSquibs);
            this.gbTipo.Location = new System.Drawing.Point(91, 163);
            this.gbTipo.Name = "gbTipo";
            this.gbTipo.Size = new System.Drawing.Size(356, 51);
            this.gbTipo.TabIndex = 12;
            this.gbTipo.TabStop = false;
            this.gbTipo.Text = "Tipo:";
            // 
            // cboColorFavorito
            // 
            this.cboColorFavorito.FormattingEnabled = true;
            this.cboColorFavorito.Location = new System.Drawing.Point(162, 220);
            this.cboColorFavorito.Name = "cboColorFavorito";
            this.cboColorFavorito.Size = new System.Drawing.Size(154, 21);
            this.cboColorFavorito.TabIndex = 13;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(83, 228);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(72, 13);
            this.lblColor.TabIndex = 14;
            this.lblColor.Text = "Color favorito:";
            // 
            // numNumeroFavorito
            // 
            this.numNumeroFavorito.Location = new System.Drawing.Point(173, 272);
            this.numNumeroFavorito.Name = "numNumeroFavorito";
            this.numNumeroFavorito.Size = new System.Drawing.Size(120, 20);
            this.numNumeroFavorito.TabIndex = 15;
            // 
            // lblNumeroFavorito
            // 
            this.lblNumeroFavorito.AutoSize = true;
            this.lblNumeroFavorito.Location = new System.Drawing.Point(82, 279);
            this.lblNumeroFavorito.Name = "lblNumeroFavorito";
            this.lblNumeroFavorito.Size = new System.Drawing.Size(85, 13);
            this.lblNumeroFavorito.TabIndex = 16;
            this.lblNumeroFavorito.Text = "Numero favorito:";
            // 
            // btnVerPerfil
            // 
            this.btnVerPerfil.Location = new System.Drawing.Point(321, 279);
            this.btnVerPerfil.Name = "btnVerPerfil";
            this.btnVerPerfil.Size = new System.Drawing.Size(126, 23);
            this.btnVerPerfil.TabIndex = 17;
            this.btnVerPerfil.Text = "Ver perfil:";
            this.btnVerPerfil.UseVisualStyleBackColor = true;
            this.btnVerPerfil.Click += new System.EventHandler(this.btnVerPerfil_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVerPerfil);
            this.Controls.Add(this.lblNumeroFavorito);
            this.Controls.Add(this.numNumeroFavorito);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.cboColorFavorito);
            this.Controls.Add(this.gbTipo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.ckbComida);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lvElementos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnAgregar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbTipo.ResumeLayout(false);
            this.gbTipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroFavorito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ListView lvElementos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.CheckBox ckbComida;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.RadioButton rbtWizard;
        private System.Windows.Forms.RadioButton rbtSquibs;
        private System.Windows.Forms.RadioButton rbtMuggle;
        private System.Windows.Forms.GroupBox gbTipo;
        private System.Windows.Forms.ComboBox cboColorFavorito;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.NumericUpDown numNumeroFavorito;
        private System.Windows.Forms.Label lblNumeroFavorito;
        private System.Windows.Forms.Button btnVerPerfil;
    }
}

