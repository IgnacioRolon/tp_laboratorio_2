using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    
    public sealed class Alumno : Universitario 
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
            :base()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();
            string estadoCuenta = "";
            switch(this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    estadoCuenta = "Cuota al día";
                    break;
                case EEstadoCuenta.Becado:
                    estadoCuenta = "Becado";
                    break;
                case EEstadoCuenta.Deudor:
                    estadoCuenta = "Debe cuotas";
                    break;
            }
            str.AppendFormat("{0}\nESTADO DE CUENTA: {1}{2}", base.MostrarDatos(), estadoCuenta, this.ParticiparEnClase());
            return str.ToString();
        }

        public static bool operator == (Alumno a, Universidad.EClases clase)
        {
            if(a != clase || a.estadoCuenta == EEstadoCuenta.Deudor)
            {
                return false;
            }
            return true;
        }

        public static bool operator != (Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma != clase)
            {
                return true;
            }
            return false;
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("\nTOMA CLASES DE: {0}", this.claseQueToma.ToString());
            return str.ToString();
        }

        public override string ToString()
        {            
            return this.MostrarDatos();
        }
    }
}
