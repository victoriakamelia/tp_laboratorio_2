using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class MiCalculadora : Form
    {
        bool estaEnBinario;

        public MiCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Realiza una operación matemática con los parámetros recibidos.
        /// </summary>
        /// <param name="numeroUno">Primer operando.</param>
        /// <param name="numeroDos">Segundo operando.</param>
        /// <param name="operador">Operación a realizar.</param>
        /// <returns>Devuelve el resultado de la operación realizada.</returns>
        private double Operar(string numeroUno, string numeroDos, string operador)
        {
            Numero numeroA = new Numero(numeroUno);
            Numero numeroB = new Numero(numeroDos);
            return Calculadora.Operar(numeroA, numeroB, operador);
        }

        /// <summary>
        /// Liampia textBox, el comboBox y el Label.
        /// </summary>
        private void Limpiar()
        {
            LabelResultado.Text = "";
            PrimerNumero.Clear();
            SegundoNumero.Clear();
            Accion.SelectedIndex = -1;
        }

        /// <summary>
        /// Llama a la función "Operar" para realizar una operación matemática y devolver su resultado.
        /// Pone en false que sea la operación "Convertir a binario".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            LabelResultado.Text = Operar(PrimerNumero.Text, SegundoNumero.Text, Accion.Text).ToString();
            estaEnBinario = false;
        }

        /// <summary>
        /// Llama a un método para limpiar el formulario. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Llama a unmétodo para realizar una conversión de decimal a binario.
        /// Pone en true que sea la operación "Convertir a binario". 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!estaEnBinario && !(LabelResultado.Text == ""))
            {
                LabelResultado.Text = Entidades.Numero.DecimalBinario(LabelResultado.Text);
                estaEnBinario = true;
            }
        }

        /// <summary>
        /// Llama a unmétodo para realizar una conversión de binario a decimal.
        /// Pone en false que sea la operación "Convertir a binario".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (estaEnBinario && !(LabelResultado.Text == ""))
            {
                LabelResultado.Text = Entidades.Numero.BinarioDecimal(LabelResultado.Text);
                estaEnBinario = false;
            }
        }
    }
}
