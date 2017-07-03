using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsAdministrador
{
    public partial class BuscadorProcesos : Form
    {
        public BuscadorProcesos()
        {
            InitializeComponent();
        }

        private void btnbusc_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            Form1 adm = new Form1();
            try
            {
                if (txtInicia.Text != string.Empty)
                {
                    adm.Iniciar(txtInicia.Text);
                   
                }
                txtInicia.Text = string.Empty;
                adm.ListaProcesos();
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarText();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LimpiarText()
        {
            //Limpia el texbox.
            txtInicia.Text = string.Empty;

        }

        private void Buscar()
        {
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

       
       

       
    }
}
