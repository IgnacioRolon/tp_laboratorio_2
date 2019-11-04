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
        /// <summary>
        /// Posibles estados de cuenta universitaria.
        /// </summary>
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

        /// <summary>
        /// Crea un alumno con todos sus datos, menos el estado de la cuenta.
        /// </summary>
        /// <param name="id">Legajo del Alumno.</param>
        /// <param name="nombre">Nombre del Alumno.</param>
        /// <param name="apellido">Apellido del Alumno.</param>
        /// <param name="dni">DNI del Alumno.</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero) del Alumno.</param>
        /// <param name="claseQueToma">Clase que toma el Alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Crea un alumno con todos sus datos.
        /// </summary>
        /// <param name="id">Legajo del Alumno.</param>
        /// <param name="nombre">Nombre del Alumno.</param>
        /// <param name="apellido">Apellido del Alumno.</param>
        /// <param name="dni">DNI del Alumno.</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero) del Alumno.</param>
        /// <param name="claseQueToma">Clase que toma el Alumno.</param>
        /// <param name="estadoCuenta">Estado de la Cuenta con sus pagos.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Devuelve los datos del Alumno.
        /// </summary>
        /// <returns>Devuelve los datos del Alumno</returns>
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

        /// <summary>
        /// Un alumno es igual a una clase si la está dando y si no es Deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase con la que compara</param>
        /// <returns>Devuelve true si es igual, false si no.</returns>
        public static bool operator == (Alumno a, Universidad.EClases clase)
        {
            if(a != clase || a.estadoCuenta == EEstadoCuenta.Deudor)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Un alumno es igual a una clase si la está dando y si no es Deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase con la que compara</param>
        /// <returns>Devuelve false si es igual, true si no.</returns>
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

        /// <summary>
        /// Devuelve los datos del Alumno y los hace publicos.
        /// </summary>
        /// <returns>Devuelve los datos del Alumno.</returns>
        public override string ToString()
        {            
            return this.MostrarDatos();
        }
    }
}
