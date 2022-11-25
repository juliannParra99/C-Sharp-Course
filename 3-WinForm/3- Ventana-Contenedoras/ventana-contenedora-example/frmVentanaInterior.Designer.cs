
namespace ventana_contenedora_example
{
    partial class frmVentanaInterior
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDevuelve = new System.Windows.Forms.Label();
            this.lvlNombreDevuelto = new System.Windows.Forms.Label();
            this.btnNombre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(73, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(234, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Te dire tu nombre:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(12, 95);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(121, 16);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Ingresa tu nombre: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(139, 91);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(158, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lblDevuelve
            // 
            this.lblDevuelve.AutoSize = true;
            this.lblDevuelve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevuelve.Location = new System.Drawing.Point(32, 173);
            this.lblDevuelve.Name = "lblDevuelve";
            this.lblDevuelve.Size = new System.Drawing.Size(97, 16);
            this.lblDevuelve.TabIndex = 3;
            this.lblDevuelve.Text = "Tu nombre es: ";
            // 
            // lvlNombreDevuelto
            // 
            this.lvlNombreDevuelto.AutoSize = true;
            this.lvlNombreDevuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlNombreDevuelto.Location = new System.Drawing.Point(155, 175);
            this.lvlNombreDevuelto.Name = "lvlNombreDevuelto";
            this.lvlNombreDevuelto.Size = new System.Drawing.Size(0, 16);
            this.lvlNombreDevuelto.TabIndex = 4;
            // 
            // btnNombre
            // 
            this.btnNombre.Location = new System.Drawing.Point(44, 133);
            this.btnNombre.Name = "btnNombre";
            this.btnNombre.Size = new System.Drawing.Size(111, 27);
            this.btnNombre.TabIndex = 5;
            this.btnNombre.Text = "Enviar";
            this.btnNombre.UseVisualStyleBackColor = true;
            this.btnNombre.Click += new System.EventHandler(this.btnNombre_Click);
            // 
            // frmVentanaInterior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 407);
            this.Controls.Add(this.btnNombre);
            this.Controls.Add(this.lvlNombreDevuelto);
            this.Controls.Add(this.lblDevuelve);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitle);
            this.MaximumSize = new System.Drawing.Size(473, 446);
            this.MinimumSize = new System.Drawing.Size(386, 405);
            this.Name = "frmVentanaInterior";
            this.Text = "I tell you your name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDevuelve;
        private System.Windows.Forms.Label lvlNombreDevuelto;
        private System.Windows.Forms.Button btnNombre;
    }
}