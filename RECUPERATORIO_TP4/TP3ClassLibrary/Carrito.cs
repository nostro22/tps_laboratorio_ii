using System;
using System.Collections.Generic;

namespace TP3ClassLibrary
{

    /// <summary>
    /// Clase encargada del manejo temporal de objetos a facturar, La grabacion de datos en el respaldo sucede al facturar por lo que si se cierra la aplicacion no se conservara el carrito
    /// Esto es una desicion de diseño pensada para ser un sistema de facturacion usuario por varios empleados por lo que no es conveniente mantener sesion 
    /// </summary>
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

        /// <summary>
        /// Vacia la lista estatica de productos y devuelve estos al stock
        /// </summary>
        /// <param name="listaStock"></param>
        /// <returns></returns>
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

    /// <summary>
    /// Una excepcion sencilla para mostrar un mensaje controlado
    /// </summary>
    public class CarritoExcepion : Exception
    {
        public CarritoExcepion(string mensaje) : base(mensaje) { }
    }

}
