using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IO;
using TP3ClassLibrary;

namespace TP3Prototipo
{
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

        private void ImprimirUnaFactura(Factura factura)
        {
            int n = dtgvFacturas.Rows.Add();
            dtgvFacturas.Rows[n].Cells[0].Value = factura.NumeroFactura.ToString();
            dtgvFacturas.Rows[n].Cells[1].Value = factura.CompradorId.ToString();
            dtgvFacturas.Rows[n].Cells[2].Value = factura.Total;
            dtgvFacturas.Rows[n].Cells[3].Value = factura.TipoPago;
        }

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

        
        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (Factura.FacturaNEstaEnLista(facturas,txtNumeroFactura.Text))
            {               
                Factura facturaADetallar;
                facturaADetallar = facturas.Find( facturaADetallar => facturaADetallar.NumeroFactura == int.Parse(txtNumeroFactura.Text));
                MessageBox.Show(facturaADetallar.GenerarFacturaString(personas, facturaADetallar.CompradorId.ToString()));            
            }

        }

       

        private void btnDescargarFactura_Click(object sender, EventArgs e)
        {
            if (Factura.FacturaNEstaEnLista(facturas, txtNumeroFactura.Text))
            {
                Factura facturaADetallar;
                facturaADetallar = facturas.Find(facturaADetallar => facturaADetallar.NumeroFactura == int.Parse(txtNumeroFactura.Text));
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
}
