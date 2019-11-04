using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Threading;

namespace Clases_Instanciables
{
    /// <summary>
    /// Clase para definir a los profesores universitarios, con la clase que dan y sus datos.
    /// </summary>
    public sealed class Profesor:Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Genera una clase random de cualquiera de los 4 tipos de clase posibles.
        /// </summary>
        void _randomClases()
        {
            int randomValue;
            for (int i = 0; i < 2; i++)
            {
                randomValue = random.Next(0, 3);
                Universidad.EClases bufferClase = (Universidad.EClases)randomValue;
                clasesDelDia.Enqueue(bufferClase);
                Thread.Sleep(200);
            }
        }
        public Profesor()
          :base()
        {
        
        }

        /// <summary>
        /// Constructor estatico que inicializa el Random.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Crea un profesor con todos sus datos.
        /// </summary>
        /// <param name="id">Legajo del Profesor</param>
        /// <param name="nombre">Nombre del Profesor</param>
        /// <param name="apellido">Apellido del Profesor</param>
        /// <param name="dni">DNI del Profesor como String</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino o Extranjero) del Profesor.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
            
        /// <summary>
        /// Un profesor es igual a una clase si la está dando.
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a encontrar</param>
        /// <returns>Devuelve true si está dando la clase, o false si no.</returns>
        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            foreach(Universidad.EClases claseActual in i.clasesDelDia)
            {
                if(claseActual == clase)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Un profesor es igual a una clase si la está dando.
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a encontrar</param>
        /// <returns>Devuelve false si está dando la clase, o true si no.</returns>
        public static bool operator != (Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
       
        /// <summary>
        /// Muestra en que clases participa el Profesor.
        /// </summary>
        /// <returns>Clases como String.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                str.AppendLine(clase.ToString());
            }
            return str.ToString();
        }

        /// <summary>
        /// Devuelve los datos del profesor, incluyendo las clases en las que participa.
        /// </summary>
        /// <returns>Datos del Profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("{0}{1}\n", base.MostrarDatos(), this.ParticiparEnClase());
            return str.ToString();
        }

        /// <summary>
        /// Muestra los datos del profesor.
        /// </summary>
        /// <returns>Datos del Profesor.</returns>
        public override string ToString()
        {            
            return this.MostrarDatos();
        }
    }
}
