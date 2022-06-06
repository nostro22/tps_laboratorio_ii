using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3ClassLibrary
{
    public class Afiliado : Persona
    {
        //private eTipoAfiliado tipoAfiliado;
        private DateTime fechaContratacion;
        
        public Afiliado() : base()
        {
        }


        public Afiliado(int dni, string nombre, DateTime fechaNacimiento, DateTime fechaContratacion) : base(dni,nombre,fechaNacimiento)
        {
            this.FechaContratacion = fechaContratacion;
        }

        public eTipoAfiliado TipoAfiliado
        {
            get
            {
                eTipoAfiliado tipoAfiliado;
                
                int antiguedad = CalcularAntiguedad();
               
                tipoAfiliado = eTipoAfiliado.trainee;
                
                if (antiguedad <= 2 && antiguedad > 4)
                {
                    tipoAfiliado = eTipoAfiliado.junior;
                }
                else if (antiguedad >= 4 )
                {
                    tipoAfiliado = eTipoAfiliado.senior;
                }

                return tipoAfiliado;
            }
          
        }

        public override string ToString() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
                   
            sb.AppendLine($"Facturacion: {eTipo.afiliado}");
            sb.AppendLine($"Aniversario: {((Afiliado)this).FechaContratacion.Date}");            

            return sb.ToString();
        }
        public DateTime FechaContratacion
        {
            get
            {
                return fechaContratacion;
            }

            set
            {
                fechaContratacion = value;
            }
        }

        private int CalcularAntiguedad()
        {
            DateTime today = DateTime.Today;
          
            int antiguedad = today.Year - FechaContratacion.Year;


            if (FechaContratacion.Date > today.AddYears(-antiguedad))
            {
                antiguedad--;
            }
            
            return antiguedad;
        }

       
       
        
    }
   
}
