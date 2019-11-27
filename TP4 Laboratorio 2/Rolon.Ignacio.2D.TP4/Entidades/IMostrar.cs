using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz generica para definir la publicacion de datos.
    /// </summary>
    /// <typeparam name="T">Tipo de dato a publicar.</typeparam>
    public interface IMostrar<T> where T : class
    {
        string MostrarDatos(IMostrar<T> elemento);
    }
}
