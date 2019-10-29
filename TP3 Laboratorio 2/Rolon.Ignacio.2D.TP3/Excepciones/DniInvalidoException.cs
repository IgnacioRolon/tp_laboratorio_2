using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;
        public DniInvalidoException()
            : base()
        {
            this.mensajeBase = "El DNI ingresado es invalido";
        }
        public DniInvalidoException(string message) 
            : base(message)
        {

        }
        public DniInvalidoException(string message, Exception e) 
            : base(message, e)
        {
            
        }

        public DniInvalidoException(Exception e)
            : base("", e) 
        {
            
        }
    }
}
