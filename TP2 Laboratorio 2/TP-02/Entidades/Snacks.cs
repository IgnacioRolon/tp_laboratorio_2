using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2019
{
    public class Snacks:Producto
    {
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
            sb.AppendFormat("Snacks - {0}, Calorias: {1}", base.Mostrar(), this.CantidadCalorias.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
    }
}
