using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Laboratorio_2
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operación indicada entre dos objetos de tipo Numero.
        /// </summary>
        /// <param name="num1">Primer numero de la operación</param>
        /// <param name="num2">Segundo numero de la operación</param>
        /// <param name="operador">Operador entre ambos numeros.</param>
        /// <returns>Devuelve el resultado de la operación.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            operador = ValidarOperador(operador);
            switch(operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
        /// <summary>
        /// Valida que el operador sea una de las funciones basicas (+, -, * y /)
        /// </summary>
        /// <param name="operador">Operador como String</param>
        /// <returns>Devuelve el operador que se ingreso. Si el operador es invalido se devuelve +.</returns>
        private static string ValidarOperador(string operador)
        {
            if(operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                return "+";
            }
            else
            {
                return operador;
            }
            
        }
    }
}
