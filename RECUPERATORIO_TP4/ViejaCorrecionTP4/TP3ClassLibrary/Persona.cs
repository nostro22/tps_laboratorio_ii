﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TP3ClassLibrary
{
    /// <summary>
    /// Clase abstracta. No era lo mas optimo crear un cliente y un afiliado pero queria probar el manejo de listas genericas y modificacion entre clases distintas.
    /// Al tener herencia en la app solo se permite la suba de base de datos Personas .xml
    /// </summary>

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
            sb.AppendLine("Nombre: " + this.nombre.ToUpper());
            sb.AppendLine($"Fecha Nacimiento: {this.FechaNacimiento.Date.ToShortDateString()}");           

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


        /// <summary>
        /// Verificacion que el nombre no contenga numeros ni sea nulo
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Verificacion que el DNI sea  solo numeros y que no se usen ceros a la izquierda
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public static bool DniIsValid(string dni)
        {
            bool retorno = false;
            int dniNumerico;
            if (!string.IsNullOrWhiteSpace(dni) && int.TryParse(dni, out dniNumerico) && dniNumerico>0)
            {
                retorno = true;
                dni =dni.TrimStart(new Char[] {'0'});
                 foreach (char unChar in dni)
                 {
                        if (char.IsLetter(unChar))
                        {
                            retorno =false;
                            break;
                        }
                 }                

                
            }

            return retorno;
        }

        /// <summary>
        /// Verifica la mayoria de edad del usuario
        /// </summary>
        /// <param name="fechaDeNacimiento"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Usando el dni recorre la lista y verifica si esta en ella
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
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

        
        /// <summary>
        /// Funcion que retorna un string con el dni y nombre del usuario para servirle de guia en la interface al selecionar cliente a facturar
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna a la persona usando el dni obtenido del resumen de ayuda de la funcion GetNamesDni
        /// tambien devolvera a la persona si se ingresa un dni
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="resumenPersona"></param>
        /// <returns></returns>
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


        public string FullName
        {
            get
            {
                return $"{this.Dni} - {this.nombre}";
            }
        }
    }
}
