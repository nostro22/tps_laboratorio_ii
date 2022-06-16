using IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TP3ClassLibrary;

namespace TP3Prototipo
{
    /// <summary>
    /// Te permite Visualizar un resumen de las facturas e ingresando su numero poder leerlas en detalle o descargarlas en un archi de texto
    /// </summary>
    public partial class FrmImformes : Form
    {
        private List<Factura> facturas;
        private List<Persona> personas;
        public FrmImformes(List<Factura> listaFacturas, List<Persona> personas)
        {
            InitializeComponent();
            this.facturas = listaFacturas;
            this.personas = personas;
            MostrarAyudaFacturas();

        }

        

        /// <summary>
        /// Manejo de datagrid para imprimir ayuda de factura en forma lineal
        /// </summary>
        /// <param name="factura"></param>
        private void ImprimirUnaFactura(Factura factura)
        {
            dtgvFacturas.DataSource = facturas;
            dtgvFacturas.Columns[0].HeaderText = "PAGO";
            dtgvFacturas.Columns[1].HeaderText = "# FACTURA";
            dtgvFacturas.Columns[2].HeaderText = "DNI";
            dtgvFacturas.Columns[3].HeaderText = "TOTAL";
            dtgvFacturas.Columns[4].Visible = false;
        }

        /// <summary>
        /// Se recorre la lista de fasturas y se imprime la ayuda completa en la grilla
        /// </summary>
        private void MostrarAyudaFacturas()
        {
            foreach (Factura item in facturas)
            {
                ImprimirUnaFactura(item);
            }
        }
        
     
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Te muestra en un message box la factura particular que deseaste abrir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetalles_Click(object sender, EventArgs e)
        {
          
            if (dtgvFacturas.SelectedRows.Count > 0)
            {               
                Factura facturaADetallar;
                facturaADetallar = (Factura)dtgvFacturas.CurrentRow.DataBoundItem;                 
                FrmDetalles frmDetalles = new FrmDetalles(facturaADetallar, personas);
                frmDetalles.Show();
            }

        }

       
        /// <summary>
        /// Genera un archivo de texto con la factura ingresada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDescargarFactura_Click(object sender, EventArgs e)
        {
            if (dtgvFacturas.SelectedRows.Count > 0)
            {
                Factura facturaADetallar;
                facturaADetallar = (Factura)dtgvFacturas.CurrentRow.DataBoundItem;
                if (Factura.FacturaNEstaEnLista(facturas, facturaADetallar.NumeroFactura.ToString()))
                {
                        SaveFileDialog saveFactura = new SaveFileDialog();                
                        saveFactura.Filter = "Archivo texto |*.txt";
                        saveFactura.DefaultExt = ".txt";
                        PuntoTxt puntoTxt = new PuntoTxt();

                        if (saveFactura.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = saveFactura.FileName;
                        
                            try
                            {
                                puntoTxt.GuardarComo(Path.GetFileNameWithoutExtension(filePath)+".txt", facturaADetallar.GenerarFacturaString(personas, facturaADetallar.CompradorId.ToString()));   
                            }
                            catch 
                            {

                                MessageBox.Show("Error al descarga Factura");
                            }
                        }

                }

            }
        }

      

        private void dtgvFacturas_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvFacturas.SelectedRows.Count > 0)
            {
                Factura facturaADetallar;
                facturaADetallar = (Factura)dtgvFacturas.CurrentRow.DataBoundItem;                
            }
        }
    }
}
