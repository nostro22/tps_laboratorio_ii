using System;
using System.Collections.Generic;
using System.Text;

namespace TP3ClassLibrary
{

    /// <summary>
    /// Clase con interface generica que determina cargas impositivas, esta clase se encargada de relacionar personas y productos
    /// </summary>
    public class Factura : ICargaImpositiva<Persona>
    {

        
        private int numeroFactura;
        private int compradorId;
        private List<Producto> listProductos;
        private decimal total;
        private decimal bonificacionCargos;
        private eTipoPago tipoPago;

        public eTipoPago TipoPago
        {
            get
            {
                return tipoPago;
            }

            set
            {
                tipoPago = value;
            }
        }
        public Factura()
        {
        }

        public Factura(int numeroFactura, Persona comprador, List<Producto> productos, eTipoPago tipoPago)
        {
            this.numeroFactura = numeroFactura;
            this.compradorId = comprador.Dni;
            this.listProductos = new List<Producto>(productos);            
            if (tipoPago == eTipoPago.all)
            {
                this.tipoPago = eTipoPago.efectivo;
            }
            this.tipoPago = tipoPago;
            this.bonificacionCargos = CalcularBonificaciones(comprador);
            if (productos is not null && productos.Count > 0)
            {
                this.total = Producto.CalcularTotal(productos, bonificacionCargos);
            }
            else
            {
                this.total = 0;
            }
        }

        public int NumeroFactura
        {
            get
            {
                return numeroFactura;
            }

            set
            {
                numeroFactura = value;
            }
        }

        public int CompradorId
        {
            get
            {
                return compradorId;
            }

            set
            {
                compradorId = value;
            }
        }

        public List<Producto> ListaProductos
        {
            get
            {
                return listProductos;
            }

            set
            {
                listProductos = new List<Producto>(value);
            }
        }

        public decimal Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public decimal Descuento
        {
            get
            {
                return this.total*bonificacionCargos;
            }

            
        }

     
        /// <summary>
        /// Metodo que calcula los descuentos y bonificaciones que le corresponde al cliente deacuerdo al tipo de pago, antiguedad como afiliado 
        /// </summary>
        /// <param name="comprador"></param>
        /// <returns></returns>
        public decimal CalcularBonificaciones(Persona comprador)
        {

            bonificacionCargos = 0;

            if (comprador is Afiliado)
            {
                switch (((Afiliado)comprador).TipoAfiliado)
                {
                    case eTipoAfiliado.trainee:
                        bonificacionCargos = (decimal)0.1f;
                        break;
                    case eTipoAfiliado.junior:
                        bonificacionCargos = (decimal)0.15f;
                        break;
                    case eTipoAfiliado.senior:
                        bonificacionCargos = (decimal)0.2f;
                        break;
                }
            }
            switch (tipoPago)
            {
                case eTipoPago.efectivo:
                case eTipoPago.debito:
                    bonificacionCargos += (decimal)0.1f;
                    break;
                case eTipoPago.credito:
                    bonificacionCargos -= (decimal)0.1f;
                    break;
            }

            return bonificacionCargos;
        }


        /// <summary>
        /// Metodo que calcula los impuesto del cliente no afiliado dependiendo de su tipo 
        /// </summary>
        /// <param name="comprador"></param>
        /// <returns></returns>
        public decimal CalcularImpuesto(Persona comprador)
        {
            decimal impuesto = 0;

            if (comprador is Cliente)
            {
                switch (((Cliente)comprador).Tipo)
                {

                    case eTipo.Particular:
                    case eTipo.Monotributo:
                        impuesto = (decimal)0.21f;
                        break;

                    case eTipo.Inscrito:
                        impuesto = 0;
                        break;
                }
            }
            return impuesto;
        }


        /// <summary>
        /// Sobrecarga que Permite adicionar de forma mas comoda productos a la factura 
        /// </summary>
        /// <param name="factura"></param>
        /// <param name="UnProducto"></param>
        /// <returns></returns>
        public static Factura operator +(Factura factura, Producto UnProducto)
        {
            
            factura.AddProducto(UnProducto,UnProducto.Cantidad);
            return factura;
           
        }

