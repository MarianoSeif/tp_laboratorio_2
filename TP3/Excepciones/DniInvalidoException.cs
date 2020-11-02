using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException():base("Dni inválido")
        {
        }

        public DniInvalidoException(Exception e) : base("Dni inválido", e)
        {

        }

        public DniInvalidoException(string message):base(message)
        {

        }

        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }
    }
}
