using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3ClassLibrary
{

    public class Producto
    {

        private float price;
        private int idProducto;
        private string nombre;
        private int cantidad;
        private eRareza rareza;       

        public Producto() { }
        public Producto(float price, int idProducto, string nombre, int stock, eRareza rareza)
        {
            this.price = price;
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

        public Producto ShallowCopy()
        {
            return (Producto)this.MemberwiseClone();
        }


        public float Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
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

       

        public static float CalcularTotal(List<Producto> productosComprados,float descuento)
        {

            float total = 0;
         

            foreach (Producto item in productosComprados)
            {                
                total += item.price * item.cantidad;
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
            sb.Append($" | Precio: " + this.price.ToString());
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

      
        public override int GetHashCode() 
        {
            return base.GetHashCode();
        }




    }

 
}
