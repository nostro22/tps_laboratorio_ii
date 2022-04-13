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
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Al cargarse la app se llama a la funcion limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Limpiar();
        }  
        /// <summary>
        /// Al ser presionado el boton limpiar se llama a la funcion limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// llama a la funcion Operar si operador no es vacio, la respuesta es impresa por el lblResultado y la operacion con su respuesta agregada al historial de operaciones en lbtOperaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if(cmbOperador.Text!="")
            {
                char operador = ' ';
                if (string.IsNullOrEmpty(txtNumero1.Text))
                {
                    txtNumero1.Text = "0";
                }
                if (string.IsNullOrEmpty(txtNumero2.Text))
                {
                    txtNumero2.Text = "0";
                }
                operador = Convert.ToChar(cmbOperador.Text);                
                string respuesta = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
                lbtOperaciones.Items.Add(txtNumero1.Text + operador + txtNumero2.Text + " = "+ respuesta);
                lbLResultado.Text = respuesta;
            }    
        }
        /// <summary>
        /// Metodo de conversion de inputs del usuario a Class Operador y char
        /// </summary>
        /// <param name="num1">  del primer operador </param>
        /// <param name="num2">  segundo operador </param>
        /// <param name="operador">  operador que define la operacion a realizar </param>
        /// <returns></returns>
        private static double Operar(string num1, string num2, string operador)
        {
            Operando operando1 = new Operando(num1);
            Operando operando2 = new Operando(num2);
            
            return Calculadora.Operar(operando1, operando2, char.Parse(operador));       
        }        
        /// <summary>
        /// Limpia los inputs del usuario, el historial de transacciones, reinicia el indice del operador selecionado a 0
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            lbtOperaciones.Items.Clear();
            lbLResultado.Text=string.Empty;
            cmbOperador.SelectedIndex =0;
        }
        /// <summary>
        /// Presionar el boton Convertir a Binario el resultado de Operar y convierte a binario la respuesta si es posible sino da un error de mensaje 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (cmbOperador.Text != "")
            {
                
                if(string.IsNullOrEmpty(txtNumero1.Text))
                {
                    txtNumero1.Text = "0";
                }
                
                if (string.IsNullOrEmpty(txtNumero2.Text))
                {
                    txtNumero2.Text = "0";
                }
                string respuesta = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
                 respuesta = Operando.DecimalABinario(respuesta);                
                lbtOperaciones.Items.Add(respuesta);
                lbLResultado.Text = respuesta;
            }
        }
        /// <summary>
        /// Presionar el boton Convertir a decimal el resultado de Operar y convierte a decimal la respuesta si es posible sino da un error de mensaje 
        /// </summary>
        /// <param name="sender"> btnConvertirADecimal </param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (cmbOperador.Text != "")
            {
                if (string.IsNullOrEmpty(txtNumero1.Text))
                {
                    txtNumero1.Text = "0";
                }
                if (string.IsNullOrEmpty(txtNumero2.Text))
                {
                    txtNumero2.Text = "0";
                }
                string respuesta = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
                respuesta= Operando.BinarioADecimal(respuesta);
                lbtOperaciones.Items.Add(respuesta);
                lbLResultado.Text = respuesta;
            }
        }            
        /// <summary>
        /// Llama al meto close que inicia una verificacion antes de cerrar la app
        /// </summary>
        /// <param name="sender"> btnCerrar </param>
        /// <param name="e"> click </param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Verificacion antes de cerrar la app mediante un messageBox
        /// </summary>
        /// <param name="sender"> metodo closing()</param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if (MessageBox.Show("¿Seguro de querer salir?", "Closing Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.No)
            {
                e.Cancel = true;
            }
        }

     
    }
}
