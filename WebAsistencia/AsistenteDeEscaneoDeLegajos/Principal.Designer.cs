namespace AsistenteDeEscaneoDeLegajos
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSubirImagenes = new System.Windows.Forms.Button();
            this.txtIdInterna = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSubirImagenes
            // 
            this.btnSubirImagenes.Location = new System.Drawing.Point(197, 9);
            this.btnSubirImagenes.Name = "btnSubirImagenes";
            this.btnSubirImagenes.Size = new System.Drawing.Size(75, 38);
            this.btnSubirImagenes.TabIndex = 0;
            this.btnSubirImagenes.Text = "Subir!";
            this.btnSubirImagenes.UseVisualStyleBackColor = true;
            this.btnSubirImagenes.Click += new System.EventHandler(this.btnSubirImagenes_Click);
            // 
            // txtIdInterna
            // 
            this.txtIdInterna.Location = new System.Drawing.Point(12, 27);
            this.txtIdInterna.Name = "txtIdInterna";
            this.txtIdInterna.Size = new System.Drawing.Size(179, 20);
            this.txtIdInterna.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id Interna";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 59);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdInterna);
            this.Controls.Add(this.btnSubirImagenes);
            this.Name = "Principal";
            this.Text = "Asistente de Escaneo de Legajos";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubirImagenes;
        private System.Windows.Forms.TextBox txtIdInterna;
        private System.Windows.Forms.Label label1;
    }
}

