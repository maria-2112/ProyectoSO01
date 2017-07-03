namespace WindowsAdministrador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ContxtServicio = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iniciarTool = new System.Windows.Forms.ToolStripMenuItem();
            this.pausarTool = new System.Windows.Forms.ToolStripMenuItem();
            this.detenerTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPagEstadisticas = new System.Windows.Forms.TabPage();
            this.gpEstadistica = new System.Windows.Forms.GroupBox();
            this.plEstadistico = new System.Windows.Forms.Panel();
            this.lbProcContar = new System.Windows.Forms.Label();
            this.lbContSuspendidos = new System.Windows.Forms.Label();
            this.lbCPU = new System.Windows.Forms.Label();
            this.lbContCorriendo = new System.Windows.Forms.Label();
            this.lbMemoria = new System.Windows.Forms.Label();
            this.tabPagProceso = new System.Windows.Forms.TabPage();
            this.listVProceso = new System.Windows.Forms.ListView();
            this.columIDp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columProcess = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columDescp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columPrioridadp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUserp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columCPUp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columMemVirtual = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columMemFisica = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContxtProceso = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.finalizarTool = new System.Windows.Forms.ToolStripMenuItem();
            this.finalizarArbolDeProcesosTool = new System.Windows.Forms.ToolStripMenuItem();
            this.afinidadTool = new System.Windows.Forms.ToolStripMenuItem();
            this.prioridadTool = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaTool = new System.Windows.Forms.ToolStripMenuItem();
            this.normalTool = new System.Windows.Forms.ToolStripMenuItem();
            this.altaTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tiempoRealTool = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarProcesoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPagServicio = new System.Windows.Forms.TabPage();
            this.listVServicio = new System.Windows.Forms.ListView();
            this.columServicio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columDescServ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columPauReanu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columDetener = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trmEstadisticas = new System.Windows.Forms.Timer(this.components);
            this.ContxtMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.actualizarTool = new System.Windows.Forms.ToolStripMenuItem();
            this.salirTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.ContxtServicio.SuspendLayout();
            this.tabPagEstadisticas.SuspendLayout();
            this.gpEstadistica.SuspendLayout();
            this.plEstadistico.SuspendLayout();
            this.tabPagProceso.SuspendLayout();
            this.ContxtProceso.SuspendLayout();
            this.tabPagServicio.SuspendLayout();
            this.ContxtMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.ContextMenuStrip = this.ContxtServicio;
            this.tabControl.Controls.Add(this.tabPagEstadisticas);
            this.tabControl.Controls.Add(this.tabPagProceso);
            this.tabControl.Controls.Add(this.tabPagServicio);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(6, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(703, 620);
            this.tabControl.TabIndex = 0;
            // 
            // ContxtServicio
            // 
            this.ContxtServicio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarTool,
            this.pausarTool,
            this.detenerTool});
            this.ContxtServicio.Name = "ContxtServicio";
            this.ContxtServicio.Size = new System.Drawing.Size(116, 70);
            // 
            // iniciarTool
            // 
            this.iniciarTool.Name = "iniciarTool";
            this.iniciarTool.Size = new System.Drawing.Size(115, 22);
            this.iniciarTool.Text = "Iniciar";
            this.iniciarTool.Click += new System.EventHandler(this.iniciarTool_Click);
            // 
            // pausarTool
            // 
            this.pausarTool.Name = "pausarTool";
            this.pausarTool.Size = new System.Drawing.Size(115, 22);
            this.pausarTool.Text = "Pausar";
            this.pausarTool.Click += new System.EventHandler(this.pausarTool_Click);
            // 
            // detenerTool
            // 
            this.detenerTool.Name = "detenerTool";
            this.detenerTool.Size = new System.Drawing.Size(115, 22);
            this.detenerTool.Text = "Detener";
            this.detenerTool.Click += new System.EventHandler(this.detenerTool_Click);
            // 
            // tabPagEstadisticas
            // 
            this.tabPagEstadisticas.Controls.Add(this.gpEstadistica);
            this.tabPagEstadisticas.Location = new System.Drawing.Point(4, 22);
            this.tabPagEstadisticas.Name = "tabPagEstadisticas";
            this.tabPagEstadisticas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagEstadisticas.Size = new System.Drawing.Size(695, 594);
            this.tabPagEstadisticas.TabIndex = 2;
            this.tabPagEstadisticas.Text = "Estadisticas";
            this.tabPagEstadisticas.UseVisualStyleBackColor = true;
            // 
            // gpEstadistica
            // 
            this.gpEstadistica.BackgroundImage = global::WindowsAdministrador.Properties.Resources.screenshot542;
            this.gpEstadistica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gpEstadistica.Controls.Add(this.plEstadistico);
            this.gpEstadistica.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpEstadistica.Location = new System.Drawing.Point(6, 6);
            this.gpEstadistica.Name = "gpEstadistica";
            this.gpEstadistica.Size = new System.Drawing.Size(680, 578);
            this.gpEstadistica.TabIndex = 0;
            this.gpEstadistica.TabStop = false;
            this.gpEstadistica.Text = "Estadisticas";
            // 
            // plEstadistico
            // 
            this.plEstadistico.Controls.Add(this.lbProcContar);
            this.plEstadistico.Controls.Add(this.lbContSuspendidos);
            this.plEstadistico.Controls.Add(this.lbCPU);
            this.plEstadistico.Controls.Add(this.lbContCorriendo);
            this.plEstadistico.Controls.Add(this.lbMemoria);
            this.plEstadistico.Location = new System.Drawing.Point(147, 57);
            this.plEstadistico.Name = "plEstadistico";
            this.plEstadistico.Size = new System.Drawing.Size(342, 494);
            this.plEstadistico.TabIndex = 37;
            // 
            // lbProcContar
            // 
            this.lbProcContar.AutoSize = true;
            this.lbProcContar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProcContar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbProcContar.Location = new System.Drawing.Point(32, 13);
            this.lbProcContar.Name = "lbProcContar";
            this.lbProcContar.Size = new System.Drawing.Size(97, 24);
            this.lbProcContar.TabIndex = 30;
            this.lbProcContar.Text = "Procesos";
            // 
            // lbContSuspendidos
            // 
            this.lbContSuspendidos.AutoSize = true;
            this.lbContSuspendidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContSuspendidos.Location = new System.Drawing.Point(43, 365);
            this.lbContSuspendidos.Name = "lbContSuspendidos";
            this.lbContSuspendidos.Size = new System.Drawing.Size(195, 24);
            this.lbContSuspendidos.TabIndex = 36;
            this.lbContSuspendidos.Text = "Servicios Detenidos";
            // 
            // lbCPU
            // 
            this.lbCPU.AutoSize = true;
            this.lbCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCPU.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbCPU.Location = new System.Drawing.Point(32, 103);
            this.lbCPU.Name = "lbCPU";
            this.lbCPU.Size = new System.Drawing.Size(158, 24);
            this.lbCPU.TabIndex = 28;
            this.lbCPU.Text = "% CPU Utilizado";
            // 
            // lbContCorriendo
            // 
            this.lbContCorriendo.AutoSize = true;
            this.lbContCorriendo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContCorriendo.Location = new System.Drawing.Point(43, 273);
            this.lbContCorriendo.Name = "lbContCorriendo";
            this.lbContCorriendo.Size = new System.Drawing.Size(225, 24);
            this.lbContCorriendo.TabIndex = 35;
            this.lbContCorriendo.Text = "Servicios en Ejecución";
            // 
            // lbMemoria
            // 
            this.lbMemoria.AutoSize = true;
            this.lbMemoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMemoria.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbMemoria.Location = new System.Drawing.Point(43, 184);
            this.lbMemoria.Name = "lbMemoria";
            this.lbMemoria.Size = new System.Drawing.Size(113, 24);
            this.lbMemoria.TabIndex = 29;
            this.lbMemoria.Text = "% Memeria";
            // 
            // tabPagProceso
            // 
            this.tabPagProceso.Controls.Add(this.listVProceso);
            this.tabPagProceso.Location = new System.Drawing.Point(4, 22);
            this.tabPagProceso.Name = "tabPagProceso";
            this.tabPagProceso.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagProceso.Size = new System.Drawing.Size(695, 594);
            this.tabPagProceso.TabIndex = 0;
            this.tabPagProceso.Text = "Proceso";
            this.tabPagProceso.UseVisualStyleBackColor = true;
            // 
            // listVProceso
            // 
            this.listVProceso.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columIDp,
            this.columProcess,
            this.columDescp,
            this.columPrioridadp,
            this.columnUserp,
            this.columCPUp,
            this.columMemVirtual,
            this.columMemFisica});
            this.listVProceso.ContextMenuStrip = this.ContxtProceso;
            this.listVProceso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVProceso.Location = new System.Drawing.Point(3, 3);
            this.listVProceso.Name = "listVProceso";
            this.listVProceso.Size = new System.Drawing.Size(689, 588);
            this.listVProceso.TabIndex = 0;
            this.listVProceso.UseCompatibleStateImageBehavior = false;
            this.listVProceso.View = System.Windows.Forms.View.Details;
            this.listVProceso.SelectedIndexChanged += new System.EventHandler(this.listVProceso_SelectedIndexChanged);
            // 
            // columIDp
            // 
            this.columIDp.Text = "Identificador";
            this.columIDp.Width = 70;
            // 
            // columProcess
            // 
            this.columProcess.Text = "Proceso";
            this.columProcess.Width = 100;
            // 
            // columDescp
            // 
            this.columDescp.Text = "Descripción";
            this.columDescp.Width = 80;
            // 
            // columPrioridadp
            // 
            this.columPrioridadp.Text = "Prioridad";
            // 
            // columnUserp
            // 
            this.columnUserp.Text = "Usuario";
            // 
            // columCPUp
            // 
            this.columCPUp.Text = "CPU";
            this.columCPUp.Width = 45;
            // 
            // columMemVirtual
            // 
            this.columMemVirtual.Text = "Memoria Virtual (en KB)";
            this.columMemVirtual.Width = 130;
            // 
            // columMemFisica
            // 
            this.columMemFisica.Text = "Memoria Fisca (en KB)";
            this.columMemFisica.Width = 130;
            // 
            // ContxtProceso
            // 
            this.ContxtProceso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.finalizarTool,
            this.finalizarArbolDeProcesosTool,
            this.afinidadTool,
            this.prioridadTool,
            this.iniciarProcesoTool});
            this.ContxtProceso.Name = "ContxtProceso";
            this.ContxtProceso.Size = new System.Drawing.Size(216, 114);
            // 
            // finalizarTool
            // 
            this.finalizarTool.Name = "finalizarTool";
            this.finalizarTool.Size = new System.Drawing.Size(215, 22);
            this.finalizarTool.Text = "Finalizar Proceso";
            this.finalizarTool.Click += new System.EventHandler(this.finalizarTool_Click);
            // 
            // finalizarArbolDeProcesosTool
            // 
            this.finalizarArbolDeProcesosTool.Name = "finalizarArbolDeProcesosTool";
            this.finalizarArbolDeProcesosTool.Size = new System.Drawing.Size(215, 22);
            this.finalizarArbolDeProcesosTool.Text = "Finalizar Arbol de Procesos";
            this.finalizarArbolDeProcesosTool.Click += new System.EventHandler(this.finalizarArbolDeProcesosTool_Click);
            // 
            // afinidadTool
            // 
            this.afinidadTool.Name = "afinidadTool";
            this.afinidadTool.Size = new System.Drawing.Size(215, 22);
            this.afinidadTool.Text = "Cambiar Afinidad";
            this.afinidadTool.Click += new System.EventHandler(this.afinidadTool_Click);
            // 
            // prioridadTool
            // 
            this.prioridadTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bajaTool,
            this.normalTool,
            this.altaTool,
            this.tiempoRealTool});
            this.prioridadTool.Name = "prioridadTool";
            this.prioridadTool.Size = new System.Drawing.Size(215, 22);
            this.prioridadTool.Text = "Prioridad";
            // 
            // bajaTool
            // 
            this.bajaTool.Name = "bajaTool";
            this.bajaTool.Size = new System.Drawing.Size(140, 22);
            this.bajaTool.Text = "Baja";
            this.bajaTool.Click += new System.EventHandler(this.bajaTool_Click);
            // 
            // normalTool
            // 
            this.normalTool.Name = "normalTool";
            this.normalTool.Size = new System.Drawing.Size(140, 22);
            this.normalTool.Text = "Normal";
            this.normalTool.Click += new System.EventHandler(this.normalTool_Click);
            // 
            // altaTool
            // 
            this.altaTool.Name = "altaTool";
            this.altaTool.Size = new System.Drawing.Size(140, 22);
            this.altaTool.Text = "Alta";
            this.altaTool.Click += new System.EventHandler(this.altaTool_Click);
            // 
            // tiempoRealTool
            // 
            this.tiempoRealTool.Name = "tiempoRealTool";
            this.tiempoRealTool.Size = new System.Drawing.Size(140, 22);
            this.tiempoRealTool.Text = "Tiempo Real";
            this.tiempoRealTool.Click += new System.EventHandler(this.tiempoRealTool_Click);
            // 
            // iniciarProcesoTool
            // 
            this.iniciarProcesoTool.Name = "iniciarProcesoTool";
            this.iniciarProcesoTool.Size = new System.Drawing.Size(215, 22);
            this.iniciarProcesoTool.Text = "Iniciar Proceso";
            this.iniciarProcesoTool.Click += new System.EventHandler(this.iniciarProcesoTool_Click);
            // 
            // tabPagServicio
            // 
            this.tabPagServicio.Controls.Add(this.listVServicio);
            this.tabPagServicio.Location = new System.Drawing.Point(4, 22);
            this.tabPagServicio.Name = "tabPagServicio";
            this.tabPagServicio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagServicio.Size = new System.Drawing.Size(695, 594);
            this.tabPagServicio.TabIndex = 1;
            this.tabPagServicio.Text = "Servicios";
            this.tabPagServicio.UseVisualStyleBackColor = true;
            // 
            // listVServicio
            // 
            this.listVServicio.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columServicio,
            this.columPID,
            this.columDescServ,
            this.columStatus,
            this.columUser,
            this.columPauReanu,
            this.columDetener});
            this.listVServicio.ContextMenuStrip = this.ContxtServicio;
            this.listVServicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVServicio.Location = new System.Drawing.Point(3, 3);
            this.listVServicio.Name = "listVServicio";
            this.listVServicio.Size = new System.Drawing.Size(689, 588);
            this.listVServicio.TabIndex = 1;
            this.listVServicio.UseCompatibleStateImageBehavior = false;
            this.listVServicio.View = System.Windows.Forms.View.Details;
            this.listVServicio.SelectedIndexChanged += new System.EventHandler(this.listVServicio_SelectedIndexChanged);
            // 
            // columServicio
            // 
            this.columServicio.Text = "Servicio";
            this.columServicio.Width = 100;
            // 
            // columPID
            // 
            this.columPID.Text = "PID";
            // 
            // columDescServ
            // 
            this.columDescServ.Text = "Descripción";
            this.columDescServ.Width = 200;
            // 
            // columStatus
            // 
            this.columStatus.Text = "Estado";
            this.columStatus.Width = 70;
            // 
            // columUser
            // 
            this.columUser.Text = "Usuario";
            this.columUser.Width = 61;
            // 
            // columPauReanu
            // 
            this.columPauReanu.Text = "Pausar/Reanudar";
            this.columPauReanu.Width = 99;
            // 
            // columDetener
            // 
            this.columDetener.Text = "¿Detener?";
            this.columDetener.Width = 85;
            // 
            // trmEstadisticas
            // 
            this.trmEstadisticas.Enabled = true;
            this.trmEstadisticas.Interval = 50;
            this.trmEstadisticas.Tick += new System.EventHandler(this.trmEstadisticas_Tick);
            // 
            // ContxtMenu
            // 
            this.ContxtMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarTool,
            this.salirTool});
            this.ContxtMenu.Name = "ContxtMenu";
            this.ContxtMenu.Size = new System.Drawing.Size(127, 48);
            // 
            // actualizarTool
            // 
            this.actualizarTool.Name = "actualizarTool";
            this.actualizarTool.Size = new System.Drawing.Size(126, 22);
            this.actualizarTool.Text = "Actualizar";
            this.actualizarTool.Click += new System.EventHandler(this.actualizarTool_Click);
            // 
            // salirTool
            // 
            this.salirTool.Name = "salirTool";
            this.salirTool.Size = new System.Drawing.Size(126, 22);
            this.salirTool.Text = "Salir";
            this.salirTool.Click += new System.EventHandler(this.salirTool_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsAdministrador.Properties.Resources.screenshot542;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(708, 616);
            this.ContextMenuStrip = this.ContxtMenu;
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de Tareas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.ContxtServicio.ResumeLayout(false);
            this.tabPagEstadisticas.ResumeLayout(false);
            this.gpEstadistica.ResumeLayout(false);
            this.plEstadistico.ResumeLayout(false);
            this.plEstadistico.PerformLayout();
            this.tabPagProceso.ResumeLayout(false);
            this.ContxtProceso.ResumeLayout(false);
            this.tabPagServicio.ResumeLayout(false);
            this.ContxtMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPagProceso;
       
        private System.Windows.Forms.TabPage tabPagServicio;
        private System.Windows.Forms.ListView listVServicio;
        private System.Windows.Forms.ColumnHeader columServicio;
        private System.Windows.Forms.ColumnHeader columPID;
        private System.Windows.Forms.ColumnHeader columDescServ;
        private System.Windows.Forms.ColumnHeader columStatus;
        private System.Windows.Forms.ColumnHeader columUser;
        private System.Windows.Forms.ColumnHeader columPauReanu;
       
        private System.Windows.Forms.ListView listVProceso;
        private System.Windows.Forms.ColumnHeader columIDp;
        private System.Windows.Forms.ColumnHeader columProcess;
        private System.Windows.Forms.ColumnHeader columDescp;
        private System.Windows.Forms.ColumnHeader columPrioridadp;
        private System.Windows.Forms.ColumnHeader columnUserp;
        private System.Windows.Forms.ColumnHeader columCPUp;
        private System.Windows.Forms.ColumnHeader columMemVirtual;
        private System.Windows.Forms.ColumnHeader columMemFisica;
        private System.Windows.Forms.ColumnHeader columDetener;
        private System.Windows.Forms.TabPage tabPagEstadisticas;
        private System.Windows.Forms.GroupBox gpEstadistica;
        private System.Windows.Forms.Label lbContSuspendidos;
        private System.Windows.Forms.Label lbContCorriendo;
        private System.Windows.Forms.Label lbProcContar;
        private System.Windows.Forms.Label lbMemoria;
        private System.Windows.Forms.Label lbCPU;
        private System.Windows.Forms.Timer trmEstadisticas;
        private System.Windows.Forms.ContextMenuStrip ContxtServicio;
        private System.Windows.Forms.ToolStripMenuItem iniciarTool;
        private System.Windows.Forms.ToolStripMenuItem pausarTool;
        private System.Windows.Forms.ToolStripMenuItem detenerTool;
        private System.Windows.Forms.ContextMenuStrip ContxtProceso;
        private System.Windows.Forms.ToolStripMenuItem finalizarTool;
        private System.Windows.Forms.ToolStripMenuItem finalizarArbolDeProcesosTool;
        private System.Windows.Forms.ToolStripMenuItem afinidadTool;
        private System.Windows.Forms.ToolStripMenuItem prioridadTool;
        private System.Windows.Forms.ToolStripMenuItem bajaTool;
        private System.Windows.Forms.ToolStripMenuItem normalTool;
        private System.Windows.Forms.ToolStripMenuItem altaTool;
        private System.Windows.Forms.ToolStripMenuItem tiempoRealTool;
        private System.Windows.Forms.ToolStripMenuItem iniciarProcesoTool;
        private System.Windows.Forms.ContextMenuStrip ContxtMenu;
        private System.Windows.Forms.ToolStripMenuItem actualizarTool;
        private System.Windows.Forms.ToolStripMenuItem salirTool;
        private System.Windows.Forms.Panel plEstadistico;
    }
}

