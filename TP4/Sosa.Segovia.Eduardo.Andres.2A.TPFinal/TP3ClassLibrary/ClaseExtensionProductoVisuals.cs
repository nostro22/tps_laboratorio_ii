using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3ClassLibrary
{
    public static class ClaseExtensionProductoVisuals
    {


        public static bool ProductoConStock(this Producto producto)
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
