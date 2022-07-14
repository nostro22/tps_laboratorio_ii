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
                /// <summary>
                /// From encargado de presentar un grid con los productos a modificar, se bloquea ciertos campos que la empresa no permite modificar
                /// </summary>
    public partial class FrmModificarProductos : Form
    {
        private List<Producto> stock;
        public FrmModificarProductos( List<Producto> productos)
        {
            InitializeComponent();
            CargarGridBD();
            this.stock = productos;           
            this.Refresh();
        }

        private void CargarGridBD()
        {
            dtgProductos.DataSource = null;
            dtgProductos.DataSource = ProductoDAO.Leer();
            AdjustColumnOrder();
        }

        private void BtnVover_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Ordena el las columnas a mostrar con los productos
        /// </summary>
        private void AdjustColumnOrder()
        {
            dtgProductos.Columns["Id"].DisplayIndex = 0;         
            dtgProductos.Columns["Nombre"].DisplayIndex = 1;
            dtgProductos.Columns["Rareza"].DisplayIndex = 2;
            dtgProductos.Columns["Cantidad"].DisplayIndex = 3;
            dtgProductos.Columns["Precio"].DisplayIndex = 4;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            string id = dtgProductos[1, dtgProductos.CurrentRow.Index].Value.ToString();
            Producto producto = stock.Find(producto => producto.Id == int.Parse(id));
            FrmModificacionProductoIngreso modificacion = new  FrmModificacionProductoIngreso(producto);
            this.Hide();
            modificacion.ShowDialog();
            CargarGridBD();
            this.Refresh();
            this.Show();
        }
    }

}
