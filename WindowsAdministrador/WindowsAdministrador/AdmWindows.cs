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

using System.Management;

namespace WindowsAdministrador
{
   
    public partial class Form1 : Form
    {
        #region Variables
        ListViewItem listProceso;//items del listview.
        ListViewItem listServicio;
        int Prioridad;
        int contCorr = 0;//cuenta los servicios corriendo.
        int contSup = 0;//cuenta los servicios suspendidos.
        ComputerInfo ObjInfPC;//Variable de la clase VB para obtener informacion del equipo.
        Thread Hilo1, Hilo2, Hilo3; //Subprocesos
        ThreadStart TSproceso, TSservicio, TSestadisticas;//representa un metodo de la clase thread.
        ServiceController myService;
        #endregion
        public Form1()
        {
            myService = new ServiceController();
            ObjInfPC = new ComputerInfo();//inicializar la variable.
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//realiza una excepción con los elementos que no son generados dentro del hilo.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TSproceso = new ThreadStart(ListaProcesos);
            Hilo1 = new Thread(TSproceso);
            Hilo1.Start();
            TSservicio = new ThreadStart(ListaServicio);
            Hilo2 = new Thread(TSservicio);
            Hilo2.Start();
           
                finalizarTool.Enabled = false;
                finalizarArbolDeProcesosTool.Enabled = false;
                afinidadTool.Enabled = false;
                prioridadTool.Enabled = false;
                detenerTool.Enabled = false;
                iniciarTool.Enabled = false;
                pausarTool.Enabled = false;
               
            
        }

        #region Ver Datos
        public void ListaProcesos()
        {
            listVProceso.Items.Clear();
            //se van ingresando los procesos a las listas.
            string Description; //-added by Rigo
            foreach (Process p in Process.GetProcesses())
            {
                try {
                    listProceso = new ListViewItem(p.Id.ToString());// Identificador del proceso
                    listProceso.SubItems.Add(p.ProcessName);
                    //listProceso.SubItems.Add(p.MainWindowTitle);//Descripcion
                    Description = FileVersionInfo.GetVersionInfo(p.Modules[0].FileName).FileDescription; //--added by Rigo
                    listProceso.SubItems.Add(Description); //--Added by Rigo
                    Prioridad = Convert.ToInt32(p.BasePriority); // Nivel de prioridad
                    if (Prioridad <= 4)
                    {
                        listProceso.SubItems.Add("Baja ");
                    }
                    else if (Prioridad <= 8)
                    {
                        listProceso.SubItems.Add("Normal");
                    }
                    else if (Prioridad <= 13)
                    {
                        listProceso.SubItems.Add("Alta");
                    }
                    else
                    {
                        listProceso.SubItems.Add("Tiempo Real");
                    }
                    //listProceso.SubItems.Add(Environment.UserName); //Nombre de usuario
                    listProceso.SubItems.Add(GetProcessOwner(p.Id)); //added by Rigo
                    listProceso.SubItems.Add((p.SessionId).ToString()); // CPU que usa el proceso
                    listProceso.SubItems.Add((p.VirtualMemorySize64 / 1024).ToString()); //Memoria virtual del proceso
                    listProceso.SubItems.Add((p.WorkingSet64 / 1024).ToString());// Memoria Fisica del proceso
                    listVProceso.Items.Add(listProceso);
                    Thread.Sleep(10);
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }
            }
           
        }
        //Added by Rigo, Funcion que recibe por parametro el ID del proceso y retornar el user.
        public string GetProcessOwner(int pid)
        {
            string query = "Select * From Win32_Process Where ProcessID = " + pid;
            //string query = "Select * From Win32_Process";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    return argList[1] + "\\" + argList[0];
                }
            }

