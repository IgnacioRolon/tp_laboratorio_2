using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase con funciones de Lectura y Escritura de Archivos de Texto.
    /// </summary>
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda el String enviado a un archivo en el Destino indicado.
        /// </summary>
        /// <param name="archivo">Path/Destino del archivo (ruta completa).</param>
        /// <param name="datos">String de datos a guardar en el archivo.</param>
        /// <returns>Devuelve true si se pudo guardar, o lanza ArchivosException si hubo un error.</returns>
        public bool Guardar(string archivo, string datos)
        {           
            try
            {
                StreamWriter writer = new StreamWriter(archivo);
                writer.Write(datos);
                writer.Close();
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);                
            }
            return true;
        }
        /// <summary>
        /// Lee el contenido de un archivo en el path indicado y lo guarda en el parametro Datos.
        /// </summary>
        /// <param name="archivo">Path/Destino del archivo (ruta completa).</param>
        /// <param name="datos">String donde se van a guardar los datos del archivo.</param>
        /// <returns>Devuelve true si se pudo leer, o lanza ArchivosException si hubo un error.</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader reader = new StreamReader(archivo);
                datos = reader.ReadToEnd();
                reader.Close();
            }catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
    }
}
