using System;
using System.Collections.Generic;
using System.Linq;
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
       


        public FrmFacturacion(List<Factura> facturas, List<Persona> personas, List<Producto> producto)
        {
            InitializeComponent();
            this.facturas = facturas;
            this.personas = personas;            
            this.productoVentas = producto;
            cmbLCliente.DataSource = personas;
            cmbLCliente.DisplayMember = "FullName";
            List<eTipoPago> mediosPago = new List<eTipoPago>();
            foreach (eTipoPago contact in Enum.GetValues(typeof(eTipoPago)).OfType<eTipoPago>().Where(m => m != eTipoPago.all))
            {
                mediosPago.Add(contact);
            }
            cmbMedioPago.DataSource = mediosPago;            
        }
        private void FrmBilling_Load(object sender, EventArgs e)
        {
            cmbMedioPago.SelectedItem = eTipoPago.efectivo;            
            txtFactura.Text = ImprimirFactura();
        }

        /// <summary>
        /// Permite generar el tipo de factura de texto para mostrar el preview de la misma al usuario
        /// </summary>
        /// <param name="tipoPago"></param>
        /// <returns></returns>
        private string ImprimirFactura()
        {
           int numeroFactura = Factura.GetFacturaActualNumber(facturas);
           Persona comprador = (Persona)cmbLCliente.SelectedItem;
           eTipoPago pago = eTipoPago.efectivo;
            if(cmbMedioPago.SelectedItem!=null)
            {
                pago = (eTipoPago)cmbMedioPago.SelectedItem;
            }
           Factura factura = new Factura(numeroFactura, comprador, productoVentas, pago);
           return factura.GenerarFacturaStringWithDni(personas,comprador);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int numeroFactura = Factura.GetFacturaActualNumber(facturas);
                Persona comprador = (Persona)cmbLCliente.SelectedItem;
                eTipoPago medioPago = (eTipoPago)cmbMedioPago.SelectedItem;
                Factura factura = new Factura(numeroFactura, comprador, productoVentas,medioPago);
                facturas.Add(factura);
                FrmDetalles frmDetalles = new FrmDetalles(factura, personas);
                frmDetalles.ShowDialog();
                DialogResult = DialogResult.OK;
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

        private void cmbMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFactura.Text = ImprimirFactura();
            this.txtFactura.Refresh();
        }

        private void cmbLCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtFactura.Refresh();
            txtFactura.Text = ImprimirFactura();
        }
    }
}
