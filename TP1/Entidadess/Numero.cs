using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Constructor por defecto inicializa el atributo numero en cero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="numero">Valor numérico para asignar al atributo numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor parametrizado (sobrecarga)
        /// </summary>
        /// <param name="strNumero">String conteniendo el valor numérico para asignar al atributo numero</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Convierte el número recibido de base 2 a base 10
        /// </summary>
        /// <param name="strNumero">String conteniendo un valor numerico en base 2</param>
        /// <returns>string</returns>
        public static string BinarioDecimal(string strNumero)
        {
            string retorno = "Valor inválido";
            if (EsBinario(strNumero))
            {
                double resultado = 0;
                for (int i = 0; i < strNumero.Length; i++)
                {
                    resultado += Char.GetNumericValue(strNumero, i) * Math.Pow(2, strNumero.Length - 1 - i);
                }
                retorno = resultado.ToString();
            }
            return retorno;
        }

        /// <summary>
        /// Convierte el numero recibido de base 10 a base 2
        /// </summary>
        /// <param name="numero">Numero en base 10 a convertir</param>
        /// <returns>string</returns>
        public static string DecimalBinario(double numero)
        {
            //Orden de calculo:
            //  Obtiene el valor absoluto
            //  Castea a entero
            //  Convierte a representacion numérica en base 2 de tipo string
            return Convert.ToString((int)Math.Abs(numero), 2);
        }

        /// <summary>
        /// Convierte el numero recibido de base 10 a base 2 (sobrecarga)
        /// </summary>
        /// <param name="strNumero">String conteniendo el valor numerico en base 10 a convertir</param>
        /// <returns>string</returns>
        public static string DecimalBinario(string strNumero)
        {
            if(double.TryParse(strNumero, out double numero))
            {
                return DecimalBinario(numero);
            }
            return "Valor inválido";
        }

        /// <summary>
        /// Determina si la representacion del numero contenido en el string recibido podría ser en base 2
        /// </summary>
        /// <param name="strNumero">String que contiene el numero a revisar</param>
        /// <returns>bool</returns>
        private static bool EsBinario(string strNumero)
        {
            for (int i = 0; i < strNumero.Length; i++)
            {
                if (strNumero[i] < '0' || strNumero[i] > '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Valida la representación de un número en tipo string
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>double numero | 0</returns>
        public static double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                return numero;
            } 
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Devuelve la resta de los atributos numero de dos Objetos Numero
        /// </summary>
        /// <param name="n1">Objeto Numero</param>
        /// <param name="n2">Objeto Numero</param>
        /// <returns>double</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Devuelve la suma de los atributos numero de dos Objetos Numero
        /// </summary>
        /// <param name="n1">Objeto Numero</param>
        /// <param name="n2">Objeto Numero</param>
        /// <returns>double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Devuelve elproducto de los atributos numero de dos Objetos Numero
        /// </summary>
        /// <param name="n1">Objeto Numero</param>
        /// <param name="n2">Objeto Numero</param>
        /// <returns>double</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Devuelve el cociente de los atributos numero de dos Objetos Numero
        /// </summary>
        /// <param name="n1">Objeto Numero</param>
        /// <param name="n2">Objeto Numero</param>
        /// <returns>double</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }

    }
}
