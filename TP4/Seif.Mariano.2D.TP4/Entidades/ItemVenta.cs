using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ItemVenta
    {
        Venta venta;
        Producto producto;
        int cantidad;

        public Venta Venta { get => venta; set => this.venta = value; }
        public Producto Producto { get => producto; set => this.producto = value; }
        public int Cantidad { get => cantidad; set => this.cantidad = cantidad; }
        
        public ItemVenta()
        {
        }

        public ItemVenta(Producto producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
        }

    }
}
