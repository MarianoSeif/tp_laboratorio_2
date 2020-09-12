using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    class Numero
    {
        private double numero;

        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
                //numero = Convert.ToDouble(value);
            }
        }

        Numero()
        {
            numero = 0;
        }

        Numero(double numero)
        {

        }
        Numero(string strNumero)
        {

        }

        public string BinarioDecimal(string binario)
        {
            return Convert.ToInt32(binario).ToString();

            /*
            double numero = 0;
            if (EsBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    numero += (int)binario[i] * (Math.Pow(2, (binario.Length-i)));
                }
                return numero.ToString();
            }
            else
            {
                return "Valor Invalido";
            }
            */
        }

        public string DecimalBinario(double numero)
        {
            
            int num = (int)ValidarNumero(numero.ToString());
            return Convert.ToString(num, 2);
        }
        public string DecimalBinario(string numero)
        {
            int num = (int)ValidarNumero(numero);
            return Convert.ToString(num, 2);
        }

        private bool EsBinario(string binario)
        {
            bool isBinary = true;
            char[] numeroCharArray = binario.ToCharArray();
            foreach (var item in numeroCharArray)
            {
                if (item < '0' || item > '1')
                {
                    isBinary = false;
                    break;
                }
            }
            return isBinary;
        }        

        public double ValidarNumero(string strNumero)
        {
            bool isNumber = true;
            char[] numeroCharArray = strNumero.ToCharArray();
            foreach (var item in numeroCharArray)
            {
                if(item<'0' || item > '9' || item!='.')
                {
                    isNumber = false;
                    break;
                }
            }
            if (isNumber)
            {
                return Convert.ToDouble(strNumero);
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
