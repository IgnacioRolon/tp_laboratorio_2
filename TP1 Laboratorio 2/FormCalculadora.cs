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
        private double Operar(string numero1, string numero2, string operador)
        {
            Numero primerNumero = new Numero(numero1);
            Numero segundoNumero = new Numero(numero2);

            double resultadoFinal = Calculadora.Operar(primerNumero, segundoNumero, operador);
            return resultadoFinal;
        }
    }
}
