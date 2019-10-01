using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2019
{
    public class Leche : Producto
    {
        public enum ETipo
        {
            Entera,
            Descremada
        }
        private ETipo tipo;

        /// <summary>
        /// Crea un objeto de tipo Leche. Por defecto, tipo será ENTERA
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="codigo">Codigo de Barras de la leche</param>
        /// <param name="color">Color del paquete de la leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
            this.tipo = ETipo.Entera;
        }

        /// <summary>
        /// Crea un objeto de tipo Leche con el tipo indicado.
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="codigo">Codigo de Barras de la leche</param>
        /// <param name="color">Color del paquete de la leche</param>
        /// <param name="tipo">Tipo de Leche (Entera o Descremada)</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Publica todos los datos de la Leche.
        /// </summary>
        /// <returns>Devuelve los datos como string.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Leche - {0}, Calorias: {1}, Tipo: {2}", base.Mostrar(), this.CantidadCalorias.ToString(), this.tipo.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
    }
}
