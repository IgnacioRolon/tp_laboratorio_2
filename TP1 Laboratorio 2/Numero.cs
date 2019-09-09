using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Laboratorio_2
{
    class Numero
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
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

    }
}
