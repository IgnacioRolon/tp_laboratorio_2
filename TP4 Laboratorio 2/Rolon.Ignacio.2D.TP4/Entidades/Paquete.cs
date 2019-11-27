using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    /// <summary>
    /// Clase para definir un paquete y todos sus atributos.
    /// </summary>
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs estado);

        /// <summary>
        /// Enumerable para los posibles estados de un paquete.
        /// </summary>
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

        /// <summary>
        /// Devuelve la dirección de entrega del paquete.
        /// </summary>
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

        /// <summary>
        /// Devuelve el estado actual del paquete.
        /// </summary>
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

        /// <summary>
        /// Devuelve el Tracking ID (identificador único) del paquete.
        /// </summary>
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

        /// <summary>
        /// Crea un nuevo paquete.
        /// </summary>
        /// <param name="direccionEntrega">Dirección de entrega del paquete.</param>
        /// <param name="trackingID">Tracking ID (identificador único) del paquete.</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Simula el ciclo de vida de un paquete, cambiado su estado desde el inicio del viaje hasta entregado,
        /// lanzando un evento ante cada cambio e insertandolo en la base de datos al finalizar.
        /// </summary>
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

        /// <summary>
        /// Publica los datos del paquete en formato string.
        /// </summary>
        /// <param name="elemento">Paquete a mostrar datos.</param>
        /// <returns>Datos del paquete.</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento) 
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}\n", p.trackingID, p.direccionEntrega);
        }

        /// <summary>
        /// Iguala dos paquetes, siendo que son iguales si su trackingID es el mismo.
        /// </summary>
        /// <param name="p1">Primer paquete a comparar</param>
        /// <param name="p2">Segundo paquete a comparar</param>
        /// <returns>Devuelve true si son iguales o false si no.</returns>
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

        /// <summary>
        /// Iguala dos paquetes, siendo que son iguales si su trackingID es el mismo.
        /// </summary>
        /// <param name="p1">Primer paquete a comparar</param>
        /// <param name="p2">Segundo paquete a comparar</param>
        /// <returns>Devuelve false si son iguales o true si no.</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Muestra los datos del paquete, convirtiendolo a string.
        /// </summary>
        /// <returns>Datos del paquete.</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
    }
}
