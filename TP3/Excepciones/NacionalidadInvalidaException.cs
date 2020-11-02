using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException():base("Nacionalidad inválida")
        {
        }

        public NacionalidadInvalidaException(string message):base(message)
        {
        }
    }
}
