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
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Devuelve el valor de todos los espacios modificables a su default.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "+";
            lblResultado.Text = "";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            double opResult = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            if(opResult == double.MinValue)
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

        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numeroBinario;
            numeroBinario = Numero.DecimalBinario(lblResultado.Text);
            lblResultado.Text = numeroBinario;
            if(lblResultado.Text != "Valor inválido.")
            {
                if (numeroBinario == double.MinValue.ToString())
                {
                    lblResultado.Text = "Valor inválido.";
                }
                else
                {
                    lblResultado.Text = numeroBinario;
                }
            }           
        }

        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numeroDecimal;
            numeroDecimal = Numero.BinarioDecimal(lblResultado.Text);
            if(lblResultado.Text != "Valor inválido.")
            {
                lblResultado.Text = numeroDecimal;
            }                    
        }
    }
}
