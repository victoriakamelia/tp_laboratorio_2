using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainCorreo
{
    public partial class FormPpal : Form
    {
        Correo correo;

        /// <summary>
        /// Constructor de FormPpal.
        /// </summary>
        public  FormPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        /// <summary>
        /// Método para mostrar los paquetes en base al estado.
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngreasado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            foreach (Paquete paqueteQueBusco in this.correo.Paquetes)
            {
                switch (paqueteQueBusco.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngreasado.Items.Add(paqueteQueBusco);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paqueteQueBusco);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paqueteQueBusco);
                        break;
                }
            }
        }

        /// <summary>
        /// Método para agregar un paquete al correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            paquete.InformaEstado += this.paq_InformaEstado;
            paquete.ocurrioError += this.MostrarError;
            try
            {
                this.correo += paquete;
            }
            catch (TrackingIdRepetidoException exception)
            {
                MessageBox.Show(exception.Message);
            }
            this.ActualizarEstados();
        }

        /// <summary>
        /// Método para mostrar la información del Correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Closing del Form, aborta los hilos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Muestra la informacion del Correo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(elemento is null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                elemento.MostrarDatos(elemento).Guardar("salida.txt");
            }
        }

        /// <summary>
        /// Método para darle funcionalidad al StripMenuItem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Método manejador del evento InformaEstado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Método manejador de OcurrioError.
        /// </summary>
        /// <param name="mensaje"></param>
        private void MostrarError(string mensaje)
        {
            MessageBox.Show("Alerta:" + mensaje);
        }

      
    }
}
