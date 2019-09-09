using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Laboratorio_2
{
    public static class Calculadora
    {
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
