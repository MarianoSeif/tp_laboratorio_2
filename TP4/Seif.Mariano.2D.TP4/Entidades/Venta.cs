using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta : IVerbose
    {
        private Cliente cliente;
        private List<ItemVenta> items;
        private int total;

        public string Message
        {
            get {
                StringBuilder sb = new StringBuilder();
                sb.Append("Venta realizada - ");
                sb.Append($"Cliente: {this.cliente.Nombre} - ");
                return sb.ToString();
            }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public List<ItemVenta> Items
        {
            get { return this.items; }
        }

        public Venta()
        {
        }

        public Venta(Cliente cliente, List<ItemVenta> items)
        {
            this.cliente = cliente;
            this.items = items;
        }

        /// <summary>
        /// Metodo implementado para cumplir con la interface IVerbose
        /// </summary>
        public void MostrarDatos()
        {
            int cantidad = 0;
            foreach (ItemVenta item in items)
            {
                cantidad += item.Cantidad;
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cliente: {this.cliente.Nombre}");
            sb.AppendLine($"Cantidad de Productos comprados: {cantidad}");
            Console.WriteLine(sb.ToString());
        }
    }
}