        /// <summary>
        /// Metodo para determinar como adicioar el producto a la factura, si el producto ya existia se le cambia el atributo cantidad y si no existia se adiciona
        /// Tambien existe una verificacion de que la cantidad del producto que deseas agregar no sea mayor a la cantidad que ese producto posee en su atributo
        /// </summary>
        /// <param name="unProducto"></param>
        /// <param name="cantidadQueDeseaAgregar"></param>
        /// <returns></returns>
        public bool AddProducto(Producto unProducto, int cantidadQueDeseaAgregar)
        {
            bool agregadoConExito = false;
            if (unProducto != null && unProducto.Cantidad>0 && cantidadQueDeseaAgregar >0)
            {

                int cantidadAgregable = 0;
                if (cantidadQueDeseaAgregar > unProducto.Cantidad)
                {
                    cantidadAgregable = unProducto.Cantidad;
                }
                else
                {
                    cantidadAgregable = cantidadQueDeseaAgregar;
                }                
            
                if (listProductos.Contains(unProducto))
                {
                    foreach (Producto item in this.listProductos)
                    {
                        if (unProducto.Equals(item))
                        {
                            
                            unProducto.Cantidad += cantidadAgregable;
                            unProducto.Cantidad -=cantidadAgregable;
                            agregadoConExito = true;
                            break;
                        }
                    }
                }
                else
                {
                    listProductos.Add(unProducto);
                    agregadoConExito = true;
                }
            }
            return agregadoConExito;        
        }

        public string GenerarFacturaString(List<Persona> listaPersonas, string resumenPersonaCmb)
        {

            StringBuilder sb = new StringBuilder();
            Persona cliente = Persona.GetPersonaWtihResumen(listaPersonas, resumenPersonaCmb);
            sb.AppendLine($"Factura # {this.numeroFactura}\n");
            sb.AppendLine(cliente.ToString());
            sb.AppendLine(Producto.ImprimirListaProductos(listProductos));
            sb.AppendLine("").AppendLine("");
            sb.AppendLine($"Medio Pago: $ {this.tipoPago}");
            sb.AppendLine($"Bonificacion y cargos Extras: $ {String.Format("{0:0.00}", this.Descuento)}");
            sb.AppendLine($"Total: $ {String.Format("{0:0.00}",this.total)}");
            return sb.ToString();
            
        }

        public string GenerarFacturaStringWithDni(List<Persona> listaPersonas, Persona cliente)
        {

            StringBuilder sb = new StringBuilder();           
            sb.AppendLine($"Factura # {this.numeroFactura}\n");
            sb.AppendLine(cliente.ToString());
            sb.AppendLine(Producto.ImprimirListaProductos(listProductos));
            sb.AppendLine("").AppendLine("");
            sb.AppendLine($"Medio Pago: $ {this.tipoPago}");
            sb.AppendLine($"Bonificacion y cargos Extras: $ {String.Format("{0:0.00}", this.Descuento)}");
            sb.AppendLine($"Total: $ {String.Format("{0:0.00}", this.total)}");
            return sb.ToString();

        }


        /// <summary>
        /// Metodo usado para determinar el siguiente id o numero de factura a emiter, se asume que se tiene acceso a la lista de las ultimas facturas emitidas en todo momento
        /// </summary>
        /// <param name="facturas"></param>
        /// <returns>int id factura siguiente</returns>
        public static int GetFacturaActualNumber(List<Factura> facturas)
        {
            int numeroFacturaActual = 0;
            foreach (Factura item in facturas)
            {
                if (item.numeroFactura >= numeroFacturaActual)
                {
                    numeroFacturaActual = item.numeroFactura + 1;
                }
            }

            return numeroFacturaActual;
        }

        /// <summary>
        /// Verifica si el string corresponde a el id o numero de factura y este esta en la lista
        /// </summary>
        /// <param name="facturas"></param>
        /// <param name="numeroFactura"></param>
        /// <returns> true si esta , flase si no esta</returns>
        public static bool FacturaNEstaEnLista(List<Factura> facturas, string numeroFactura)
        {

            if (int.TryParse(numeroFactura, out int numero))
            {
                foreach (Factura item in facturas)
                {
                    if (item.NumeroFactura == numero)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }


}
