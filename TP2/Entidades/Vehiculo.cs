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

       protected EMarca marca;
       protected string chasis;
       protected ConsoleColor color;

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected virtual ETamanio Tamanio { get;}

        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        

        #endregion Campos y propiedades

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }      

        public static  explicit  operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(p.GetType().Name.ToUpper());
            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendFormat("---------------------");
            sb.Append($"\n\n\r\rTAMAÑO : {p.Tamanio}");
            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
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

        /*
        public override bool Equals(object obj)
        {
            bool rta = false;
            if (obj is Vehiculo vehiculo && vehiculo == this)
            {
                rta = true;
            }
            return rta;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        */
    }
}
