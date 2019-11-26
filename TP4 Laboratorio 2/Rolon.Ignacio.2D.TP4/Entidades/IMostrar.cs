using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T> where T : class
    {
        string MostrarDatos(IMostrar<T> elemento); //Cambiar o Revisar con el profe como hacer con IMostrar<T>
    }
}
