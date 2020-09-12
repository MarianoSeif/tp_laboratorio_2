using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    static class Calculadora
    {
        static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado=0;
            char[] operadorChar = operador.ToCharArray(0, 1);
            operador = Calculadora.ValidarOperador(operadorChar[0]);
            switch (operador)
            {
                case "+":
                    resultado = (double)(num1 + num2);
                    break;
                case "-":
                    resultado = (double)(num1 - num2);
                    break;
                case "*":
                    resultado = (double)(num1 * num2);
                    break;
                case "/":
                    resultado = (double)(num1 / num2);
                    break;
            }

            return resultado;
        }

        private static string ValidarOperador(char operador)
        {
            string retorno;
            switch (operador)
            {
                case '+':
                case '-':
                case '/':
                case '*':
                    retorno = operador.ToString();
                    break;
                default:
                    retorno = "+";
                    break;
            }
            return retorno;
        }
    }
}
