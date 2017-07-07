using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Librerias Utilizadas.
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using Microsoft.VisualBasic.Devices;
using System.Timers;
using System.IO;

namespace WindowsAdm
{
    public partial class AdmWindows : Form
    {
      ComputerInfo ObjInfPC;//Variable de la clase VB para obtener informacion del equipo.
        Thread Hilo1, Hilo2,Hilo3; //Subprocesos
        ThreadStart TSproceso, TSservicio,TSestadisticas;//representa un metodo de la clase thread.
        ServiceController myService;

        public AdmWindows()
        {
            myService = new ServiceController();
            ObjInfPC = new ComputerInfo();//inicializar la variable.
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//realiza una excepción con los elementos que no son generados dentro del hilo.
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //se establecen los subprocesos y se ejecutan.
            TSproceso = new ThreadStart(ListaProcesos);
            Hilo1 = new Thread(TSproceso);
            Hilo1.Start();
            TSservicio = new ThreadStart(ListaServicios);
            Hilo2 = new Thread(TSservicio);
            Hilo2.Start();
        }
        public void ListaProcesos()
        {

            int id = 1; //Inicia la cuenta de procesos
            int Prioridad;
         
            this.LimpiarProcesos();
            this.listNombre.SelectedIndex = this.listNombre.Items.Count - 1;
            //se van ingresando los procesos a las listas.
            foreach (Process p in Process.GetProcesses())
            {

                
                listNombre.Items.Add(id + ":" + p.ProcessName); // Nombre del proceso
                listID.Items.Add(id + ": " + p.Id);// Identificador del proceso
                list_memoriafisica.Items.Add(id + ": " + p.WorkingSet64 / 1024);// Memoria Fisica del proceso
                list_memoriavirtual.Items.Add(id + ": " + p.VirtualMemorySize64 / 1024); //Memoria virtual del proceso
                listCPU.Items.Add(id + ": " + p.SessionId); // CPU que usa el proceso
                listUsuario.Items.Add(id + ": " + Environment.UserName); //Nombre de usuario
                listDescripcion.Items.Add(id + ": " + p.MainWindowTitle);//Descripcion

                Prioridad = Convert.ToInt32(p.BasePriority); // Nivel de prioridad
                if (Prioridad <= 4)
                {
                    listPrioridad.Items.Add(id + " : " + "Baja ");
                }
                else if (Prioridad <= 8)
                {
                    listPrioridad.Items.Add(id + " : " + "Normal");
                }
                else if (Prioridad <= 13)
                {
                    listPrioridad.Items.Add(id + " : " + "Alta");
                }
                else
                {
                    listPrioridad.Items.Add(id + " : " + "Tiempo Real");
                }



                id = id + 1;
            }


            this.ListarProcesos();//enfoca en ultimo proceso de la lista.
            Thread.Sleep(50);//espere 50 milisegundos.
        }

        public void ListaServicios()
        {
            int id = 1;//Inicia la cuenta de servicios
            int contCorr = 0;//cuenta los servicios corriendo.
            int contSup = 0;//cuenta los servicios suspendidos.
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();//recupera todo los servicios.
            //se van ingresando los servicios a las listas.
            this.LimpiarServicios();
            foreach (ServiceController scTemp in scServices)
            {

                listPID.Items.Add(id);
                listNomServicio.Items.Add(id + ":" + scTemp.ServiceName);//Nombre del servicio.
                listDescServicio.Items.Add(id + ": " + scTemp.DisplayName);//Descripcion del servicio.
                listStatus.Items.Add(id + ": " + scTemp.Status);//estado del servicio.
                listUserServicio.Items.Add(id + ": " + scTemp.MachineName);//nombre del equipo donde reside el servicio.
                listPausa_Reanudar.Items.Add(id + ": " + scTemp.CanPauseAndContinue.ToString());//se puede pausar o reanudar.
                listDetener.Items.Add(id + ": " + scTemp.CanStop.ToString());//se puede detener el servicio.
                if (scTemp.Status.ToString() == "Running")
                {
                    contCorr = contCorr + 1;
                }
                else
                {
                    contSup = contSup + 1;
                }
                Thread.Sleep(10);
                id = id + 1;

            }
            lbContCorriendo.Text = "Servicios en Ejecución   " + contCorr.ToString();
            lbContSuspendidos.Text = "Servicios Detenidos   " + contSup.ToString();
            this.ListarServicios();
        }
        private void Estadisticas()
        {
            double MTfisica = ObjInfPC.TotalPhysicalMemory;//memoria total del equipo.
            double MTvirtual = ObjInfPC.TotalVirtualMemory;//memoria total virtual.
            double Mfisica = ObjInfPC.AvailablePhysicalMemory;//memoria fisica disponible.
            double Mvirtual = ObjInfPC.AvailableVirtualMemory;//memoria virtual disponible.
            double MUtilfisica = MTfisica - Mfisica;//memoria fisica Utilizada.
            double MUtilVirtual = MTvirtual - Mvirtual;
           //formula para sacar el porcentaje.
            double cpuMTotal = Math.Round(100 - ((Mfisica * 100) / MTfisica), 2);
            double cpuVTotal = Math.Round(100 - ((Mvirtual * 100) / MTvirtual), 2);
            lbProcContar.Text = "Procesos en Ejecución     " + listNombre.Items.Count.ToString(); //Cantidad de Procesos en Ejecucion.
            lbMemoria.Text = "% Memeria     " + cpuMTotal.ToString() + " %";//Porcentaje de memoria utilizada.
            lbCPU.Text = "% CPU Utilizado     " + cpuVTotal.ToString() + "%";//porcentaje de CPU utilzado.

        }

