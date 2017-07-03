using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace WindowsAdministrador
{

    public partial class Afinidad : Form
    {
        public int id;
        public Afinidad()
        {
            InitializeComponent();
        }

        private void Afinidad_Load(object sender, EventArgs e)
        {
            this.Kernel();
            
        }
        private void Kernel()
        { //Establece los nucleos que tiene el computador.
            int coreCount = Environment.ProcessorCount;

            checkedKernel.Items.Clear();
            checkedKernel.Items.Add(string.Format("CPU [ Todos ]"));
            for (Int16 i = 0; i <= coreCount - 1; i++)
            {
                checkedKernel.Items.Add(string.Format("CPU [ {0} ]", i));
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (checkedKernel.SelectedItems.Count > 0)
            {


                if (checkedKernel.GetItemChecked(0) && checkedKernel.GetItemChecked(1) == false && checkedKernel.GetItemChecked(3) == false && checkedKernel.GetItemChecked(4) == false && checkedKernel.GetItemChecked(2) == false)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)15;//la afinidad es con todos los nucleos.
                    btnAceptar.Enabled = true;
                }
                if (checkedKernel.GetItemChecked(1) == true && checkedKernel.GetItemChecked(2) == false && checkedKernel.GetItemChecked(3) == false && checkedKernel.GetItemChecked(4) == false && checkedKernel.GetItemChecked(0) == false)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)1;//afinidad 0.
                }
                if (checkedKernel.GetItemChecked(2) == true && checkedKernel.GetItemChecked(1) == false && checkedKernel.GetItemChecked(3) == false && checkedKernel.GetItemChecked(4) == false && checkedKernel.GetItemChecked(0) == false)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)2;//afinidad 1.
                }
                if (checkedKernel.GetItemChecked(3) == true && checkedKernel.GetItemChecked(1) == false && checkedKernel.GetItemChecked(2) == false && checkedKernel.GetItemChecked(4) == false && checkedKernel.GetItemChecked(0) == false)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)4;//afinidad 2.
                }

                if (checkedKernel.GetItemChecked(4) == true && checkedKernel.GetItemChecked(1) == false && checkedKernel.GetItemChecked(3) == false && checkedKernel.GetItemChecked(2) == false && checkedKernel.GetItemChecked(0) == false)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)8;//afinidad 3.
                }




                if (checkedKernel.GetItemChecked(1) == true && checkedKernel.GetItemChecked(2) == true)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)3;//afinidad 0,1.
                }
                
                    if (checkedKernel.GetItemChecked(1) == true  && checkedKernel.GetItemChecked(3) == true)
                    {
                        Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)5;//afinidad 0,2.
                    }
                    if (checkedKernel.GetItemChecked(1) == true && checkedKernel.GetItemChecked(4) == true)
                    {
                        Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)9;//afinidad primero y ultimo.
                    }
                if (checkedKernel.GetItemChecked(2) == true && checkedKernel.GetItemChecked(3) == true)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)6;//afinidad 1,2.
                }
                if (checkedKernel.GetItemChecked(2) == true && checkedKernel.GetItemChecked(4) == true)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)10;//afinidad 1,3.
                }
                if (checkedKernel.GetItemChecked(3) == true && checkedKernel.GetItemChecked(4) == true && checkedKernel.GetItemChecked(1) == false)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)12;//afinidad 2,3.
                }


               

                if (checkedKernel.GetItemChecked(1) == true && checkedKernel.GetItemChecked(2) == true && checkedKernel.GetItemChecked(3) == true)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)7;//afinidad 0,1,2.
                }
                if (checkedKernel.GetItemChecked(1) == true && checkedKernel.GetItemChecked(2) == true && checkedKernel.GetItemChecked(4) == true)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)11;//afinidad 0,1,3.
                }
                if (checkedKernel.GetItemChecked(1) == true && checkedKernel.GetItemChecked(3) == true && checkedKernel.GetItemChecked(4) == true)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)13;//afinidad 0,2,3.
                }
                if (checkedKernel.GetItemChecked(2) == true && checkedKernel.GetItemChecked(4) == true && checkedKernel.GetItemChecked(4) == true)
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)14;//afinidad 1,2,3.
                }

                this.Close();
            }
        }
        private void checkedKernel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedKernel.SelectedItems.Count>0)
            {
                
          
            if (checkedKernel.GetItemChecked(0))
            {
                Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)15;//la afinidad es con todos los nucleos.
                btnAceptar.Enabled = true;
            }
          
            if (checkedKernel.GetItemChecked(1))
            {
                Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)1;//la afinidad es con el nucleo 1.
                btnAceptar.Enabled = true;
            }
          
            if (checkedKernel.GetItemChecked(2))
            {
                Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)2;//la afinidad es con el nucleo 1.
                btnAceptar.Enabled = true;
            }
           
            if (checkedKernel.GetItemChecked(3))
            {
                Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)4;//la afinidad es con el nucleo 2.
                btnAceptar.Enabled = true;
            }
           
            if (checkedKernel.GetItemChecked(4))
            {
                Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)8;//la afinidad es con el nucleo 3.
                btnAceptar.Enabled = true;
            }

            //if (checkedKernel.GetItemChecked(1)==true)
            //{
            //    if (checkedKernel.GetItemChecked(2) == true) {
            //        if (checkedKernel.GetItemChecked(3) == true)
            //        {
            //            Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)3;//la afinidad es con el nucleo 3.
            //        }
            //    }
            //    else { 
            //    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)8;//la afinidad es con el nucleo 3.
            //    }
            //}

            }
            else
            {
                btnAceptar.Enabled = false;
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
            }

                                 
                    
                }
            
            

    
