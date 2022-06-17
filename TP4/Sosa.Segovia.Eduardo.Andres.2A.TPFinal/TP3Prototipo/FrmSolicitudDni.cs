using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TP3ClassLibrary;

namespace TP3Prototipo
{
    /// <summary>
    /// Se encarga de pedir DNI si es para modificar o eliminar muestra una ayuda listando a todos los clientes en el sistema
    /// </summary>
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
        /// <summary>
        /// Imprime ayuda con datos resumidos del cliente y lo coloca en la grilla
        /// </summary>
        /// <param name="persona"></param>
        private void ImprimirUnaPersonaGuia(Persona persona)
        {
            string estado = string.Empty;
            int n = dtgvCliente.Rows.Add();
            dtgvCliente.Rows[n].Cells[0].Value = persona.Dni.ToString();
            dtgvCliente.Rows[n].Cells[1].Value = persona.Nombre.ToString();
            if(persona.Activo)
            {
                estado = "Activo";
            }
            else
            {
                estado = "Inactivo";
            }
            dtgvCliente.Rows[n].Cells[2].Value = estado;
        }

        /// <summary>
        /// Recorre la lista e imprime a todos los cliente de la lista
        /// </summary>
        private void ImprimirGuia()
        {
            foreach (Persona unaPersona in Listpersonas)
            {

                ImprimirUnaPersonaGuia(unaPersona);

            }

        }

        /// <summary>
        /// Si el dni no esta en la lista te avisa que para modificar debe esta y si es para dar de baja adicionalemente verifica que este activo
        /// </summary>
        /// <param name="mensajeError1"></param>
        /// <param name="mensajeError2"></param>
        /// <returns></returns>
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

        /// <summary>
        /// llama al error provider del campo dni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDniModificar_TextChanged(object sender, EventArgs e)
        {
            VerificarDniErrorProvider("Solo se permiten numeros en el DNI y debe ser positivo", "No se encuentra registrado este DNI en la lista de clientes");
        }

        /// <summary>
        /// Procede a invocar al frm modificar o dar de baja segun corresponda Lo hice asi medio rebuscado para usar expresiones lamda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (VerificarDniErrorProvider("Solo se permiten numeros en el DNI ", "No se encuentra registrado este DNI en la lista de clientes") )
            {
                switch (accionARealizar)
                {
                    case eAccion.MODIFICAR:
                        FrmModificacion frmModificacion = new FrmModificacion(Listpersonas.Find(personaEncontrada => personaEncontrada.Dni == int.Parse(txtDniModificar.Text)),Listpersonas);
                        frmModificacion.ShowDialog();
                        ImprimirGuia();
                        break;
                    case eAccion.BAJA:
                        Persona clienteDarBaja = Listpersonas.Find(personaEncontrada => personaEncontrada.Dni == int.Parse(txtDniModificar.Text));
                        if (clienteDarBaja.Activo)
                        {
                            clienteDarBaja.Activo = false;
                            MessageBox.Show(clienteDarBaja.ToString(), "Dado de baja con exito");
                            ImprimirGuia();
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

        private void dtgvCliente_SelectionChanged(object sender, EventArgs e)
        {
            txtDniModificar.Text = dtgvCliente[0, dtgvCliente.CurrentRow.Index].Value.ToString();
        }
    }
}
