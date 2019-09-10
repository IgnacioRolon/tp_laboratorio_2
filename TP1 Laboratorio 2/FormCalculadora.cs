using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_Laboratorio_2
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Inicializa el formulario principal de la calculadora
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Al presionar, ejecuta el metodo Limpiar que vacia el contenido de todos los controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Devuelve el valor de todos los espacios modificables a su default.
        /// </summary>
        private void Limpiar()
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Clear();
                }
                else if (item is ComboBox)
                {
                    (item as ComboBox).SelectedIndex = 0;
                }else if (item is Label)
                {
                    (item as Label).Text = "";
                }
            }
        }

        /// <summary>
        /// Al presionar el boton Cerrar se finaliza la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Realiza la operación designada entre los dos numeros en los TextBox. 
        /// Si recibe MinValue significa que la división fue por cero, y cambia ese valor por un mensaje de error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            double opResult = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            if (opResult == double.MinValue)
            {
                lblResultado.Text = "Error: No se puede dividir por cero.";
            }
            else
            {
                lblResultado.Text = opResult.ToString();
            }
        }

        /// <summary>
        /// Realiza la operación indicada entre los dos numeros ingresados.
        /// </summary>
        /// <param name="numero1">Primer numero a participar de la operación</param>
        /// <param name="numero2">Segundo numero a participar de la operación</param>
        /// <param name="operador">Operador de la cuenta elegido</param>
        /// <returns>Devuelve el resultado del calculo realizado.</returns>
        private double Operar(string numero1, string numero2, string operador)
        {
            Numero primerNumero = new Numero(numero1);
            Numero segundoNumero = new Numero(numero2);

            double resultadoFinal = Calculadora.Operar(primerNumero, segundoNumero, operador);
            return resultadoFinal;
        }

        /// <summary>
        /// Llama al metodo DecimalBinario de la clase Numero para transformar el numero en Binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numeroBinario;
            numeroBinario = Numero.DecimalBinario(lblResultado.Text);
            lblResultado.Text = numeroBinario;
        }

        /// <summary>
        /// Llama al metodo BinarioDecimal de la clase Numero para transformar el numero en Decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numeroDecimal;
            numeroDecimal = Numero.BinarioDecimal(lblResultado.Text);
            lblResultado.Text = numeroDecimal;
        }
    }
}