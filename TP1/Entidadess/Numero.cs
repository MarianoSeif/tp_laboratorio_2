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

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        public static string BinarioDecimal(string strNumero)
        {
            string retorno = "No se puede convertir";
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

        public static string DecimalBinario(double numero)
        {
            return Convert.ToString((int)Math.Abs(numero), 2);
        }
        public static string DecimalBinario(string strNumero)
        {
            double.TryParse(strNumero, out double numero);
            return DecimalBinario(numero);
        }

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

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
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