            return "System";
        }




        public void ListaServicio() {
            listVServicio.Items.Clear();
            contCorr = 0;//cuenta los servicios corriendo.
            contSup = 0;//cuenta los servicios suspendidos.
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();//recupera todo los servicios.
            //se van ingresando los servicios a las listas.
           
            foreach (ServiceController scTemp in scServices)
            {
                listServicio = new ListViewItem(scTemp.ServiceName);//Nombre del servicio.
                ManagementObject service1 = new ManagementObject(@"Win32_service.Name='" + scTemp.ServiceName + "'");
                listServicio.SubItems.Add(service1.GetPropertyValue("ProcessId").ToString());//PID del servicio.
              //  listServicio.SubItems.Add("");
                listServicio.SubItems.Add(scTemp.DisplayName);//Descripcion del servicio.
                listServicio.SubItems.Add(scTemp.Status.ToString());//estado del servicio.
                listServicio.SubItems.Add(scTemp.MachineName);//nombre del equipo donde reside el servicio.
                listServicio.SubItems.Add(scTemp.CanPauseAndContinue.ToString());//se puede pausar o reanudar.
                listServicio.SubItems.Add(scTemp.CanStop.ToString());//se puede detener el servicio.
                listVServicio.Items.Add(listServicio);

                if (scTemp.Status.ToString() == "Running")
                {
                    contCorr = contCorr + 1;
                }
                else
                {
                    contSup = contSup + 1;
                }
                Thread.Sleep(10);
               

            }
            
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
            lbProcContar.Text = "Procesos en Ejecución     " + listVProceso.Items.Count.ToString(); //Cantidad de Procesos en Ejecucion.
            lbMemoria.Text = "% Memeria     " + cpuMTotal.ToString() + " %";//Porcentaje de memoria utilizada.
            lbCPU.Text = "% CPU Utilizado     " + cpuVTotal.ToString() + "%";//porcentaje de CPU utilzado.
            lbContCorriendo.Text = "Servicios en Ejecución   " + contCorr.ToString();
            lbContSuspendidos.Text = "Servicios Detenidos   " + contSup.ToString();
            Thread.Sleep(5);
        }
        #endregion

        public void Iniciar(string inicio)
        {
            try
            {
                if (inicio != string.Empty)
                {
                    Process.Start(inicio); //inica el proceso del archivo buscado
                   
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
            this.ListaProcesos(); 
        }
    
             private void Detener() {
            try
            {
                if (listVProceso.SelectedItems.Count > 0 && listVProceso.SelectedItems.Count < 2) //debe de seleccionar algun elemento de la lista
                {
                    int id=Convert.ToInt16(listVProceso.SelectedItems[0].Text);
                    foreach (Process p in Process.GetProcesses())
                    {
                       
                        if (p.Id == id)
                        {
                            p.Kill(); // Elimina el proceso

                        }

                    }
                    this.ListaProcesos();
                }
                else
                {
                    MessageBox.Show("Lo sentimos, para esta acción solo se puede seleccionar un elemento.");
                }
                
               
            }
            catch (Exception x)
            {
                MessageBox.Show("No seleccionó ningún proceso " + x, "Error al Detener el Proceso", MessageBoxButtons.OK);
            }
        }

             private void DetenerArbolProcess()
             {
                 try
                 {
                     if (listVProceso.SelectedItems.Count > 0 && listVProceso.SelectedItems.Count < 2)
                     {
                        
                         foreach (Process p in Process.GetProcesses())
                         {



                             if (p.ProcessName == listVProceso.SelectedItems[0].SubItems[1].Text)
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
                     else
                     {
                         MessageBox.Show("Lo sentimos, para esta acción solo se puede seleccionar un elemento.");
                     }
                 }
                 catch (Exception x)
                 {
                     MessageBox.Show("No seleccionó ningún proceso " + x, "Error al Detener el Proceso", MessageBoxButtons.OK);
                 }
             }

             private void CambioPrioridad(int x)
             {
                 int seleccion = x;
                 if (listVProceso.SelectedItems.Count > 0 && listVProceso.SelectedItems.Count < 2)
                 {
                     int id = Convert.ToInt16(listVProceso.SelectedItems[0].Text);
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
                 else
                 {
                     MessageBox.Show("Lo sentimos, para esta acción solo se puede seleccionar un elemento.");
                 }
             }

             private void Reanudar()
             {

                 try
                 {
                     if (listVServicio.SelectedItems.Count > 0 && listVServicio.SelectedItems.Count < 2)
                     {
                         myService.ServiceName = listVServicio.SelectedItems[0].Text; //establece el nombre del servicio.


                         if (myService.Status.Equals(ServiceControllerStatus.Stopped) || myService.Status.Equals(ServiceControllerStatus.StopPending))//evalua cual es el estado en el que se encuentra el servicio.
                         { //y si esta el estado es detenido o detenido en espera.
                             myService.Start(); //iniciar el servicio.
                             myService.WaitForStatus(ServiceControllerStatus.Running);

                         }

                         myService.Refresh();//actualizar.
                         this.ListaServicio();
                     }
                     else
                     {
                         MessageBox.Show("Lo sentimos, para esta acción solo se puede seleccionar un elemento.");
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message, this.Text);
                 }

             }

             private void Pausar()
             {


                 try
                 {
                     if (listVServicio.SelectedItems.Count > 0 && listVServicio.SelectedItems.Count < 2)
                     {
                         myService.ServiceName = listVServicio.SelectedItems[0].Text; //establece el nombre del servicio.

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
                         this.ListaServicio();
                     }
                     else
                     {
                         MessageBox.Show("Lo sentimos, para esta acción solo se puede seleccionar un elemento.");
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
                     if (listVServicio.SelectedItems.Count > 0 && listVServicio.SelectedItems.Count < 2)
                     {
                         myService.ServiceName = listVServicio.SelectedItems[0].Text; //establece el nombre del servicio.
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
                         this.ListaServicio();
                     }
                     else
                     {
                         MessageBox.Show("Lo sentimos, para esta acción solo se puede seleccionar un elemento.");
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message, this.Text);
                 }


             }


             private void finalizarTool_Click(object sender, EventArgs e)
             {
                 this.Detener();
             }
             private void actualizarTool_Click(object sender, EventArgs e)
             {
                 this.ListaProcesos();
                 this.ListaServicio();
             }
             private void trmEstadisticas_Tick(object sender, EventArgs e)
             {
                 TSestadisticas = new ThreadStart(Estadisticas);
                 Hilo3 = new Thread(TSestadisticas);
                 Hilo3.Start();
             }

             private void iniciarProcesoTool_Click(object sender, EventArgs e)
             {
                 BuscadorProcesos buscProc = new BuscadorProcesos();
                 buscProc.ShowDialog();
             }

             private void salirTool_Click(object sender, EventArgs e)
             {
                 Hilo1.Abort();
                 Hilo2.Abort();
                 Hilo3.Abort();
                 Application.Exit();
             }

             private void finalizarArbolDeProcesosTool_Click(object sender, EventArgs e)
             {
                 this.DetenerArbolProcess();
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

             private void afinidadTool_Click(object sender, EventArgs e)
             {
                 int id = Convert.ToInt16(listVProceso.SelectedItems[0].Text);
                 Afinidad procesador = new Afinidad();
                 procesador.id = id;
                 procesador.ShowDialog();
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

             private void listVServicio_SelectedIndexChanged(object sender, EventArgs e)
             {
                 if (listVServicio.SelectedItems.Count > 0)
                 {
                     detenerTool.Enabled = true;
                     iniciarTool.Enabled = true;
                     pausarTool.Enabled = true;

                 }
                 else
                 {
                     detenerTool.Enabled = false;
                     iniciarTool.Enabled = false;
                     pausarTool.Enabled = false;

                 }
             }

             private void listVProceso_SelectedIndexChanged(object sender, EventArgs e)
             {
                 if (listVProceso.SelectedItems.Count > 0)
                 {
                     finalizarTool.Enabled = true;
                     finalizarArbolDeProcesosTool.Enabled = true;
                     afinidadTool.Enabled = true;
                     prioridadTool.Enabled = true;
                 }
                 else
                 {
                     finalizarTool.Enabled = false;
                     finalizarArbolDeProcesosTool.Enabled = false;
                     afinidadTool.Enabled = false;
                     prioridadTool.Enabled = false;
                 }
             }
        }


    }

