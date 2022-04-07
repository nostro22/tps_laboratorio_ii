using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;



namespace FormCalculadora
{
    public partial class FormCalculadora : Form
    {
        Operando n1 = new Operando();
        Operando n2 = new Operando();
        char operador =' ';      
        
        public FormCalculadora()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            n1 = new Operando(txtNumero1.Text);
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            n2 = new Operando(txtNumero2.Text);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if(cmbOperador.Text!="")
            {
                operador = Convert.ToChar(cmbOperador.Text);
                string respuesta = Calculadora.Operar(n1, n2, operador).ToString();
                lbtOperaciones.Items.Add(n1.GetNumero().ToString() + operador + n2.GetNumero().ToString() + " = "+ respuesta);
                lbLResultado.Text = respuesta;
            }       
       
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            lbtOperaciones.Items.Clear();
            lbLResultado.Text=string.Empty;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (cmbOperador.Text != "")
            {
                operador = Convert.ToChar(cmbOperador.Text);
                string respuesta = Operando.DecimalABinario(Calculadora.Operar(n1, n2, operador));
                lbtOperaciones.Items.Add(respuesta);
                lbLResultado.Text = respuesta;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (cmbOperador.Text != "")
            {
                operador = Convert.ToChar(cmbOperador.Text);
                string respuesta = Operando.BinarioADecimal(Calculadora.Operar(n1, n2, operador));
                lbtOperaciones.Items.Add(respuesta);
                lbLResultado.Text = respuesta;
            }
        }

        private void lbLResultado_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if (MessageBox.Show("¿Seguro de querer salir?", "Closing Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
