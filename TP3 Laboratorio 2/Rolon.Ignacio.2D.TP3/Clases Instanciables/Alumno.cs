using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public enum EEstadoCuenta
    {
        AlDia,
        Deudor,
        Becado
    }
    public sealed class Alumno : Universitario 
    {
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
            :base()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("{0}\nESTADO DE CUENTA: {1}\n{2}\n", base.MostrarDatos(), this.estadoCuenta.ToString(), this.ParticiparEnClase());
            return base.MostrarDatos();
        }

        public static bool operator == (Alumno a, EClases clase)
        {
            if(a != clase || a.estadoCuenta == EEstadoCuenta.Deudor)
            {
                return false;
            }
            return true;
        }

        public static bool operator != (Alumno a, EClases clase)
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
            str.AppendFormat("TOMA CLASES DE: {0}", this.claseQueToma.ToString());
            return str.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
