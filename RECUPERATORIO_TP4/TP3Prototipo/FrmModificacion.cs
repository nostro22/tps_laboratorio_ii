using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TP3ClassLibrary;

namespace TP3Prototipo
{
    /// <summary>
    /// Se encarga de la modificacion de usuarios. Si hay cambio de clases se realiza una baja y resubida con la nueva clase
    /// </summary>
    public partial class FrmModificacion : Form
    {
        private Persona personaAModificar;
        private List<Persona> listaClientes;
        private eTipo tipoPersonaModificar;
        public FrmModificacion(Persona persona, List<Persona> listaClientes)
        {
            InitializeComponent();
            this.personaAModificar = persona;
            this.listaClientes = listaClientes;
            InitDataCliente(personaAModificar);
           
        }

        private void FrmModificacion_Load(object sender, EventArgs e)
        {
            LoadCliente();
        }

        /// <summary>
        /// Detecta si al modificar hubo cambios en los datos
        /// </summary>
        /// <returns></returns>
        private bool HuboCambios()
        {
            if (dtgvCliente.Rows[0].Cells[1].Value != TxtNombre || (DateTime)dtgvCliente.Rows[0].Cells[2].Value != dateTimeNacimiento.Value || tipoPersonaModificar != (eTipo)cmbTipo.SelectedItem || (bool)cmbEstado.SelectedItem != personaAModificar.Activo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        /// <summary>
        /// Trae la data a modificar y la imprime por pantalla en un grid no editable y en paralelo se muestran  las opciones que se pueden modificar
        /// </summary>
        /// <param name="persona"></param>
        private void InitDataCliente(Persona persona)
        {
            lblDni.Text = "DNI: " + persona.Dni.ToString();
            TxtNombre.Text = personaAModificar.Nombre;
            dateTimeNacimiento.Value = personaAModificar.FechaNacimiento;
            if (personaAModificar.Activo)
            {
                cmbEstado.SelectedIndex = 0;            
            }
            else
            {
                cmbEstado.SelectedIndex = 1;
            }

            cmbTipo.DataSource = Enum.GetNames(typeof(eTipo));
            if (persona is Cliente)
            {
                tipoPersonaModificar = ((Cliente)persona).Tipo;
                cmbTipo.SelectedIndex =(int)tipoPersonaModificar;
            }
            else
            {
                tipoPersonaModificar = eTipo.Afiliado;
                cmbTipo.SelectedIndex =(int)tipoPersonaModificar;
            }
        }


        /// <summary>
        /// Si hubo cambio y dependiendo del modo del from sea modificacion o baja se realiza la accion luego de verificar condiciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (HuboCambios() && VerificarMayoriaEdad() && VerificadorNombre())
            {
                if (personaAModificar is Afiliado && cmbTipo.SelectedIndex != 0)
                {
                    Cliente clienteModificado = new Cliente(personaAModificar.Dni, TxtNombre.Text, dateTimeNacimiento.Value, (eTipo)cmbTipo.SelectedIndex);
                    clienteModificado.Activo = Conversions.ToBoolean(cmbEstado.SelectedItem);
                    listaClientes.Remove(personaAModificar);
                    listaClientes.Add(clienteModificado);
                }
                else if (personaAModificar is Cliente && cmbTipo.SelectedIndex==0)
                {
                    Afiliado clienteModificado = new Afiliado(personaAModificar.Dni, TxtNombre.Text, dateTimeNacimiento.Value, DateTime.Now);
                    clienteModificado.Activo = (bool)cmbEstado.SelectedItem;
                    listaClientes.Remove(personaAModificar);
                    listaClientes.Add(clienteModificado);
                }
                else
                {
                    personaAModificar.Nombre = TxtNombre.Text;
                    personaAModificar.FechaNacimiento = dateTimeNacimiento.Value;
                    personaAModificar.Activo = Conversions.ToBoolean(cmbEstado.SelectedIndex);
                    if (personaAModificar is Cliente)
                    {
                        ((Cliente)personaAModificar).Tipo = (eTipo)cmbTipo.SelectedIndex; 
                    }
                }                
                this.Close();
            }
        }

         
        /// <summary>
        /// Determina si es mayor de edad y no permite avanzar con la modificacion
        /// </summary>
        /// <returns></returns>
        private bool VerificarMayoriaEdad()
        {
            if (!Persona.EsMayorEdad(dateTimeNacimiento.Value))
            {
                errorProviderModificacion.SetError(dateTimeNacimiento, "Campo obligatorio. Debe ser mayor de edad");
                return false;
            }
            else
            {
                errorProviderModificacion.SetError(dateTimeNacimiento, string.Empty);
                return true;
            }
        }


        /// <summary>
        /// Verifica el nombre y no permite avanzar con la modificacion en caso contrario
        /// </summary>
        /// <returns></returns>
        private bool VerificadorNombre()
        {

            if (!Persona.NombreIsValid(TxtNombre.Text))
            {
                errorProviderModificacion.SetError(TxtNombre, "Campo obligatorio. Solo se permiten letras en el nombre");
                return false;
            }
            else
            {
                errorProviderModificacion.SetError(TxtNombre, string.Empty);
                return true;
            }
        }

        /// <summary>
        /// Carga los datos viejos en los campos de modificacion para ahorrar tiempo al usuario al modificacar valores
        /// </summary>
        private void LoadCliente()
        {
            string estado = string.Empty;
            dtgvCliente.Rows[0].Cells[0].Value = personaAModificar.Dni.ToString();
            dtgvCliente.Rows[0].Cells[1].Value = personaAModificar.Nombre.ToString();
            dtgvCliente.Rows[0].Cells[2].Value = personaAModificar.FechaNacimiento.ToString();
            if (personaAModificar.Activo)
            {
                estado = "Activo";
            }
            else
            {
                estado = "Inactivo";
            }
            dtgvCliente.Rows[0].Cells[4].Value = estado;
            dtgvCliente.ForeColor = Color.Black;
            if (personaAModificar is Cliente)
            {
                dtgvCliente.Rows[0].Cells[3].Value = ((Cliente)personaAModificar).Tipo.ToString();
            }
            else
            {
                dtgvCliente.Rows[0].Cells[3].Value = eTipo.Afiliado.ToString();
            }

        }

        /// <summary>
        /// Llama al verificado de nombre cuando escribe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            VerificadorNombre();
        }

        /// <summary>
        /// Llama al verificador de fecha cuando la cambian
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimeNacimiento_ValueChanged(object sender, EventArgs e)
        {
            VerificarMayoriaEdad();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
