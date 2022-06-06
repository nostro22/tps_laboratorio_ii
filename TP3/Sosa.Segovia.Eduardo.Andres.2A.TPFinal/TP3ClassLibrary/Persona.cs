using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TP3ClassLibrary
{


    [XmlInclude(typeof(Afiliado))]
    [XmlInclude(typeof(Cliente))]
    public abstract class  Persona
    {
      
        protected int dni;
        protected string nombre;
        protected DateTime fechaNacimiento;
        private bool activo;
        public Persona()
        {        
        }

        public Persona(int dni, string nombre, DateTime fechaNacimiento)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
            this.activo = true;
        }

        public int Dni
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }

            set
            {
                fechaNacimiento = value;
            }
        }

        public bool Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"DNI: {this.dni}");
            sb.Append("Nombre: " + this.nombre.ToUpper());
            sb.AppendFormat($"Fecha Nacimiento: ${this.FechaNacimiento.Date}");           

            return sb.ToString();
        }

        public static List<Persona> ListaActivos(List<Persona> list)
        {
            List<Persona> listaFiltrada = new List<Persona>();

            if (list != null && list.Count > 0)
            {
            
                foreach (Persona item in list)
                {
                    if (item.Activo)
                    {
                        listaFiltrada.Add(item);
                    }
                }
            }

            return listaFiltrada;
        }

        public static bool NombreIsValid(string nombre)
        {
            bool retorno = true;
            foreach (char unChar in nombre)
            {
                if (char.IsDigit(unChar))
                {
                    retorno = false;
                }
            }
            if (string.IsNullOrWhiteSpace(nombre))
            {
                retorno = false;
            }
            return retorno;
        }

        public static bool DniIsValid(string dni)
        {
            bool retorno = false;
            if (!string.IsNullOrWhiteSpace(dni))
            {
                retorno = true;
                dni =dni.TrimStart(new Char[] {'0'});
                if (dni.Length >=9 || dni.Length<6)
                {
                    retorno = false;
                   
                }
                else
                {
                    foreach (char unChar in dni)
                    {
                        if (char.IsLetter(unChar))
                        {
                            retorno =false;
                            break;
                        }
                    }                

                }
            }

            return retorno;
        }

        public static bool EsMayorEdad(DateTime fechaDeNacimiento)
        {
            DateTime today = DateTime.Today;
            bool retorno = true;
           
            int edad = today.Year - fechaDeNacimiento.Year;


            if (fechaDeNacimiento.Date > today.AddYears(-edad))
            {
                edad--;
            }

            if (edad < 18)
            {
                retorno = false;            
            }

            return retorno;
        }

        public static bool EstaEnLista(string dni, List<Persona> lista)
        {
            dni = dni.TrimStart(new Char[] { '0' });

            if (DniIsValid(dni))
            {
                foreach (Persona unaPersona in lista)
                {
                    if (unaPersona.Dni == int.Parse(dni))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        

        public static List<string> GetNamesDni(List<Persona> lista)
        {
            List<string> listaActivos = new List<string>();
            foreach (Persona item in lista)
            {
                if (item is Persona unPersona)
                    listaActivos.Add($"{unPersona.Dni} - {unPersona.Nombre}");
            }

            return listaActivos;
        }

        public static Persona GetPersonaWtihResumen(List<Persona> lista, string resumenPersona)
        {
            resumenPersona = resumenPersona.Trim(' ');
            string[] arrayString = resumenPersona.Split('-');
            string dniPersona = arrayString[0];           
            foreach (Persona item in lista)
            {
                if (int.Parse(dniPersona) == item.Dni)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
