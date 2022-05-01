﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
       public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
       public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        #region Campos y propiedades

       private EMarca marca;
       private string chasis;
       private ConsoleColor color;

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get;}

        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        

        #endregion 

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }      
        /// <summary>
        /// SobreCarga de string vehiculos usando el getType.name obtengo el tipo de clase de vehiculo 
        /// </summary>
        /// <param name="p"></param>
        public static  explicit  operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(p.GetType().Name.ToUpper());
            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendFormat("---------------------");
            sb.AppendFormat("\n\n\r\rTAMAÑO : {0}",p.Tamanio);
            return sb.ToString();
        }

        /// <summary>
        /// SobreCarga de == Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1 is Vehiculo && v2 is Vehiculo && v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1==v2);
        }

    }
}
