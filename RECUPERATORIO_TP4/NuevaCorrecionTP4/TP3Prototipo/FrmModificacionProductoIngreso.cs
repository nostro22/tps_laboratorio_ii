using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP3ClassLibrary;

namespace TP3Prototipo
{
    public partial class FrmModificacionProductoIngreso : Form
    {
        Producto productoOriginal;
        public FrmModificacionProductoIngreso(Producto producto)
        {
            InitializeComponent();
            List<Producto> productos1 = new List<Producto>();         
            productos1.Add(producto);
            dtgProducto.DataSource = productos1;
            AdjustColumnOrder();
            dtgProducto.Refresh();
            cmbRareza.DataSource = Enum.GetNames(typeof(eRareza));
            this.productoOriginal = producto;
            cmbRareza.SelectedIndex = cmbRareza.FindString(productoOriginal.Rareza.ToString());
            txtNombre.Text = productoOriginal.Nombre;
            txtCantidad.Text = productoOriginal.Cantidad.ToString();
            txtPrecio.Text = productoOriginal.Precio.ToString();
        }

        /// <summary>
        /// Ordena el las columnas a mostrar con los productos
        /// </summary>
        private void AdjustColumnOrder()
        {
            dtgProducto.AutoGenerateColumns = false;
            dtgProducto.Columns["Id"].DisplayIndex = 0;
            dtgProducto.Columns["Nombre"].DisplayIndex = 1;
            dtgProducto.Columns["Rareza"].DisplayIndex = 2;
            dtgProducto.Columns["Cantidad"].DisplayIndex = 3;
            dtgProducto.Columns["Precio"].DisplayIndex = 4;
          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtNombre.Text, @"[\w]{1,50}"))
            {
                errorProviderProducto.SetError(txtNombre, string.Empty);                
            }
            else
            {
                errorProviderProducto.SetError(txtNombre, "Campo obligatorio. Solo se permiten letras");                
            }

        }
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtCantidad.Text, "^[0-9]{1,10}$"))
            {
                errorProviderProducto.SetError(txtCantidad, string.Empty);
            }
            else
            {
                errorProviderProducto.SetError(txtCantidad, "Campo obligatorio. Solo se permiten numeros enteros maximo 10 digitos");
            }
        }
        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

            if (Regex.IsMatch(txtPrecio.Text, @"^[0-9]\d{1,10}(\.\d{0,3}|\,\d{0,3})?$"))
            {
                errorProviderProducto.SetError(txtPrecio, string.Empty);
            }
            else
            {
                errorProviderProducto.SetError(txtPrecio, "Campo obligatorio. Ingrese un valor decimal presicion de dos decimales, maximo 18 digitos");
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            if(Regex.IsMatch(txtCantidad.Text, "^[0-9]{1,10}$") && Regex.IsMatch(txtPrecio.Text, @"^[0-9]\d{1,10}(\.\d{0,3}|\,\d{0,3})?$") && Regex.IsMatch(txtNombre.Text,@"[\w]{1,50}"))
            {
                if(txtNombre.Text != productoOriginal.Nombre || txtPrecio.Text != productoOriginal.Precio.ToString() || txtCantidad.Text != productoOriginal.Cantidad.ToString() || cmbRareza.SelectedItem.ToString() != productoOriginal.Rareza.ToString())
                {
                    string precio = txtPrecio.Text.Replace('.', ',');
                    Producto modifiedProduct = new Producto(decimal.Parse(precio), productoOriginal.Id, txtNombre.Text, int.Parse(txtCantidad.Text), (eRareza)cmbRareza.SelectedIndex);
                    ProductoDAO.Modificar(modifiedProduct);
                    MessageBox.Show("Se ha actualizado la base de datos  \n", "CAMBIOS REALIZADOS CON EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Volviendo al menu de modificacion  \n", "NO HUBO CAMBIOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.Close();
            }
            
        }
    }
}
