using System;

namespace Entidades
{
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
            this.Numero = strNumero;
        }
        #endregion Constructor



        #region Metodos

        public static string DecimalABinario(double numero)
        {
            string numeroBinarioInverso = string.Empty;
            string numeroBinario = string.Empty;
            string respuesta = string.Empty;

            int residuo = (int)(MathF.Abs((float)numero));
            
            if(residuo>=0)
            {
                if(residuo==0)
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

        public static string BinarioADecimal(double numero)
        {
            string arrayBinario = string.Empty;
            string arrayBinarioInverso = string.Empty;
            string respuesta = string.Empty;
            int numeroEnteroObtenido = 0;
            int enteroAux = (int)MathF.Floor(MathF.Abs((float)numero));
            arrayBinario = enteroAux.ToString();
            if (EsBinario(arrayBinario))
            {
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


        private static bool EsBinario(string binario)
        {

            for (int i = binario.Length - 1; i >= 0; i--)
            {
                if (binario[i] != '1' && binario[i] != '0')
                {
                    return false;
                }
            }
            return true;
        }

        private double ValidarOperando(string strNumero)
        {

            if (double.TryParse(strNumero, out numero))
            {
                numero = double.Parse(strNumero);
            }
            else
            {
                numero = 0;
            }
            return numero;
        }


        public double GetNumero()
        {
            return this.numero;
        }
        #endregion Metodos

        #region SobrecargaOperadores
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
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
