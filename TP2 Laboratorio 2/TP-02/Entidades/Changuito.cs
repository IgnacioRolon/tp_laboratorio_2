using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2019
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Changuito
    {
        private List<Producto> productos;
        private int espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible)
            :this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestra el Changuito y TODOS los Productos dentro del mismo.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido (especificado como parametro).
        /// </summary>
        /// <param name="chango">Elemento a exponer</param>
        /// <param name="tipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Devuelve el contenido requerido como string.</returns>
        public static string Mostrar(Changuito chango, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", chango.productos.Count, chango.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto producto in chango.productos)
            {
                if(tipo == ETipo.Todos)
                {
                    sb.AppendLine(producto.Mostrar());
                }else if(tipo.ToString() == producto.GetType().Name)
                {
                    sb.AppendLine(producto.Mostrar());
                }
                
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará el elemento a la lista indicado con el operador +. No se agregará si ya existe.
        /// </summary>
        /// <param name="chango">Objeto donde se agregará el elemento</param>
        /// <param name="producto">Objeto a agregar</param>
        /// <returns>Devuelve el Changuito cambiado</returns>
        public static Changuito operator +(Changuito chango, Producto producto)
        {
            if(chango.productos.Count < chango.espacioDisponible)
            {
                foreach (Producto item in chango.productos)
                {
                    if (item == producto)
                        return chango;
                }
                chango.productos.Add(producto);
            }      
            return chango;
        }
        /// <summary>
        /// Quitará el elemento de la lista indicado con el operador -
        /// </summary>
        /// <param name="chango">Objeto donde se quitará el elemento</param>
        /// <param name="producto">Objeto a quitar</param>
        /// <returns>Devuelve el Changuito cambiado</returns>
        public static Changuito operator -(Changuito chango, Producto producto)
        {
            foreach (Producto item in chango.productos)
            {
                if (item == producto)
                {
                    chango.productos.Remove(producto);
                    break;
                }
            }
            return chango;
        }
        #endregion
    }
}
