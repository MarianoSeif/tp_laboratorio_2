using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(string message) : base(message)
        {
        }
        public ArchivosException(Exception innerException) : base("Error de Archivo", innerException)
        {
        }
    }
}
