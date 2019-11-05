using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase Abstracta para definir todas las clases del tipo Persona
    /// </summary>
    public abstract class Persona
    { 
        /// <summary>
        /// Nacionalidades posibles de un DNI.
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        /// <summary>
        /// Guarda un String como DNI.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);                
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if(ValidarNombreApellido(value) != null)
                {
                    this.nombre = value;
                }                
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);                
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public Persona()
        {

        }

        /// <summary>
        /// Instancia un objeto de la clase persona, definiendo todos sus atributos menos el DNI.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero).</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
            this.Apellido = apellido;
        }

        /// <summary>
        /// Instancia un objeto de la clase persona, definiendo todos sus atributos.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero).</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
            this.Dni = dni;
            this.Apellido = apellido;
        }

        /// <summary>
        /// Instancia un objeto de la clase persona, definiendo todos sus atributos.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero).</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDNI = dni;            
        }

        /// <summary>
        /// Muestra los datos de la Persona.
        /// </summary>
        /// <returns>Datos de la Persona como String.</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("NOMBRE COMPLETO: {1}, {0}\nNACIONALIDAD: {2}\n", this.nombre, this.apellido, this.nacionalidad.ToString());
            return str.ToString();
        }

        /// <summary>
        /// Valida que el DNI sea valido, cumpliendo con las reglas de DNI Argentino.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        /// <param name="dato">DNI de la Persona.</param>
        /// <returns>Devuelve el DNi si es valido, si no lanza NacionalidadInvalidaException.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                return dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }

        /// <summary>
        /// Valida que el DNI como String sea valido.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        /// <param name="dato">DNI de la Persona.</param>
        /// <returns>Devuelve el DNI si es valido, si no lanza DniInvalidoException.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if(int.TryParse(dato, out int dni))
            {
                return ValidarDni(nacionalidad, dni);
            }else
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// Valida que el nombre o apellido sean valores validos para tales (no posean espacios y que sean letras).
        /// </summary>
        /// <param name="dato">Dato a validar.</param>
        /// <returns>Devuelve el nombre si es valido, o null si no.</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char item in dato)
            {
                if (!Char.IsLetter(item) || Char.IsWhiteSpace(item)) //Verifica que no haya espacios ni caracteres invalidos
                {
                    return null;
                }
            }
            return dato;
        }
    }
}
