using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Operando encargada para la validacion de ingresos y realizacion de operaciones matematicas 
    /// </summary>
    public class Operando
    {
        #region Campos    
        private double numero;
        #endregion Campos

        #region Propiedades
        private string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }
        #endregion Propiedades

        #region Constructor
        public Operando()
        {
            this.numero = 0;
        }
        public Operando(double numero)
        {
            this.numero = numero;
        }
        public Operando(string strNumero)
        {
            if(string.IsNullOrEmpty(strNumero))
            {
                strNumero = "0";
            }
            this.Numero = strNumero;
        }
        #endregion Constructor



        #region Metodos

        /// <summary>
        /// Recibe un double, realizando el valor absoluto tomando solo la parte entera positiva y devolviendo el binario que lo represente si existe
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>si el ingreso es valido un string con numero Binario Representativo. Si no es valido mensaje de error "Valor invalido"</returns>
        public static string DecimalABinario(double numero)
        {
            string numeroBinarioInverso = string.Empty;
            string numeroBinario = string.Empty;
            string respuesta = string.Empty;

            int residuo = (int)(MathF.Abs((float)numero));

            if (residuo >= 0)
            {
                if (residuo == 0)
                {
                    numeroBinario = "0";
                }
                while (residuo > 0)
                {
                    numeroBinarioInverso += (residuo % 2).ToString();
                    residuo = residuo / 2;
                }
                for (int i = numeroBinarioInverso.Length - 1; i >= 0; i--)
                {
                    numeroBinario += numeroBinarioInverso[i];
                }
                respuesta = numeroBinario;
            }
            else
            {
                respuesta = "Valor inválido";
            }
            return respuesta;
        }
        /// <summary>
        /// Recibe un string, determina si es un numero de ser asi llama a DecimalABinario que convierte el numero a binario de ser posible sino devuelve un mensaje de error
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns>si es posible devuelve un string con el numero binario sino un mensaje de error</returns>
        public static string DecimalABinario(string numeroString)
        {
            double numero = 0;
            if (double.TryParse(numeroString,out numero))
            {
                return DecimalABinario(numero);
            }
            else
            {
                return "Valor inválido";
            }
        }
        /// <summary>
        ///  Recibe un string, invoca a esBinario que determina si el numero es   de ser asi llama a DecimalABinario que convierte el numero a binario de ser posible sino devuelve un mensaje de error
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        public static string BinarioADecimal(string numeroString)
        {
            string arrayBinario = string.Empty;
            string arrayBinarioInverso = string.Empty;
            string respuesta = string.Empty;
            int numeroEnteroObtenido = 0;
            if (EsBinario(numeroString))
            {
                float numero = float.Parse(numeroString);
                int enteroAux = (int)MathF.Floor(MathF.Abs(numero));
                arrayBinario = enteroAux.ToString();

                for (int i = arrayBinario.Length - 1; i >= 0; i--)
                {
                    arrayBinarioInverso += arrayBinario[i];
                }
                for (int i = 0; i < arrayBinarioInverso.Length; i++)
                {
                    if (arrayBinarioInverso[i] == '1')
                    {
                        numeroEnteroObtenido += (int)MathF.Pow(2, i);
                    }
                }
                respuesta = numeroEnteroObtenido.ToString();
            }
            else
            {
                respuesta = "Valor inválido";
            }
            return respuesta;
        }

        /// <summary>
        /// Determina si el string es un numero binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns> true si es binario || false en caso contrario</returns>
        private static bool EsBinario(string binario)
        {
            bool esBinario = true;
            foreach (var item in binario)
            {
                if (item != '1' && item != '0')
                {
                    esBinario = false;
                }
            }
            return esBinario;
        }
        /// <summary>
        /// Verifica que el string sea un operando valido es decir un numero double 
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarOperando(string strNumero)
        {
            double numero = 0;
            StringBuilder strNumeroDecimal = new StringBuilder(strNumero);
            strNumeroDecimal.Replace('.', ',');
            double.TryParse(strNumeroDecimal.ToString(), out numero);

            return numero;
        }


        #endregion Metodos

        #region SobrecargaOperadores
        /// <summary>
        /// Toma los atributos  numeros double de los operando y los resta
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>devuelce un double con el resultado de la resta de los operando </returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Toma los atributos  numeros double de los operando y los suma
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>double con el valor de la suma de los atributos de los operando</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Toma los atributos  numeros double de los operando y los divide
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> si el divisor es != 0 devuelve double con el resultado de la division. Si no devuelve el double MinValue </returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return (n1.numero / n2.numero);
            }
            else
            {
                return double.MinValue;
            }
        }
        /// <summary>
        /// Toma los atributos  numeros double de los operando y los divide
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> double con el resultado de la multiplicacion</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            double respuesta = n1.numero * n2.numero;
            //Fix -0 error;that result on the (n1=negative * n2)=-0 and in  (n2=negative * n1=0)=-0
            if (respuesta == 0)
            {
                respuesta = (double)MathF.Abs((float)respuesta);
            }
            return respuesta;

        }
        #endregion SobrecargaOperadores

    }
}
