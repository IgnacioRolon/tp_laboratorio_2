using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    /// <summary>
    /// Clase que contiene toda la información de una central de correos con sus respectivos paquetes.
    /// </summary>
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Devuelve todos los paquetes del correo.
        /// </summary>
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

        /// <summary>
        /// Crea un nuevo correo.
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Le da fin a todas las entregas activas.
        /// </summary>
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

        /// <summary>
        /// Publica los datos del correo, con los datos y estado de todos sus paquetes.
        /// </summary>
        /// <param name="elemento">Correo a mostrar.</param>
        /// <returns>Datos del correo.</returns>
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

        /// <summary>
        /// Agrega un paquete a un correo.
        /// </summary>
        /// <param name="c">Correo al cual se le agregará</param>
        /// <param name="p">Paquete a agregar</param>
        /// <returns>Correo con el paquete agregado si se pudo agregar.</returns>
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
