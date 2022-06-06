﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace IO
{
    public class puntoJson<T> : Archivo, IArchivo<T>
        where T : class
    {
        
        protected override string Extension
        {
            get
            {
                return ".json";
            }
        }

        public void Guardar(string ruta, T contenido)
        {
            if (ValidarSiExisteElArchivo(ruta) && ValidarExtension(ruta))
            {
                Serializar(ruta, contenido);
            }
        }

        public void GuardarComo(string ruta, T contenido)
        {
            if (ValidarExtension(ruta))
            {
                Serializar(ruta, contenido);
            }
        }

        private void Serializar(string ruta, T contenido)
        {
    
            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {                
                string json = JsonSerializer.Serialize(contenido);
                streamWriter.Write(json);
            }
        }

        public T Leer(string ruta)
        {
            if (ValidarSiExisteElArchivo(ruta) && ValidarExtension(ruta))
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    string json = streamReader.ReadToEnd(); 
                    return JsonSerializer.Deserialize<T>(json);
                }
            }

            return null;
        }

    }
}
