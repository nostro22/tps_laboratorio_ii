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
    public partial class FrmDetalles : Form
    {
        private Factura Factura;
        private readonly List<Persona> personas;

        public FrmDetalles(Factura factura, List<Persona> personas)
        {
            InitializeComponent();
            Factura = factura;
            this.personas = personas;
            txtFactura.Text = factura.GenerarFacturaString(personas, factura.CompradorId.ToString());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
