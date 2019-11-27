using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {
            foreach(Thread ciclo in this.mockPaquetes)
            {
                if(ciclo.IsAlive)
                {
                    ciclo.Abort();
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elemento) //Arreglar
        {
          Correo correoLocal = (Correo)elemento;
          string datosCompletos = "";
          foreach(Paquete p in correoLocal.Paquetes)
          {
            datosCompletos += string.Format("{0} para {1} ({2}) \n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
          }
          return datosCompletos;
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete paquete in c.paquetes)
            {
                if(paquete == p)
                {
                    throw new TrackingIdRepetidoException("Paquete repetido.");
                }
            }
            c.paquetes.Add(p);
            Thread ciclo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(ciclo);
            ciclo.Start();
            return c;
        }
    }
}
