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
    public partial class FrmClienteAlta : Form
    {

        private List<Persona> listaClientes;

        public FrmClienteAlta(List<Persona> listaClientes)
        {
            InitializeComponent();
            this.listaClientes = listaClientes;
            cmbTipo.DataSource = Enum.GetNames(typeof(eTipo));
            
        }      
        
        private void FrmCliente_Load(object sender, EventArgs e)
        {

        }

        protected bool VerificadorDNI()
        {
            bool isValid = true;
            if (!Persona.DniIsValid(txtDNI.Text))
            {
                errorProviderAlta.SetError(txtDNI, "Campo obligatorio. Solo se permiten numeros en el DNI de 7-9 digitos maximo");
                isValid = false;
                
            }

            else if (Persona.DniIsValid(txtDNI.Text) && Persona.EstaEnLista(txtDNI.Text, listaClientes))
            {
                errorProviderAlta.SetError(txtDNI, "Ya se encuentra registrado este DNI");
                isValid = false;
            }
            else
            {
                errorProviderAlta.SetError(txtDNI, string.Empty);
                isValid = true;
            }
            return isValid;
        }

        private bool VerificarMayoriaEdad()
        {
            if (!Persona.EsMayorEdad(dateTimeNacimiento.Value))
            {
                errorProviderAlta.SetError(dateTimeNacimiento, "Campo obligatorio. Debe ser mayor de edad");
                return false;
            }
            else
            {
                errorProviderAlta.SetError(dateTimeNacimiento, string.Empty);
                return true;
            }
        }

      

        private bool VerificadorNombre()
        {

            if (!Persona.NombreIsValid(TxtNombre.Text))
            {
                errorProviderAlta.SetError(TxtNombre, "Campo obligatorio. Solo se permiten letras en el nombre");
                return false;
            }         
            else
            {
                errorProviderAlta.SetError(TxtNombre,string.Empty);
                return true;
            }
        }
       
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (VerificadorDNI() && VerificadorNombre() && VerificarMayoriaEdad() )
            {
                if (cmbTipo.Text == Enum.GetName(eTipo.afiliado))
                {
                    listaClientes.Add(new Afiliado(int.Parse(txtDNI.Text), TxtNombre.Text, dateTimeNacimiento.Value, DateTime.Now));
                }
                else
                {               
                    listaClientes.Add(new Cliente(int.Parse(txtDNI.Text), TxtNombre.Text, dateTimeNacimiento.Value,(eTipo)cmbTipo.SelectedIndex));
                }
                this.Close();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
