using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase con funciones de Lectura y Escritura de Archivos XML
    /// </summary>
    /// <typeparam name="T">Tipo de objeto a guardar en el archivo.</typeparam>
    public class Xml<T> : IArchivo<T> where T : class
    {
        /// <summary>
        /// Guarda el objeto enviado a un archivo en el Destino indicado.
        /// </summary>
        /// <param name="archivo">Path/Destino del archivo (ruta completa).</param>
        /// <param name="datos">Objeto a guardar en el archivo.</param>
        /// <returns>Devuelve true si se pudo guardar, o lanza ArchivosException si hubo un error.</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlTextWriter writer;
                XmlSerializer serializer;

                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);
                writer.Close();
            }catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return true;
        }
        /// <summary>
        /// Lee el contenido de un archivo XML y lo guarda en un objeto.
        /// </summary>
        /// <param name="archivo">Path/Destino del archivo (ruta completa).</param>
        /// <param name="datos">Objeto a leer del archivo.</param>
        /// <returns>Devuelve true si se pudo leer, o lanza ArchivosException si hubo un error.</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlTextReader reader;
                XmlSerializer serializer;
                
                reader = new XmlTextReader(archivo);
                serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(reader);
                reader.Close();
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            
            return true;
        }
    }
}
