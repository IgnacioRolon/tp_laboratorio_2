using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase Abstracta para los datos basicos de Universitarios.
    /// </summary>
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
            :base()
        {

        }
        /// <summary>
        /// Crea un universitario con todos sus datos.
        /// </summary>
        /// <param name="legajo">Legajo del Universitario</param>
        /// <param name="nombre">Nombre del Universitario</param>
        /// <param name="apellido">Apellido del Universitario</param>
        /// <param name="dni">DNI del Universitario</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero) del Universitario.</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Verifica si son del mismo tipo, y si lo son verifica que sean iguales.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>Devuelve true si son iguales, o false si no.</returns>
        public override bool Equals(object obj)
        {
            if(this.GetType() == obj.GetType())
            {
              return this == obj;
            }
            return false;
        }

        /// <summary>
        /// Un universitario es igual a otro si son del mismo tipo, y su legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">Primer Universitario a Comparar</param>
        /// <param name="pg2">Segundo Universitario a Comparar</param>
        /// <returns>Devuelve true si son iguales o false si no.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if(pg1.GetType() == pg2.GetType())
            {
                if (pg1.legajo == pg2.legajo || pg1.Dni == pg2.Dni)
                {
                    return true;
                }
            }            
            return false;
        }

        /// <summary>
        /// Un universitario es igual a otro si son del mismo tipo, y su legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">Primer Universitario a Comparar</param>
        /// <param name="pg2">Segundo Universitario a Comparar</param>
        /// <returns>Devuelve false si son iguales o true si no.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Agrega el legajo a los datos de una Persona, mostrando los datos de un universitario.
        /// </summary>
        /// <returns>Devuelve los datos completos.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("{0}\nLEGAJO NÚMERO: {1}\n", base.ToString(), this.legajo.ToString());
            return str.ToString();
        }

        protected abstract string ParticiparEnClase();


    }
}
