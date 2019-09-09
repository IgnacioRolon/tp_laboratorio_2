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
        public double ValidarNumero(string strNumero)
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
    }
}
