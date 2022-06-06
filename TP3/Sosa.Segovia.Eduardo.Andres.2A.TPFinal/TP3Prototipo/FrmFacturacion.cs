using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP3ClassLibrary;

namespace TP3Prototipo
{
    public partial class FrmFacturacion : Form
    {

        private List<Factura> facturas;
        private List<Persona> personas;
        private List<Producto> productoVentas;
        private List<Producto> productoStock;
        private string resumenPersonaAFacturar;
        public FrmFacturacion(List<Factura> facturas, List<Persona> personas, List<Producto> producto, List<Producto> stock, string resumenPersona)
        {
            InitializeComponent();
            this.facturas = facturas;
            this.personas = personas;
            this.resumenPersonaAFacturar = resumenPersona;
            this.productoVentas = producto;
            this.productoStock = stock;
        }

        private string ImprimirFactura(eTipoPago tipoPago)
        {
           int numeroFactura = Factura.GetFacturaActualNumber(facturas);
           Persona comprador = Persona.GetPersonaWtihResumen(personas,resumenPersonaAFacturar);
           Factura factura = new Factura(numeroFactura, comprador, productoVentas, tipoPago);
            return factura.GenerarFacturaString(personas,resumenPersonaAFacturar);
        }

        private void InitFacturacionOpciones()
        {
            txtFactura.Text = ImprimirFactura(eTipoPago.all);
            txtFacturaCredito.Text = ImprimirFactura(eTipoPago.credito);
        }

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

        private void ActualizarCarrito()
        {
            foreach (Producto item in productoVentas)
            {
               item.Cantidad = 0; 
            }
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            InitFacturacionOpciones();
        }

        private void btneFECTIVO_Click(object sender, EventArgs e)
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
    }
}
