using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    /// <summary>
    /// Dudas:
    /// @ Excepciones
    /// - Como se hacen y usan las excepciones (en este caso).
    /// @ Persona
    /// - Como hago correctamente las validaciones dentro de las propiedades (usando los metodos creados). 
    /// - ¿Como se yo cual es la nacionalidad en el contexto de la propiedad para usar los metodos ValidarDni?
    /// @ Profesor
    /// - ¿Como puedo reutilizar multiples constructores en un solo constructor? Como usar this() y despues base().
    /// - ¿Como puede ser que Profesor tiene dos constructores iguales con la unica diferencia siendo su visibilidad?
    /// - Si la corrección que hice esta bien, ¿que deberia hacer el constructor sin parametros?
    /// </summary>
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

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

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
            this.Apellido = apellido;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
            this.Dni = dni;
            this.Apellido = apellido;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
            StringToDNI = dni;            
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("NOMBRE COMPLETO: {0}, {1}\nNACIONALIDAD: {2}\n", this.nombre, this.apellido, this.nacionalidad.ToString());
            return str.ToString();
        }

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

        private string ValidarNombreApellido(string dato)
        {
            foreach (char item in dato)
            {
                if (!Char.IsLetter(item) || Char.IsWhiteSpace(item))
                {
                    return null;
                }
            }
            return dato;
        }
    }
}
