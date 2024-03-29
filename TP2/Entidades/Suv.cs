﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv:Vehiculo
    {
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color){}
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        /// <summary>
        /// Muestra los Suv usando el mostrar de la clase base y colocando el ----------
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar()); 
            sb.Append("---------------------");

            return sb.ToString();
        }
    }
}
