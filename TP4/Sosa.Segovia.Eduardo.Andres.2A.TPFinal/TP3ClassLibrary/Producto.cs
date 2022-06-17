using System.Collections.Generic;
using System.Text;

namespace TP3ClassLibrary
{
    /// <summary>
    /// Clase de producto a vender en mi caso son NFT o productos digitales, Los productos son de producion masiva por lo que el id lo identifa al grupo en general y la cantidad representa su stock
    /// </summary>
    public class Producto
    {

        private double precio;
        private int idProducto;
        private string nombre;
        private int cantidad;
        private eRareza rareza;       

        public Producto() { }
        public Producto(double price, int idProducto, string nombre, int stock, eRareza rareza)
        {
            this.precio = price;
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.cantidad = stock;
            if (rareza == eRareza.all)
            {
                this.rareza = eRareza.common;
            }
            else
            {
                this.rareza = rareza;
            }
            
        }
        public Producto(double price, int idProducto, string nombre, int stock, int rareza)
        {
            this.precio = price;
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.cantidad = stock;
            if (rareza == 3)
            {
                this.rareza = eRareza.epic;
            }
            else if ( rareza ==2)
            {
                this.rareza = eRareza.epic;
            }
            else
            {
                this.rareza = eRareza.common;
            }

        }

        public Producto ShallowCopy()
        {
            return (Producto)this.MemberwiseClone();
        }


        public double Price
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public int IdProducto
        {
            get
            {
                return idProducto;
            }

            set
            {
                idProducto = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public eRareza Rareza
        {
            get
            {
                return rareza;
            }

            set
            {
                rareza = value;
            }
        }

       /// <summary>
       /// Recorre la lista y devuelve el descuento acumulativo que se recibe en formato 0.D
       /// </summary>
       /// <param name="productosComprados"></param>
       /// <param name="descuento"></param>
       /// <returns></returns>

        public static double CalcularTotal(List<Producto> productosComprados,double descuento)
        {

            double total = 0;
         

            foreach (Producto item in productosComprados)
            {                
                total += item.precio * item.cantidad;
            }
            descuento = total * descuento;
            return total-descuento;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id: {this.idProducto}");
            sb.Append($" | Nombre: " + this.nombre.ToUpper());
            sb.Append($" | Rareza: " + this.Rareza.ToString().ToUpper());
            sb.Append($" | Cantidad: " + this.Cantidad.ToString());
            sb.Append($" | Precio: " + this.precio.ToString());
            return sb.ToString();
        }

        public static string ImprimirListaProductos(List<Producto> productos)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Lista Productos");
            foreach (Producto item in productos)
            {
                sb.AppendLine(item.ToString());
            }
           

            return sb.ToString();
        }

        /// <summary>
        /// mantiene la relacion entre stock y carrito de venta para que se vea reflejada el cambio visualmente al agregar productos, 
        /// recibe una cantidad por si en un futuro se quiere agregar la funcionabilidad de bundle o botones de venta con x cantidad de unidades
        /// </summary>
        /// <param name="listaEntregas"></param>
        /// <param name="productoEnStock"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static bool VenderProducto(List<Producto> listaEntregas,  Producto productoEnStock, int cantidad)
        {
            if (productoEnStock.cantidad > 0  && listaEntregas is not null && productoEnStock is not null)
            {
                Producto aux = productoEnStock.ShallowCopy();
                if(productoEnStock.cantidad<cantidad)
                {
                    cantidad = productoEnStock.cantidad;
                }
                aux.cantidad = cantidad;
                productoEnStock.cantidad -= cantidad;

                listaEntregas = listaEntregas + aux;
                

                return true;
            }
            return false;

        }
        
        /// <summary>
        /// Funcion similar a la de arriba se podria funcionar paro quise conservar la logica separada por la complejidad del proyecto
        /// </summary>
        /// <param name="listaStock"></param>
        /// <param name="productoADevolver"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static bool DevolverProducto(List<Producto> listaStock, Producto productoADevolver , int cantidad)
        {
            if (cantidad > 0 && listaStock is not null)
            {
                foreach (Producto item in Carrito.ListaCarrito)
                {
                    if (item.idProducto == productoADevolver.idProducto && item.cantidad>0)
                    {
                        item.cantidad--;
                        productoADevolver.cantidad++;
                        if (item.Cantidad==0)
                        {
                        Carrito.ListaCarrito.Remove(item);
                        break;
                        }
                    }
                }

                return true;
            }
            return false;

        }

        /// <summary>
        /// recoore la lista y te dice el total de productos que tienes en ella
        /// usada principalmente para el carrito de venta
        /// </summary>
        /// <param name="listProductos"></param>
        /// <returns></returns>
        public static int CantidadProductoEnLista(List<Producto> listProductos)
        {
            int cantidadProductos = 0;
            if (listProductos is not null)
            {
                foreach (Producto item in listProductos)
                {
                    cantidadProductos += item.Cantidad;
                }            
            }
            return cantidadProductos;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj is not null && obj is Producto unProducto && unProducto.IdProducto == this.IdProducto)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Suma una lista y un producto 
        /// use una shallow copie para no alterar a mi producto original y agregar una copia de este a la lista
        /// </summary>
        /// <param name="l"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static List<Producto> operator +(List<Producto> l, Producto p)
        {
            
            if (l is not null && p is not null &&p.cantidad>0)
            {
                if (l.Contains(p))
                {
                    foreach (Producto item in l)
                    {
                        if (item.Equals(p))
                        {
                            item.cantidad += p.cantidad;
                            p.cantidad=0;                          
                            break;
                        }

                    }
                }
                else
                {
                    Producto aux = p.ShallowCopy();
                    p.cantidad = 0;
                    l.Add(aux);
                }
            }           
            return l;
        }

        public static List<Producto> operator -(List<Producto> l, Producto p)
        {

            if (l is not null && p is not null && p.cantidad > 0)
            {
                if (l.Contains(p))
                {
                    foreach (Producto item in l)
                    {
                        if (item.Equals(p))
                        {
                            if (item.cantidad > p.cantidad)
                            {
                                item.cantidad -= p.cantidad;
                                p.cantidad = 0;

                            }
                            else
                            {
                                p.cantidad -= item.cantidad;
                                item.cantidad = 0;
                            }

                            break;
                        }

                    }
                }
           
            }
            return l;
        }

        public static bool operator !=(Producto p , Producto p1)
        {
         
                 return !(p==p1);
        }
        public static bool operator ==(Producto p, Producto p1)
        {
            bool isEqual = false;
            if (p is not null && p1 is not null && p.idProducto == p1.idProducto)
            {
                isEqual = true;
            }
            return isEqual;

        }
        public override int GetHashCode() 
        {
            return base.GetHashCode();
        }




    }

 
}
