using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3ClassLibrary
{
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Facturacion: {((Cliente)this).Tipo}");


            return sb.ToString();
        }
        public Cliente(int dni, string nombre, DateTime fechaNacimiento,eTipo tipo) : base(dni, nombre, fechaNacimiento)
        {
            this.tipo = tipo;
            if (tipo == eTipo.afiliado)
            {
                this.tipo = eTipo.particular;
            }
        }

     
    }
  


}
