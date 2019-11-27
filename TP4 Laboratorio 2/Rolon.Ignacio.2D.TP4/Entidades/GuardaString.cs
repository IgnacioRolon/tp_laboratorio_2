using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    /// <summary>
    /// Clase para extender la clase String.
    /// </summary>
    public static class GuardaString
    {
        /// <summary>
        /// Guarda el string en un archivo de texto en el escritorio con el nombre indicado, agregando nueva información al final del archivo.
        /// </summary>
        /// <param name="texto">String a guardar en el escritorio.</param>
        /// <param name="archivo">Nombre del archivo donde se guardará.</param>
        /// <returns>Devuelve true si salió bien, o lanza una excepción si no.</returns>
        public static bool Guardar(this String texto, string archivo)
        {
            StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true);
            writer.Write(texto);
            writer.Close();
            return true;
        }
    }
}
