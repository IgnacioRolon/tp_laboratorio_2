using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using System.Threading;

namespace Clases_Instanciables
{
    public sealed class Profesor:Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;

        void _randomClases()
        {
            int randomValue;
            for (int i = 0; i < 2; i++)
            {
                randomValue = random.Next(0, 3);
                EClases bufferClase = (EClases)randomValue;
                clasesDelDia.Enqueue(bufferClase);
                Thread.Sleep(200);
            }
        }
        public Profesor()
          :base()
        {
        
        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<EClases>();
            _randomClases();
        }
            
        public static bool operator == (Profesor i, EClases clase)
        {
            foreach(EClases claseActual in i.clasesDelDia)
            {
                if(claseActual == clase)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator != (Profesor i, EClases clase)
        {
            return !(i == clase);
        }
       
        protected override string ParticiparEnClase()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("CLASES DEL DÍA:");
            foreach (EClases clase in this.clasesDelDia)
            {
                str.AppendLine(clase.ToString());
            }
            return str.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("{0}\n{1}\n", base.MostrarDatos(), this.ParticiparEnClase());
            return str.ToString();
        }

        public override string ToString()
        {            
            return this.MostrarDatos();
        }
    }
}
