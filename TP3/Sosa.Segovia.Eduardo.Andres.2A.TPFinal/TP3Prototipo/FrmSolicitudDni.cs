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
    public partial class FrmSolicitudDni : Form
    {
        private List<Persona> Listpersonas;
        private eAccion accionARealizar;

        public FrmSolicitudDni(List<Persona> listPersonas, eAccion accion)
        {
            InitializeComponent();
            this.Listpersonas = listPersonas;
            this.accionARealizar = accion;
            SetUp(accion);
            ImprimirGuia();
        }

        private void SetUp(eAccion accion)
        {
            switch (accion)
            {
                case eAccion.MODIFICAR:

                    lblTituloSolicitud.Text = "MODIFICACION";
                    lblDniAccion.Text = "Ingrese el DNI del usuario que desea modificar";

                    break;
                case eAccion.BAJA:
                    lblTituloSolicitud.Text = "BAJA";
                    lblDniAccion.Text = "Ingrese el DNI del usuario que desea dar de baja";

                    break;             
            }
        }

        private void ImprimirUnaPersonaGuia(Persona persona)
        {            
            int n = dtgvCliente.Rows.Add();
            dtgvCliente.Rows[n].Cells[0].Value = persona.Dni.ToString();
            dtgvCliente.Rows[n].Cells[1].Value = persona.Nombre.ToString();
            dtgvCliente.Rows[n].Cells[2].Value = persona.Activo;
        }

        private void ImprimirGuia()
        {

           
            foreach (Persona unaPersona in Listpersonas)
            {

                ImprimirUnaPersonaGuia(unaPersona);

            }


        }

        private bool VerificarDniErrorProvider(string mensajeError1, string mensajeError2)
        {
            bool isValid = true;
            if (!Persona.DniIsValid(txtDniModificar.Text))
            {
                errorProviderDni.SetError(txtDniModificar, mensajeError1);
                isValid = false;

            }
            else if (Persona.DniIsValid(txtDniModificar.Text) && !Persona.EstaEnLista(txtDniModificar.Text, Listpersonas))
            {
                errorProviderDni.SetError(txtDniModificar, mensajeError2);
                isValid = false;
            }
            else
            {
                errorProviderDni.SetError(txtDniModificar, string.Empty);
                
            }
    
                return isValid;
        }

        private void txtDniModificar_TextChanged(object sender, EventArgs e)
        {
            VerificarDniErrorProvider("Solo se permiten numeros en el DNI y debe tener 6-9 digitos maximo", "No se encuentra registrado este DNI en la lista de clientes");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (VerificarDniErrorProvider("Solo se permiten numeros en el DNI y debe tener 6-9 digitos maximo", "No se encuentra registrado este DNI en la lista de clientes") )
            {
                switch (accionARealizar)
                {
                    case eAccion.MODIFICAR:
                        FrmModificacion frmModificacion = new FrmModificacion(Listpersonas.Find(personaEncontrada => personaEncontrada.Dni == int.Parse(txtDniModificar.Text)),Listpersonas);
                        frmModificacion.ShowDialog();
                        break;
                    case eAccion.BAJA:
                        Persona clienteDarBaja = Listpersonas.Find(personaEncontrada => personaEncontrada.Dni == int.Parse(txtDniModificar.Text));
                        if (clienteDarBaja.Activo)
                        {
                            clienteDarBaja.Activo = false;
                            MessageBox.Show(clienteDarBaja.ToString(), "Dado de baja con exito");                        
                        }
                        else
                        {
                            MessageBox.Show(clienteDarBaja.ToString(), "El Cliente ya esta Dado de Baja");
                        }
                       
                        break;
                
                }
                this.Hide();
                this.Close();

            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