        private void LimpiarProcesos()
        {
            ///Limpia las listas
            listNombre.Items.Clear();
            listID.Items.Clear();
            list_memoriafisica.Items.Clear();
            list_memoriavirtual.Items.Clear();
            listDescripcion.Items.Clear();
            listPrioridad.Items.Clear();
            listUsuario.Items.Clear();
            listCPU.Items.Clear();
        }

        private void LimpiarServicios()
        {
            ///Limpia las listas
            listPID.Items.Clear();
            listNomServicio.Items.Clear();
            listStatus.Items.Clear();
            listUserServicio.Items.Clear();
            listPausa_Reanudar.Items.Clear();
            listDescServicio.Items.Clear();
            listDetener.Items.Clear();

        }

        private void ListarProcesos()
        {
            //que todas las listas se enfoquen en el ultimo elemento agregado.
            listID.SelectedIndex = listID.Items.Count - 1; listID.Focus();
            listNombre.SelectedIndex = listNombre.Items.Count - 1; listNombre.Focus();
            listDescripcion.SelectedIndex = listDescripcion.Items.Count - 1; listDescripcion.Focus();
            listPrioridad.SelectedIndex = listPrioridad.Items.Count - 1; listPrioridad.Focus();
            listUsuario.SelectedIndex = listUsuario.Items.Count - 1; listUsuario.Focus();
            listCPU.SelectedIndex = listCPU.Items.Count - 1; listCPU.Focus();
            list_memoriafisica.SelectedIndex = list_memoriafisica.Items.Count - 1; list_memoriafisica.Focus();
            list_memoriavirtual.SelectedIndex = list_memoriavirtual.Items.Count - 1; list_memoriavirtual.Focus();
        }

        private void ListarServicios()
        {
            //que todas las listas se enfoquen en el ultimo elemento agregado.
            listPID.SelectedIndex = listPID.Items.Count - 1; listPID.Focus();
            listNomServicio.SelectedIndex = listNomServicio.Items.Count - 1; listNomServicio.Focus();
            listDescServicio.SelectedIndex = listDescServicio.Items.Count - 1; listDescServicio.Focus();
            listStatus.SelectedIndex = listStatus.Items.Count - 1; listStatus.Focus();
            listUserServicio.SelectedIndex = listUserServicio.Items.Count - 1; listUserServicio.Focus();
            listPausa_Reanudar.SelectedIndex = listPausa_Reanudar.Items.Count - 1; listPausa_Reanudar.Focus();
            listDetener.SelectedIndex = listDetener.Items.Count - 1; listDetener.Focus();


        }
        private void Buscar() {
            try
            {
                OpenFileDialog buscar = new OpenFileDialog(); //abre ventana para buscar.
                buscar.InitialDirectory = "c:\\Windows\\System32"; // direccion original de donde abre el adm de tareas al ejecutar un nuevo proceso.

                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    txtInicia.Text = buscar.FileName; //Le asign el nombre del archivo al textbox
                }


            }
            catch (Exception) { }
        }

