using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Laboratorio_2
{
    public class Numero
    {
        private double numero;
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        /// <summary>
        /// Valida que el numero (ingresado como string) sea double y lo transforma.
        /// </summary>
        /// <param name="strNumero">Numero como String</param>
        /// <returns>Devuelve el numero como Double si es valido, y devuelve 0 si no es posible transformarlo.</returns>
        private double ValidarNumero(string strNumero)
        {
            double localNum;
            if(double.TryParse(strNumero, out localNum))
            {
                return localNum;
            }
            else
            {
                return 0;
            }
        }
        
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
        /// <summary>
        /// Transforma el numero de Decimal a Binario, validando que sea un numero posible de transformar a binario. No
        /// permite que se transforme un numero binario nuevamente para evitar que se sobrepase el limite facilmente.
        /// </summary>
        /// <param name="numero">Numero como double</param>
        /// <returns>Devuelve el numero como binario si se pudo completar correctamente, o "Valor invalido." si no se pudo.</returns>
        public static string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }
        /// <summary>
        /// Sobrecarga de la función DecimalBinario.
        /// </summary>
        /// <param name="numero">Numero como String</param>
        /// <returns>Devuelve el numero como binario si se pudo completar correctamente, o "Valor invalido." si no se pudo.</returns>
        public static string DecimalBinario(string numero)
        {
            string binaryNumber;
            if (double.TryParse(numero, out double doubleNumber))
            {
                long intNumber = Convert.ToInt64(doubleNumber); //Se transforma a numero entero
                string checkNumber = BinarioDecimal(numero); //Si se puede formatear BinarioDecimal, no se puede formatear DecimalBinario.
                if(checkNumber == "Valor invalido.") //Si BinarioDecimal devuelve el minValue, entonces el numero está en decimal y se puede convertir a Binario.
                {
                    if (intNumber >= 0) //Si es negativo, se borra el numero negativo.
                    {
                        numero = intNumber.ToString();
                    }
                    else
                    {
                        numero = intNumber.ToString().Remove(0, 1);
                    }
                    try
                    {
                        binaryNumber = Convert.ToString(Convert.ToByte(numero), 2);
                        return binaryNumber;
                    }
                    catch (System.OverflowException) //Si el numero supera el maximo posible en una variable tipo Byte, se lanza esta excepción
                    {
                        return "Valor invalido."; //Como siempre, si hay error devolvemos "Valor invalido."
                    }                   
                }
            }
            return "Valor invalido."; //Si no es convertible, se devuelve "Valor invalido.".
        }
        /// <summary>
        /// Transforma el numero de Binario a Decimal, validando que sea un numero posible de transformar a decimal.
        /// </summary>
        /// <param name="numero">Numero como String</param>
        /// <returns>Devuelve el numero como decimal si se pudo completar correctamente, o "Valor invalido." si no se pudo.</returns>
        public static string BinarioDecimal(string numero)
        {
            if(numero != "" && numero[0] != '-')
            {
                try
                {       
                    return Convert.ToInt64(numero, 2).ToString();
                }
                catch (System.FormatException) //Lanza esta excepción si el texto no está en formato binario
                {                    
                    return "Valor invalido."; //Si salta la excepción, se devuelve "Valor invalido.".
                }
            }     
            return "Valor invalido."; //Si el numero esta vacio o es negativo, devuelve "Valor invalido.".
        }
    }
}
