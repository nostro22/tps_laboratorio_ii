using System;
using System.Text;

namespace TP3ClassLibrary
{

    /// <summary>
    /// Es un clase que hereda de persona igual que Cliente, Queria probar modificacion con herencia y manejo de ambas en una sola listas genericas persona y como  solucionar modificacion si habian cambios de Clase
    /// </summary>

    public class Afiliado : Persona
    {
     
        private DateTime fechaContratacion;
        
        public Afiliado() : base()
        {
        }


        public Afiliado(int dni, string nombre, DateTime fechaNacimiento, DateTime fechaContratacion) : base(dni,nombre,fechaNacimiento)
        {
            this.FechaContratacion = fechaContratacion;
        }
        /// <summary>
        /// El tipo de afiliado se determina de forma automatica con la antiguedad dato no alterable que es setea al dar el alta, Esto da beneficios de descuentos en base a su valor
        /// </summary>
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
                   
            sb.AppendLine($"Facturacion: {eTipo.Afiliado}");
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

        /// <summary>
        /// Devuelve la antiguedad tomando como cuenta el momento donde se dio el alta
        /// </summary>
        /// <returns></returns>
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
