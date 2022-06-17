using System;
using System.Text;

namespace TP3ClassLibrary
{
    /// <summary>
    /// Un cliente que hereda de persona para ser facturado, facturacion toma en consideracion el tipo y le calcula un precio distinto
    /// </summary>
    public class Cliente : Persona
    { 
        private eTipo tipo;

        public eTipo Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }
        public Cliente():base()
        {
        }
        public Cliente(int dni, string nombre, DateTime fechaNacimiento,eTipo tipo) : base(dni, nombre, fechaNacimiento)
        {
            this.tipo = tipo;
            if (tipo == eTipo.afiliado)
            {
                this.tipo = eTipo.particular;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Facturacion: {((Cliente)this).Tipo}");


            return sb.ToString();
        }

     
    }
  


}
