using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    /// <summary>
    /// Clase para definir Jornadas universitarias, con su clase, profesor y lista de alumnos inscriptos. 
    /// </summary>
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Instancia una Jornada, inicializando la lista de Alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Instancia una jornada con su clase y profesor.
        /// </summary>
        /// <param name="clase">Clase que se dará en la Jornada</param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Guarda una jornada en un archivo de texto ubicado en Mis Documentos.
        /// </summary>
        /// <param name="jornada">Jornada a guardar en el archivo</param>
        /// <returns>Devuelve true si la Jornada fue guardada, o lanza ArchivosException si no se pudo.</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + @"\Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee la jornada guardada en Mis Documentos y la devuelve como string.
        /// </summary>
        /// <returns>Contenido de la Jornada como String.</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            texto.Leer(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + @"\Jornada.txt", out string jornadaActual);
            return jornadaActual;
        }

        /// <summary>
        /// Una jornada es igual a un alumno si existe dentro de su lista de alumnos.
        /// </summary>
        /// <param name="j">Jornada a Comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve true si el alumno existe en la lista, si no devuelve false.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Una jornada es igual a un alumno si existe dentro de su lista de alumnos.
        /// </summary>
        /// <param name="j">Jornada a Comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve false si el alumno existe en la lista, si no devuelve true.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada indicada, solo si no existe el alumno.
        /// </summary>
        /// <param name="j">Jornada a la cual se le agregará el Alumno.</param>
        /// <param name="a">Alumno a Agregar.</param>
        /// <returns>Devuelve la Jornada, ya sea que se le pudo agregar el alumno o no.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }            
            return j;
        }

        /// <summary>
        /// Devuelve los datos de la jornada.
        /// </summary>
        /// <returns>Devuelve los datos de la jornada.</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("CLASE DE {0} POR {1}", this.clase.ToString(), this.instructor.ToString());
            str.AppendLine("ALUMNOS:");
            foreach(Alumno alumno in this.alumnos)
            {
                str.AppendLine(alumno.ToString());
            }
            return str.ToString();
        }
    }
}
