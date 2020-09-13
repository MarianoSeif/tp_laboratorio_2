using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado=0;
            operador = Calculadora.ValidarOperador(operador[0]);
            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
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
