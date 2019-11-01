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
    public class Xml<T> : IArchivo<T> where T : class
    {
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
