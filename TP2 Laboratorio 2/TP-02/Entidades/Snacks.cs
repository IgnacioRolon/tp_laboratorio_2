using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2019
{
    public class Snacks:Producto
    {
        /// <summary>
        /// Crea un objeto de tipo Snacks.
        /// </summary>
        /// <param name="marca">Marca del Snack</param>
        /// <param name="codigo">Codigo de Barras</param>
        /// <param name="color">Color del Paquete</param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {

        }
        /// <summary>
        /// Devuelve las calorias del Snack. Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        /// <summary>
        /// Publica todos los datos del Snack.
        /// </summary>
        /// <returns>Devuelve los datos como string.</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("---------------------");
            sb.AppendLine("");
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
