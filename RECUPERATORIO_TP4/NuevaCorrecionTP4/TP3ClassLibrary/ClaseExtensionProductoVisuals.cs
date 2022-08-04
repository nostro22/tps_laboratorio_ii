using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3ClassLibrary
{
    /// <summary>
    /// Se usa para controlar con un booleano si hay o no stock y posteriormente apagar la visual
    /// </summary>
    public static class ClaseExtensionProductoVisuals
    {


        public static bool ProductoDisponible(this Producto producto)
        {

            
                if(producto.Cantidad<=0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            
        }


    }
}
