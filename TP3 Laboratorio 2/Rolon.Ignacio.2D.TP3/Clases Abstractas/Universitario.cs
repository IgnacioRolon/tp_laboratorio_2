using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
            :base()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        public override bool Equals(object obj)
        {
            if(obj is Universitario)
            {
                if((obj as Universitario) == this)
                {
                    return true;
                }
            }
            return false;
        }

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

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("{0}\nLEGAJO NÚMERO: {1}\n", base.ToString(), this.legajo.ToString());
            return str.ToString();
        }

        protected abstract string ParticiparEnClase();


    }
}
