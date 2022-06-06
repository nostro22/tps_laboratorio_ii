using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TP3ClassLibrary;

namespace TP3Prototipo
{
    /// <summary>
    /// frm usado para Facturacion final, aqui se generan las nuevas facturas y se añaden a la lista estatica atravez de un pasaje por referencia en el constructor
    /// Las lista de carrito , lista de personas y resumenPersona combobox selecionador de cliente se pasan en el contructor para hacer imprimir dos preview facturas dependiendo del medio de pago
    /// Luego existe un manejo de datos atravez de archivos default que se actualizan automaticamente al final operaciones
    /// </summary>
    public partial class FrmFacturacion : Form
    {

        private List<Factura> facturas;
        private List<Persona> personas;
        private List<Producto> productoVentas;        
        private string resumenPersonaAFacturar;


        public FrmFacturacion(List<Factura> facturas, List<Persona> personas, List<Producto> producto, string resumenPersona)
        {
            InitializeComponent();
            this.facturas = facturas;
            this.personas = personas;
            this.resumenPersonaAFacturar = resumenPersona;
            this.productoVentas = producto;           
        }
        private void FrmBilling_Load(object sender, EventArgs e)
        {
            InitFacturacionOpciones();
        }

        /// <summary>
        /// Permite generar el tipo de factura de texto para mostrar el preview de la misma al usuario
        /// </summary>
        /// <param name="tipoPago"></param>
        /// <returns></returns>
        private string ImprimirFactura(eTipoPago tipoPago)
        {
           int numeroFactura = Factura.GetFacturaActualNumber(facturas);
           Persona comprador = Persona.GetPersonaWtihResumen(personas,resumenPersonaAFacturar);
           Factura factura = new Factura(numeroFactura, comprador, productoVentas, tipoPago);
            return factura.GenerarFacturaString(personas,resumenPersonaAFacturar);
        }

        /// <summary>
        /// Imprime la facturas preview con sus descuentos correspondientes
        /// </summary>
        private void InitFacturacionOpciones()
        {
            txtFactura.Text = ImprimirFactura(eTipoPago.all);
            txtFacturaCredito.Text = ImprimirFactura(eTipoPago.credito);
        }

        /// <summary>
        /// Actualiza la cantidad de articulos en el carrito a cero
        /// </summary>
        private void ActualizarCarrito()
        {
            foreach (Producto item in productoVentas)
            {
               item.Cantidad = 0; 
            }
            
        }




        /// <summary>
        /// Genera una factura final abona en efectivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEfectivo(object sender, EventArgs e)
        {
            try
            {
                int numeroFactura = Factura.GetFacturaActualNumber(facturas);
                Persona comprador = Persona.GetPersonaWtihResumen(personas, resumenPersonaAFacturar);
                Factura factura = new Factura(numeroFactura, comprador, productoVentas, eTipoPago.efectivo);
                facturas.Add(factura);
                MessageBox.Show(factura.GenerarFacturaString(personas, resumenPersonaAFacturar));
                ActualizarCarrito();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar cobro efectivo");
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// Genera una factura final abonada en debito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDebito_Click(object sender, EventArgs e)
        {
            try
            {
                int numeroFactura = Factura.GetFacturaActualNumber(facturas);
                Persona comprador = Persona.GetPersonaWtihResumen(personas, resumenPersonaAFacturar);
                Factura factura = new Factura(numeroFactura, comprador, productoVentas, eTipoPago.debito);
                facturas.Add(factura);
                MessageBox.Show(factura.GenerarFacturaString(personas, resumenPersonaAFacturar));
                ActualizarCarrito();               
            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar cobro debito");
            }
            finally
            {
                this.Close();
            }
        }
        /// <summary>
        /// Genera una factura final abona en credito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCredito_Click(object sender, EventArgs e)
        {
            try
            {
                int numeroFactura = Factura.GetFacturaActualNumber(facturas);
                Persona comprador = Persona.GetPersonaWtihResumen(personas, resumenPersonaAFacturar);
                Factura factura = new Factura(numeroFactura, comprador, productoVentas, eTipoPago.credito);
                facturas.Add(factura);
                MessageBox.Show(factura.GenerarFacturaString(personas, resumenPersonaAFacturar));
                ActualizarCarrito();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar cobro credito");
            }
            finally
            {
                this.Close();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
