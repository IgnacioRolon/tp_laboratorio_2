using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Dudas:
    /// @ General
    /// - En el main pasado dice que el proyecto se llama EntidadesAbstractas, pero en el ejercicio pide que se llame
    /// Clases Abstractas, ¿se modifica el main o el namespace?
    /// @ Archivos
    /// - ¿No tendria mas sentido que los metodos de los archivos sean estaticos?
    /// - El archivo tiene el mismo encoding pero no deja salto de linea como cualquier archivo XML (contando el entregado
    /// como ejemplo). ¿Por que?
    /// @ Tests Unitarios
    /// - Aclarar como deberian hacerse, ¿a que se refiere con validar valor numerico?
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
            str.AppendFormat("NOMBRE COMPLETO: {1}, {0}\nNACIONALIDAD: {2}\n", this.nombre, this.apellido, this.nacionalidad.ToString());
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
                if (!Char.IsLetter(item) || Char.IsWhiteSpace(item)) //Verifica que no haya espacios ni caracteres invalidos
                {
                    return null;
                }
            }
            return dato;
        }
    }
}
