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

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        public string MostrarDatos(List<Paquete> elemento)
        {
            StringBuilder str = new StringBuilder();
            foreach(Paquete paquete in elemento)
            {
                str.AppendLine(string.Format("{0} para {1} ({2})", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString()));
            }
            return str.ToString();
        }
    }
}
