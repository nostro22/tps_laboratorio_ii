using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using TP3ClassLibrary;

namespace TP3Prototipo
{
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
                tipoPersonaModificar = eTipo.afiliado;
                cmbTipo.SelectedIndex =(int)tipoPersonaModificar;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
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
                    personaAModificar.Activo = Conversions.ToBoolean(cmbEstado.SelectedItem);
                    if (personaAModificar is Cliente)
                    {
                        ((Cliente)personaAModificar).Tipo = (eTipo)cmbTipo.SelectedIndex; 
                    }
                }                
                this.Close();
            }
        }

         

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
        private void LoadCliente()
        {
            
            dtgvCliente.Rows[0].Cells[0].Value = personaAModificar.Dni.ToString();
            dtgvCliente.Rows[0].Cells[1].Value = personaAModificar.Nombre.ToString();
            dtgvCliente.Rows[0].Cells[2].Value = personaAModificar.FechaNacimiento.ToString();
            dtgvCliente.Rows[0].Cells[4].Value = personaAModificar.Activo;
            dtgvCliente.ForeColor = Color.Black;
            if (personaAModificar is Cliente)
            {
                dtgvCliente.Rows[0].Cells[3].Value = ((Cliente)personaAModificar).Tipo.ToString();
            }
            else
            {
                dtgvCliente.Rows[0].Cells[3].Value = eTipo.afiliado.ToString();
            }

        }

        private void FrmModificacion_Load(object sender, EventArgs e)
        {
            LoadCliente();
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            VerificadorNombre();
        }

        private void dateTimeNacimiento_ValueChanged(object sender, EventArgs e)
        {
            VerificarMayoriaEdad();
        }

     
    }
}
