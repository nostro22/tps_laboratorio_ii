using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3ClassLibrary
{
    public class ExcepcionArchivos:Exception
    {
        /// <summary>
        /// </summary>
        /// <param name="message">Mensaje que describe la causa de la excepcion</param>
        public ExcepcionArchivos(string message) : this(message, null)
        {
        }

        /// <summary> 
        /// </summary>
        /// <param name="message">Mensaje que describe el porque se produjo la excepcion</param>
        /// <param name="innerException"></param>
        public ExcepcionArchivos(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
