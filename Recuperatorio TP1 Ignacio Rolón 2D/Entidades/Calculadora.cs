using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operación entre dos objetos de tipo Numero.
        /// </summary>
        /// <param name="num1">Primer numero a operar.</param>
        /// <param name="num2">Segundo numero a operar.</param>
        /// <param name="operador">Operador a utilizar.</param>
        /// <returns>Devuelve el resultado del calculo.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            switch(operador)
            {
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default:
                    return num1 + num2;
            }
        }

        /// <summary>
        /// Valida que el operador sea valido.
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Devuelve el operador validado, y si es erroneo devuelve +.</returns>
        public static string ValidarOperador(string operador)
        {
            switch(operador)
            {
                case "-":
                    return "-";
                case "*":
                    return "*";
                case "/":
                    return "/";
                default:
                    return "+";
            }
        }
    }
}
