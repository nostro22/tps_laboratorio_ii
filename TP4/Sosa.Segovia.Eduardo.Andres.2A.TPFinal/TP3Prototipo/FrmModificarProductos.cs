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
            RestricionesDataGrid();
            this.stock = productos;
        }

        private void CargarGridBD()
        {
            dtgProductos.DataSource = ProductoDAO.Leer();
        }

        private void RestricionesDataGrid()
        {
            dtgProductos.Columns[1].ReadOnly = true;
            dtgProductos.Columns[1].DefaultCellStyle.BackColor = Color.Red;
            dtgProductos.Columns[2].ReadOnly = true;
            dtgProductos.Columns[2].DefaultCellStyle.BackColor = Color.Red;
            dtgProductos.Columns[4].ReadOnly = true;
            dtgProductos.Columns[4].DefaultCellStyle.BackColor = Color.Red;
          
        }

        private void btnVover_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtgProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if(!inputInvalid(this.dtgProductos.CurrentCell.Value))
            {
                dtgProductos[e.ColumnIndex, e.RowIndex].Value = "0";
            }
            stock = (List<Producto>)dtgProductos.DataSource;
            ProductoDAO.ActualizarProductos((List<Producto>)dtgProductos.DataSource);
            
            
        }
    

        private void dtgProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if(e.ColumnIndex==3)
            {
                MessageBox.Show("Solo debe ingresar numero enteros en cantidad \nCorrija error", "ERROR INPUT", MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            else
            {
                MessageBox.Show("Solo debe ingresar numero \nCorrija error", "ERROR INPUT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Analisa los inpust del usuario y si no son numeros positivos devuelve false 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool inputInvalid(object data)
        {
            bool retorno = false;
            if(data is Int32)
            {
                if((Int32)data<0)
                {

                    retorno = false;
                }
                else
                {
                    retorno = true;
                }
            }
            if (data is double)
            {
                if ((double)data < 0)
                {
                    retorno = false;
                }
                else
                {
                    retorno = true;
                }
            }

            return retorno;
        }
    }
}
