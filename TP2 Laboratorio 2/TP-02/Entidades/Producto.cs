using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2019
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// Crea un objeto de tipo Producto.
        /// </summary>
        /// <param name="codigo">Codigo de Barras</param>
        /// <param name="marca">Marca del Producto</param>
        /// <param name="color">Color del Paquete</param>
        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = codigo;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de Calorias del producto.
        /// </summary>
        protected abstract short CantidadCalorias
        {
            get;
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>Devuelve los datos como string.</returns>
        public virtual string Mostrar()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("Marca: {0}, Codigo de Barras: {1}, Color del Empaque: {2}", this.marca.ToString(), this.codigoDeBarras.ToString(), this.colorPrimarioEmpaque.ToString());
            return str.ToString();
        }


        /// <summary>
        /// Castea producto a string, devolviendo sus datos como string
        /// </summary>
        /// <param name="producto">Producto a castear a string</param>
        public static explicit operator string(Producto producto)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(producto.Mostrar());
            sb.AppendLine("---------------------");
            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras. 
        /// </summary>
        /// <param name="producto1">Primer Producto a comparar</param>
        /// <param name="producto2">Segundo Producto a comparar</param>
        /// <returns>Devuelve el resultado de la igualdad.</returns>
        public static bool operator ==(Producto producto1, Producto producto2)
        {
            return producto1.codigoDeBarras == producto2.codigoDeBarras;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto.
        /// </summary>
        /// <param name="producto1">Primer Producto a comparar</param>
        /// <param name="producto2">Segundo Producto a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Producto producto1, Producto producto2)
        {
            return producto1 == producto2;
        }

    }
}
