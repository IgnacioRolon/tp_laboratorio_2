using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{    
    /// <summary>
    /// Clase para guardar los datos de una Universidad.
    /// </summary>
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }


        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }


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

        public Jornada this[int i]
        {
            get
            {
                return this.jornada.ElementAt(i);
            }
            set
            {
                this.jornada.Insert(i, value);  
            }
        }
        /// <summary>
        /// Crea una universidad, inicializando todos sus atributos.
        /// </summary>
        public Universidad()
        {
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Muestra los datos de la universidad, mostrando que se da en cada Jornada.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("JORNADA:");
            foreach(Jornada item in uni.jornada)
            {
                str.Append(item.ToString());
                str.AppendLine("<---------------------------------------------------->\n");
            }
            return str.ToString();
        }

        /// <summary>
        /// Devuelve los datos de la universidad.
        /// </summary>
        /// <returns>Datos de la Universidad.</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Un alumno es igual a una universidad si el alumno está en la misma.
        /// </summary>
        /// <param name="g">Universidad a Comparar</param>
        /// <param name="a">Alumno a Comparar</param>
        /// <returns>Devuelve true si el alumno´está en la Universidad, o false si no.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach(Alumno item in g.alumnos)
            {
                if(item == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Un alumno es igual a una universidad si el alumno está en la misma.
        /// </summary>
        /// <param name="g">Universidad a Comparar</param>
        /// <param name="a">Alumno a Comparar</param>
        /// <returns>Devuelve false si el alumno´está en la Universidad, o true si no.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un profesor es igual a una universidad si el profesor está en la misma.
        /// </summary>
        /// <param name="g">Universidad a Comparar</param>
        /// <param name="i">Profesor a Comparar</param>
        /// <returns>Devuelve true si el profesor´está en la Universidad, o false si no.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Un profesor es igual a una universidad si el profesor está en la misma.
        /// </summary>
        /// <param name="g">Universidad a Comparar</param>
        /// <param name="i">Profesor a Comparar</param>
        /// <returns>Devuelve false si el profesor´está en la Universidad, o true si no.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Una universidad es igual a una clase si hay algun profesor dandola.
        /// </summary>
        /// <param name="g">Universidad a Comparar</param>
        /// <param name="clase">Clase a Comparar</param>
        /// <returns>Devuelve el profesor que la está dando si lo hay, y si no lanza SinProfesorException.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {            
            foreach (Profesor item in u.profesores)
            {
                if(item == clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Una universidad es igual a una clase si hay algun profesor dandola.
        /// </summary>
        /// <param name="g">Universidad a Comparar</param>
        /// <param name="clase">Clase a Comparar</param>
        /// <returns>Devuelve el primer profesor no que la está dando si lo hay, y si no devuelve null.</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {            
            foreach (Profesor item in u.profesores)
            {
                if(item != clase)
                {
                    return item;
                }
            }
            return null;
        }
        
        /// <summary>
        /// Agrega una clase a la universidad, asignando una Jornada para la misma, con su profesor y alumnos correspondientes.
        /// </summary>
        /// <param name="g">Universidad a la cual se le agregará.</param>
        /// <param name="clase">Clase a Agregar</param>
        /// <returns>Devuelve la universidad a la cual se le agregó la clase.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = new Profesor();
            profesor = (g == clase);
            Jornada nuevaJornada = new Jornada(clase, profesor);
            foreach(Alumno item in g.alumnos)
            {
                if(item == clase)
                {
                    nuevaJornada.Alumnos.Add(item);
                }
            }
            g.jornada.Add(nuevaJornada);
            return g;
        }

        /// <summary>
        /// Añade un alumno a la universidad si no existe en la misma.
        /// </summary>
        /// <param name="u">Universidad a la cual se le agregará.</param>
        /// <param name="a">Alumno a agregar.</param>
        /// <returns>Devuelve la universidad con el alumno agregado si se agregó, o lanza AlumnoRepetidoException si no.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            foreach(Alumno item in u.alumnos)
            {
                if(item == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }
            u.alumnos.Add(a);
            return u;
        }

        /// <summary>
        /// Agrega un profesor a la universidad si no existe en la misma.
        /// </summary>
        /// <param name="u">Universidad a la cual se le agregará.</param>
        /// <param name="i">Profesor a agregar./param>
        /// <returns>Devuelve la universidad, con el profesor agregado (si se pudo agregar) o no.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            foreach(Profesor item in u.profesores)
            {
                if(item == i)
                {
                    return u;
                }
            }
            u.profesores.Add(i);
            return u;
        }

        /// <summary>
        /// Guarda la Universidad en un archivo XML, con destino a la carpeta Mis Documentos.
        /// </summary>
        /// <param name="uni">Universidad a Guardar.</param>
        /// <returns>Devuelve True si se pudo guardar, o lanza ArchivosException si no se pudo.</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Lee la Universidad guardada en un archivo XML.
        /// </summary>
        /// <param name="uni">Universidad a Leer.</param>
        /// <returns>Devuelve True si se pudo leer, o lanza ArchivosException si no se pudo.</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();  
            Universidad universidad = new Universidad();
            xml.Leer("Universidad.xml", out universidad);
            return universidad;
        }
    } 
}
