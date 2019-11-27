using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Crea un nuevo numero.
        /// </summary>
        /// <param name="strNumero">Numero a crear como string.</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Crea un nuevo numero.
        /// </summary>
        /// <param name="numero">Numero a crear como double.</param>
        public Numero(double numero)
            :this(numero.ToString())
        {

        }
        
        /// <summary>
        /// Crea un nuevo numero, indicando su valor como cero.
        /// </summary>
        public Numero()
            :this(0)
        {
            
        }

        /// <summary>
        /// Valida que el numero ingresado como string sea un numero, y lo devuelve.
        /// </summary>
        /// <param name="strNumero">Numero como string.</param>
        /// <returns>Devuelve el numero si pudo ser formateado, o 0 si no se pudo.</returns>
        public double ValidarNumero(string strNumero)
        {
            if(double.TryParse(strNumero, out double value))
            {
                return value;
            }
            return 0;
        }

        /// <summary>
        /// Suma el valor de dos numeros.
        /// </summary>
        /// <param name="n1">Numero 1 a operar</param>
        /// <param name="n2">Numero 2 a operar</param>
        /// <returns>Resultado del calculo.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta el valor de dos numeros.
        /// </summary>
        /// <param name="n1">Numero 1 a operar</param>
        /// <param name="n2">Numero 2 a operar</param>
        /// <returns>Resultado del calculo.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica el valor de dos numeros.
        /// </summary>
        /// <param name="n1">Numero 1 a operar</param>
        /// <param name="n2">Numero 2 a operar</param>
        /// <returns>Resultado del calculo.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide el valor de dos numeros.
        /// </summary>
        /// <param name="n1">Numero 1 a operar</param>
        /// <param name="n2">Numero 2 a operar</param>
        /// <returns>Resultado del calculo. Si se divide por cero devuelve double.minValue.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            return double.MinValue;
        }

        /// <summary>
        /// Transforma el string ingresado (numero binario) a decimal.
        /// </summary>
        /// <param name="binario">Numero binario como string.</param>
        /// <returns>Devuelve el valor como binario, o "valor invalido." si falló.</returns>
        public string BinarioDecimal(string binario)
        {
            if (binario != "" && binario[0] != '-')
            {
                try
                {
                    return Convert.ToInt64(binario, 2).ToString();
                }
                catch (Exception ex)
                {
                    return "Valor invalido."; //Si salta una excepción, se devuelve "Valor invalido.".
                }
            }
            return "Valor invalido."; //Si el numero esta vacio o es negativo, devuelve "Valor invalido.".
        }

        /// <summary>
        /// Transforma el string ingresado (numero decimal) a binario.
        /// </summary>
        /// <param name="numero">Numero decimal como string.</param>
        /// <returns>Devuelve el valor como decimal, o "valor invalido" si no se pudo.</returns>
        public string DecimalBinario(string numero)
        {
            string binaryNumber;
            if(double.TryParse(numero, out double doubleNumber))
            {
                long longNumber = Convert.ToInt64(doubleNumber); //Se transforma a numero entero
                numero = longNumber.ToString();
                try
                {
                    binaryNumber = Convert.ToString(Convert.ToByte(numero), 2);
                    return binaryNumber;
                }
                catch (Exception ex) //Si hay alguna excepcion, devuelve el valor de error.
                {
                    return "Valor invalido."; //Como siempre, si hay error devolvemos "Valor invalido."
                }
            }
            return "Valor invalido.";
        }

        /// <summary>
        /// Transforma el numero decimal ingresado a binario.
        /// </summary>
        /// <param name="numero">Numero decimal a convertir.</param>
        /// <returns>Devuelve el valor como decimal, o "valor invalido" si no se pudo.</returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }
    }
}
