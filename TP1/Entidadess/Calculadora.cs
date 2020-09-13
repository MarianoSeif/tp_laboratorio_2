using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operación pedida entre ambos números
        /// </summary>
        /// <param name="num1">Objeto tipo Numero</param>
        /// <param name="num2">Objeto tipo Numero</param>
        /// <param name="operador">String conteniendo el operador especificado</param>
        /// <returns>double</returns>
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

        /// <summary>
        /// Valida el operador pasado
        /// </summary>
        /// <param name="operador">String conteniendo el operador</param>
        /// <returns>string</returns>
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
