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
namespace WindowsAdm
{
    public partial class Procesador : Form
    {
        public int id;
        public Procesador()
        {
            InitializeComponent();
        }

        private void Procesador_Load(object sender, EventArgs e)
        {
            this.Kernel();
        }
        private void Kernel()
        { //Establece los nucleos que tiene el computador.
            int coreCount = Environment.ProcessorCount;

            listKernel.Items.Clear();
            listKernel.Items.Add(string.Format("CPU [ Todos ]"));
            for (Int16 i = 0; i <= coreCount - 1; i++)
            {
                listKernel.Items.Add(string.Format("CPU [ {0} ]", i));
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {//evalua la opcion seleccionada.
            if (listKernel.SelectedItem.ToString() == listKernel.Items[0].ToString())
            {
                Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)15;//la afinidad es con todos los nucleos.
            }
            else
            {
                if (listKernel.SelectedItem.ToString() == listKernel.Items[1].ToString())
                {
                    Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)1;//la afinidad es con el nucleo 0.
                }
                else
                {
                    if (listKernel.SelectedItem.ToString() == listKernel.Items[2].ToString())
                    {
                        Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)2;////la afinidad es con el nucleo 1
                    }
                    else
                    {
                        if (listKernel.SelectedItem.ToString() == listKernel.Items[3].ToString())
                        {
                            Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)4; //la afinidad es con el nucleo 2
                        }
                        else
                        {
                            if (listKernel.SelectedItem.ToString() == listKernel.Items[4].ToString())
                            {
                                Process.GetProcessById(id).ProcessorAffinity = (System.IntPtr)8;////la afinidad es con el nucleo 3
                            }
                        }
                    }


                }
            }
            this.Close();
        }
    }
}