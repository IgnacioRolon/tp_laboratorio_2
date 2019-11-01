using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{    
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

        public Universidad()
        {
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
            this.alumnos = new List<Alumno>();
        }

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

        public override string ToString()
        {
            return MostrarDatos(this);
        }

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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        
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

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + @"\Universidad.xml", uni);
        }

        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();  
            Universidad universidad = new Universidad();
            xml.Leer(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + @"\Universidad.xml", out universidad);
            return universidad;
        }
    } 
}
