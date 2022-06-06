using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3ClassLibrary
{
    public class Factura : ICargaImpositiva<Persona>
    {

        
        private int numeroFactura;
        private int compradorId;
        private List<Producto> listProductos;
        private float total;
        private float bonificacionCargos;
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
            this.listProductos = productos;
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
                listProductos = value;
            }
        }

        public float Total
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

        public float Descuento
        {
            get
            {
                return this.total*bonificacionCargos;
            }

            
        }

     

        public float CalcularBonificaciones(Persona comprador)
        {

            bonificacionCargos = 0;

            if (comprador is Afiliado)
            {
                switch (((Afiliado)comprador).TipoAfiliado)
                {
                    case eTipoAfiliado.trainee:
                        bonificacionCargos = 0.1f;
                        break;
                    case eTipoAfiliado.junior:
                        bonificacionCargos = 0.15f;
                        break;
                    case eTipoAfiliado.senior:
                        bonificacionCargos = 0.2f;
                        break;
                }
            }
            switch (tipoPago)
            {
                case eTipoPago.efectivo:
                case eTipoPago.debito:
                    bonificacionCargos += 0.1f;
                    break;
                case eTipoPago.credito:
                    bonificacionCargos -= 0.1f;
                    break;
            }

            return bonificacionCargos;
        }

        public float CalcularImpuesto(Persona comprador)
        {
            float impuesto = 0;

            if (comprador is Cliente)
            {
                switch (((Cliente)comprador).Tipo)
                {

                    case eTipo.particular:
                    case eTipo.monotributo:
                        impuesto = 0.21f;
                        break;

                    case eTipo.responsable_Inscrito:
                        impuesto = 0;
                        break;
                }
            }
            return impuesto;
        }

        public static Factura operator +(Factura factura, Producto UnProducto)
        {
            
            factura.AddProducto(UnProducto,UnProducto.Cantidad);
            return factura;
           
        }

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
            sb.AppendLine($"Factura # {this.numeroFactura}");
            sb.AppendLine(cliente.ToString());
            sb.AppendLine(Producto.ImprimirListaProductos(listProductos));
            sb.AppendLine("").AppendLine("");
            sb.AppendLine($"Medio Pago: $ {this.tipoPago}");
            sb.AppendLine($"Bonificacion y cargos Extras: $ {this.Descuento}");
            sb.AppendLine($"Total: $ {this.total}");
            return sb.ToString();

        }

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
