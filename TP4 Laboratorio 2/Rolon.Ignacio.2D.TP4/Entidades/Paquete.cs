using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs estado);
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformaEstado;

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }

        public void MockCicloDeVida()
        {
            while(this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                switch(this.estado)
                {
                    case EEstado.Ingresado:
                        this.estado = EEstado.EnViaje;
                        break;
                    case EEstado.EnViaje:
                        this.estado = EEstado.Entregado;
                        break;
                }

                this.InformaEstado.Invoke(this.estado, EventArgs.Empty);
            }

            PaqueteDAO.Insertar(this);
        }

        public string MostrarDatos(Paquete elemento) //Revisar como hacerlo con IMostrar<Paquete>
        {
            return string.Format("{0} para {1}", elemento.trackingID, elemento.direccionEntrega);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if(p1.trackingID == p2.trackingID)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }
    }
}
