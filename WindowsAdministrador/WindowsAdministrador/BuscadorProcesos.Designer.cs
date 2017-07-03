namespace WindowsAdministrador
{
    partial class BuscadorProcesos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscadorProcesos));
            this.gpContenedor2 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.txtInicia = new System.Windows.Forms.TextBox();
            this.btnbusc = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gpContenedor2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpContenedor2
            // 
            this.gpContenedor2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.gpContenedor2.Controls.Add(this.btnCancelar);
            this.gpContenedor2.Controls.Add(this.btnLimpiar);
            this.gpContenedor2.Controls.Add(this.btnInicio);
            this.gpContenedor2.Controls.Add(this.txtInicia);
            this.gpContenedor2.Controls.Add(this.btnbusc);
            this.gpContenedor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.gpContenedor2.ForeColor = System.Drawing.Color.Black;
            this.gpContenedor2.Location = new System.Drawing.Point(4, 37);
            this.gpContenedor2.Name = "gpContenedor2";
            this.gpContenedor2.Size = new System.Drawing.Size(563, 108);
            this.gpContenedor2.TabIndex = 26;
            this.gpContenedor2.TabStop = false;
            this.gpContenedor2.Text = "Inicializador de procesos";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLimpiar.Location = new System.Drawing.Point(155, 47);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(85, 31);
            this.btnLimpiar.TabIndex = 20;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.Transparent;
            this.btnInicio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInicio.BackgroundImage")));
            this.btnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnInicio.Location = new System.Drawing.Point(295, 47);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(85, 31);
            this.btnInicio.TabIndex = 18;
            this.btnInicio.Text = "Iniciar";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // txtInicia
            // 
            this.txtInicia.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicia.Location = new System.Drawing.Point(85, 23);
            this.txtInicia.Name = "txtInicia";
            this.txtInicia.ReadOnly = true;
            this.txtInicia.Size = new System.Drawing.Size(380, 18);
            this.txtInicia.TabIndex = 17;
            // 
            // btnbusc
            // 
            this.btnbusc.BackColor = System.Drawing.Color.Transparent;
            this.btnbusc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnbusc.BackgroundImage")));
            this.btnbusc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnbusc.FlatAppearance.BorderSize = 0;
            this.btnbusc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbusc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbusc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnbusc.Location = new System.Drawing.Point(27, 47);
            this.btnbusc.Name = "btnbusc";
            this.btnbusc.Size = new System.Drawing.Size(85, 31);
            this.btnbusc.TabIndex = 19;
            this.btnbusc.Text = "Buscar";
            this.btnbusc.UseVisualStyleBackColor = false;
            this.btnbusc.Click += new System.EventHandler(this.btnbusc_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.Location = new System.Drawing.Point(426, 47);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 31);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BuscadorProcesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsAdministrador.Properties.Resources.screenshot542;
            this.ClientSize = new System.Drawing.Size(579, 157);
            this.Controls.Add(this.gpContenedor2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BuscadorProcesos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BuscadorProcesos";
            this.gpContenedor2.ResumeLayout(false);
            this.gpContenedor2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpContenedor2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.TextBox txtInicia;
        private System.Windows.Forms.Button btnbusc;
    }
}