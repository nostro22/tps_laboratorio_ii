using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static char ValidarOperador(char operador)
        {
            if(operador=='+'|| operador == '-' || operador == '/' || operador == '*')
            {
                return operador;
            }
            else
            {
                return '+';
            }
        }
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