        private void LimpiarText() {
            //Limpia el texbox.
            txtInicia.Text = string.Empty;
          
        }
        private void Iniciar()
        {
            try
            {
                if (txtInicia.Text != string.Empty)
                {
                    Process.Start(txtInicia.Text); //inica el proceso del archivo buscado
                    txtInicia.Text = string.Empty;
                    this.ListaProcesos();
                }
                else
                {
                    MessageBox.Show("No a ingresado ningun programa que quiera iniciar.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Detener() {
            try
            {
                foreach (Process p in Process.GetProcesses())
                {
                    string arr = listNombre.SelectedItem.ToString(); // Selecciona un proceso del listbox
                    string[] proceso = arr.Split(':');// Divide el contenido del listbox para poder terminar el proceso y 
                    //así no reconozca el número del proceso como parte de este


                    if (p.ProcessName == proceso[1])
                    {
                        p.Kill(); // Elimina el proceso

                    }

                }
                this.ListaProcesos();
            }
            catch (Exception x)
            {
                MessageBox.Show("No seleccionó ningún proceso " + x, "Error al Detener el Proceso", MessageBoxButtons.OK);
            }
        }

        private void DetenerArbolProcess()
        {
            try {
                foreach (Process p in Process.GetProcesses())
                {
                    string arr = listNombre.SelectedItem.ToString(); // Selecciona un proceso del listbox
                    string[] proceso = arr.Split(':');// Divide el contenido del listbox para poder terminar el proceso y 
                    //así no reconozca el número del proceso como parte de este
                   

                    if (p.ProcessName == proceso[1])
                    {
                        if (!p.HasExited)//obtiene un valor bool indicando si el proceso asociado está finalizado.
                            {
                                p.Kill();
                                p.WaitForExit();//espere hasta que el proceso asociado termine.
                            }
                        

                    }

                }
                this.ListaProcesos();
             }
            catch (Exception x)
            {
                MessageBox.Show("No seleccionó ningún proceso " + x, "Error al Detener el Proceso", MessageBoxButtons.OK);
            }
          
        }
        private void Reanudar() {

            try
            {
                if (listNomServicio.SelectedItems.Count > 0)
                {
                    string arr = listNomServicio.SelectedItem.ToString(); // Selecciona un proceso del listbox
                    string[] proceso = arr.Split(':');// Divide el contenido del listbox para poder terminar el proceso y 
                    string str = proceso[1].ToString();
                    myService.ServiceName = str; //establece el nombre del servicio.


                    if (myService.Status.Equals(ServiceControllerStatus.Stopped) || myService.Status.Equals(ServiceControllerStatus.StopPending) )//evalua cual es el estado en el que se encuentra el servicio.
                    { //y si esta el estado es detenido o detenido en espera.
                         myService.Start(); //iniciar el servicio.
                         myService.WaitForStatus(ServiceControllerStatus.Running);
                        
                     }

                    myService.Refresh();//actualizar.
                    this.ListaServicios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        
        }

        private void Pausar() {

            
            try
            {
                if (listNomServicio.SelectedItems.Count > 0) 
                {
                    string arr = listNomServicio.SelectedItem.ToString(); // Selecciona un proceso del listbox
                    string[] proceso = arr.Split(':');// Divide el contenido del listbox para poder terminar el proceso y 
                    string str = proceso[1].ToString();
                    myService.ServiceName = str;//establece el nombre del servicio 
                    if (myService.Status.Equals(ServiceControllerStatus.Running)) //evalua cual es el estado en el que se encuentra el servicio.
                    { //y si esta corriendo.
                        myService.Pause(); //pausa el servicio.
                        myService.WaitForStatus(ServiceControllerStatus.Paused); //cambia el estado del servicio a pausado.
                    }
                    else
                    {
                        MessageBox.Show("No sé a podido efectuar la suspensión del servicio.");
                    }
                    myService.Refresh();
                    this.ListaServicios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            
        }

        private void DetenerServicio()
        {
             
            try
            {
                if (listNomServicio.SelectedItems.Count > 0)
                {
                    string arr = listNomServicio.SelectedItem.ToString(); // Selecciona un proceso del listbox
                    string[] proceso = arr.Split(':');// Divide el contenido del listbox para poder terminar el proceso y 
                    string str = proceso[1].ToString();
                    myService.ServiceName = str; //establece el nombre del servicio.


                    if (myService.Status.Equals(ServiceControllerStatus.Running) || myService.Status.Equals(ServiceControllerStatus.StartPending) || myService.Status.Equals(ServiceControllerStatus.Paused)) //evalua cual es el estado en el que se encuentra el servicio.
                     { // y si esta corriendo o en espera.
                         myService.Stop(); // se finaliza el servicio.
                         myService.WaitForStatus(ServiceControllerStatus.Stopped); //el estado del servicio cambia a detenido.
                     }
                    else
                    {
                        MessageBox.Show("No sé a podido efectuar la finalización del servicio.");
                    }
                     myService.Refresh();//actualiza
                     this.ListaServicios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        

        }
       

        private void CambioPrioridad(int x)
        {
            int seleccion = x;
            if (listNombre.SelectedItems.Count > 0)
            {
                int indiceN = listNombre.SelectedIndex;
                string arr = listID.Items[indiceN].ToString(); // Selecciona un proceso del listbox
                string[] proceso = arr.Split(':');// Divide el contenido del listbox para poder terminar el proceso y 
                string str = proceso[1].ToString();
                int id = Convert.ToInt16(str);
                Process p = Process.GetProcessById(id);

                switch (seleccion)
                {
                    case 1:
                        
                        p.PriorityClass = ProcessPriorityClass.Idle;


                        break;
                    case 2:

                        p.PriorityClass = ProcessPriorityClass.Normal;

                        break;
                    case 3:
                        p.PriorityClass = ProcessPriorityClass.High;


                        break;
                    case 4:
                        p.PriorityClass = ProcessPriorityClass.RealTime;

                        break;


                }
                this.ListaProcesos();

            }
        }
        
        private void trmEstadisticas_Tick(object sender, EventArgs e)
        {
            TSestadisticas = new ThreadStart(Estadisticas);
            Hilo3 = new Thread(TSestadisticas);
            Hilo3.Start();
            
        }

        private void btnbusc_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarText();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Iniciar();
        }

        private void finalizarArbolDeProcesosTool_Click(object sender, EventArgs e)
        {
            this.DetenerArbolProcess();

        }

        private void finalizarTool_Click(object sender, EventArgs e)
        {
            this.Detener();
        }

        private void actualizarTool_Click(object sender, EventArgs e)
        {
            this.ListaProcesos();
            this.ListaServicios();
            this.Estadisticas();
        }

        private void salirTool_Click(object sender, EventArgs e)
        {
            Hilo1.Abort();
            Hilo2.Abort();
            Hilo3.Abort();
            Application.Exit();
        }

        private void bajaTool_Click(object sender, EventArgs e)
        {
            try
            {
          
                this.CambioPrioridad(1);
         
            }
            catch (Exception x)
            {

                MessageBox.Show("Por no seleccionar ningun elemento de la lista de prioridad se genero un error. " + x, "Error", MessageBoxButtons.OK);
            }
            
        }

        private void normalTool_Click(object sender, EventArgs e)
        {
            try
            {
                this.CambioPrioridad(2);
              
            }
            catch (Exception x)
            {

                MessageBox.Show("Por no seleccionar ningun elemento de la lista de prioridad se genero un error. " + x, "Error", MessageBoxButtons.OK);
            }
        }

        private void altaTool_Click(object sender, EventArgs e)
        {
            try
            {
                this.CambioPrioridad(3);
               
            }
            catch (Exception x)
            {

                MessageBox.Show("Por no seleccionar ningun elemento de la lista de prioridad se genero un error. " + x, "Error", MessageBoxButtons.OK);
            }
        }

        private void tiempoRealTool_Click(object sender, EventArgs e)
        {
            try
            {
                this.CambioPrioridad(4);
            }
            catch (Exception x)
            {

                MessageBox.Show("Por no seleccionar ningun elemento de la lista de prioridad se genero un error. " + x, "Error", MessageBoxButtons.OK);
            }
        }

        private void iniciarTool_Click(object sender, EventArgs e)
        {
            this.Reanudar();
        }

        private void pausarTool_Click(object sender, EventArgs e)
        {
            this.Pausar();
        }

        private void detenerTool_Click(object sender, EventArgs e)
        {
            this.DetenerServicio();
        }

        private void afinidadTool_Click(object sender, EventArgs e)
        {
            int indiceN = listNombre.SelectedIndex;
            string arr = listID.Items[indiceN].ToString(); // Selecciona un proceso del listbox
            string[] proceso = arr.Split(':');// Divide el contenido del listbox para poder terminar el proceso y 
            string str = proceso[1].ToString();
            int id = Convert.ToInt16(str);
            Procesador procesador = new Procesador();
            procesador.id = id;
            procesador.ShowDialog();
        }

     
       

        

      
        
    }
}
    

