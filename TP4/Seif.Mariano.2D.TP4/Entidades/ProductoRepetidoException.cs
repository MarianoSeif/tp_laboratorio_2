using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoRepetidoException : Exception
    {
        public ProductoRepetidoException():base("El producto ya existe")
        {
        }
    }
}
