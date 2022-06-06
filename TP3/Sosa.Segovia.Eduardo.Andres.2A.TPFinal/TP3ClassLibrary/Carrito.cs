using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3ClassLibrary
{
    public static class Carrito
    {
        private static List<Producto> listaCarrito;
        

        static Carrito()
        {
            listaCarrito = new();
        }

        public static List<Producto> ListaCarrito
        {
            get
            {
                return listaCarrito;
            }

            set
            {
                listaCarrito = value;
            }
        }

        public static int CantidadProductoCarrito
        {
            get
            {      
                return Producto.CantidadProductoEnLista(listaCarrito);
            }
        }

        public static bool VaciaCarrito(List<Producto> listaStock)
        {

            if (listaCarrito is null)
            {
                throw new CarritoExcepion("Error carro sin memoria asignada");
            }
            else
            {
                foreach (Producto item in listaCarrito)
                {
                    if (listaStock.Contains(item))
                    {
                       listaStock = listaStock + item;
                    }
                }

              
            }


            listaCarrito.Clear();
           
            return true;
        }
    }

    public class CarritoExcepion : Exception
    {
        public CarritoExcepion(string mensaje) : base(mensaje) { }
    }

}
