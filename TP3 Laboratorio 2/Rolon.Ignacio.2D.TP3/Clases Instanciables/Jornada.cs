using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clase;
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

        public EClases Clase
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

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + @"\Jornada.txt", jornada.ToString());
        }

        public static string Leer()
        {
            Texto texto = new Texto();
            texto.Leer(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString() + @"\Jornada.txt", out string jornadaActual);
            return jornadaActual;
        }

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

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }            
            return j;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("CLASE DE {0} POR: {1}\n", this.clase.ToString(), this.instructor.ToString());
            str.AppendLine("ALUMNOS:");
            foreach(Alumno alumno in this.alumnos)
            {
                str.AppendLine(alumno.ToString());
            }
            return str.ToString();
        }
    }
}
