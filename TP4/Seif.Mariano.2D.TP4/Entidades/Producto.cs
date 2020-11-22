using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public delegate void NotifierDelegate(string mensaje, Producto producto);
    public class Producto : IVerbose
    {
        public event NotifierDelegate outOfStockEvent;
        private int id;
        private string descripcion;
        private double precio;
        private int stock;

        [System.ComponentModel.Browsable(false)]
        public string Message
        {
            get
            {
                return "Se creó un nuevo producto: " + this.descripcion;
            }
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        public int Stock
        {
            get { return this.stock; }
            set { 
                this.stock = value;
                if(this.stock == 0)
                {
                    outOfStockEvent.Invoke("Stock agotado!", this);
                }
            }
        }

        public Producto()
        {
            //Se agrega un manejador al evento outOfStock
            this.outOfStockEvent += SuperMercado.MostrarNotificacion;
        }
        public Producto(string descripcion, double precio, int stock) : this()
        {
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }

        public Producto(int id, string descripcion, double precio, int stock): this(descripcion, precio, stock)
        {
            this.id = id;
        }

        /// <summary>
        /// Metodo implementado para cumplir con la interface IVerbose
        /// </summary>
        public void MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Descripcion: {this.descripcion}");
            sb.AppendLine($"Precio: {this.precio}");
            sb.AppendLine($"Stock: {this.stock}");
            Console.WriteLine(sb.ToString());
        }
    }
}
