using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz para las funciones basicas de Lectura y Escritura de Archivos para cualquier tipo de archivo.
    /// </summary>
    /// <typeparam name="T">Tipo de Objeto a guardar/leer.</typeparam>
    public interface IArchivo<T> where T : class
    {
        bool Guardar(string archivo, T datos);
        bool Leer(string archivo, out T datos);
    }
}
