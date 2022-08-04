using System;
using System.IO;

namespace IO
{
    public abstract class Archivo
    {
        //Properties

        protected abstract string Extension {get; }


        public bool ValidarSiExisteElArchivo(string ruta)
        {
            if (!File.Exists(ruta))
            {
                throw new ArchivoIncorrectoException($"El archivo no se encontro");
            }
            return true;
        }
        public bool ValidarExtension(string ruta)
        {
            if (Path.GetExtension(ruta) != Extension)
            {           
                throw new ArchivoIncorrectoException($"El archivo no tiene la extension {Extension}");
            }
            return true;
        }
    }

    public class ArchivoIncorrectoException : Exception
    {

        public  ArchivoIncorrectoException(string mensaje) : base(mensaje) { }
    }


}
