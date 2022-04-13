using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Verifica que operador sea una de las opciones validad en caso erroneo asigna la suma como valor predeterminado
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                return operador;
            }
            else
            {
                return '+';
            }
        }
        /// <summary>
        /// Realiza la operacion basica correspondiente deacuerdo al operador asignado mediante un swicht
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double respuesta = 0;
            switch (operador)
            {
                case '+':
                    respuesta = num1 + num2;
                    break;
                case '-':
                    respuesta = num1 - num2;
                    break;
                case '*':
                    respuesta = num1 * num2;
                    break;
                case '/':
                    respuesta = num1 / num2;
                    break;
            }
            return respuesta;
        }
    }
}
