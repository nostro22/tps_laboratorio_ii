using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TP3ClassLibrary;

namespace TP3Prototipo
{
    /// <summary>
    /// Usada para el alta de clientes
    /// Se cuenta con un alto grado de verificacion y guia de error provider para facilitar el uso
    /// </summary>
    public partial class FrmClienteAlta : Form
    {

        private List<Persona> listaClientes;

        public FrmClienteAlta(List<Persona> listaClientes)
        {
            InitializeComponent();
            this.listaClientes = listaClientes;
            
        }      
        
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            cmbTipo.DataSource = Enum.GetNames(typeof(eTipo));

        }

        /// <summary>
        /// Verificacion de ingreso con error provider, no me dio tiempo de implementar esta funcionabilidad en detalle en las otras forms
        /// </summary>
        /// <returns></returns>
        protected bool VerificadorDNI()
        {
            bool isValid = true;
            if (!Persona.DniIsValid(txtDNI.Text))
            {
                errorProviderAlta.SetError(txtDNI, "Campo obligatorio. Solo se permiten numeros positivos en el DNI");
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
       
        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (VerificadorDNI() && VerificadorNombre() && VerificarMayoriaEdad() )
            {
                if (cmbTipo.Text == Enum.GetName(eTipo.Afiliado))
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            VerificadorDNI();
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            VerificadorNombre();
        }
    }
}
