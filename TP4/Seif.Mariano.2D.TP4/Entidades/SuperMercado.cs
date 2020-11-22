using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    //Clase estática que maneja el negocio
    public static class SuperMercado
    {
        private static Random random;
        public static List<Producto> listadoProductos;
        public static List<Venta> listadoVentas;
        public static List<Cliente> listadoClientes;

        static SuperMercado()
        {
            random = new Random();
            listadoProductos = DB.TraerProductos();
            listadoClientes = DB.TraerClientes();
            listadoVentas = new List<Venta>();
        }
        
        /// <summary>
        /// Genera una venta con datos al azar (ya existentes, traidos de la base de datos)
        /// </summary>
        public static void GenerarVenta()
        {
            int cantItems = random.Next(1, 3);
            Cliente cliente = listadoClientes[random.Next(0, (listadoClientes.Count) - 1)];
            List<ItemVenta> items = new List<ItemVenta>();

            for (int i = 0; i < cantItems; i++)
            {
                int cantCadaProducto = random.Next(1, 3);
                int indice;
                Producto producto;
                do
                {
                    indice = random.Next(0, (listadoProductos.Count) - 1);
                    producto = listadoProductos[indice];
                } while (producto.Stock < 3);
                items.Add(new ItemVenta(producto, cantCadaProducto));
                listadoProductos[indice].Stock -= cantCadaProducto;
                DB.GuardarProducto(listadoProductos[indice], EDbOperation.update);
            }
            try
            {
                Venta venta = new Venta(cliente, items);
                listadoVentas.Add(venta);
                Logger.RegistrarEvento<Venta>(venta);
                Serializador<Venta>.Guardar("venta.xml", venta);
                DB.GuardarVenta(venta);
            }
            catch (Exception e)
            {
                throw new Exception("Error al generar la venta " + e.Message, e);
            }
        }

        /// <summary>
        /// Agrega el producto pasado por parametro a la lista del negocio, lo guarda en la base de datos, y genera una entrada en el archivo de log
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static bool AgregarProducto(Producto producto)
        {
            bool retorno;
            foreach (Producto item in listadoProductos)
            {
                if(String.Compare(producto.Descripcion, item.Descripcion) == 0)
                {
                    throw new ProductoRepetidoException();
                }
            }
            try
            {
                retorno = DB.GuardarProducto(producto, EDbOperation.insert);
                listadoProductos.Add(producto);
                Logger.RegistrarEvento<Producto>(producto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar guardar el producto - " + ex.Message, ex);
            }
            return retorno;
        }

        public static void MostrarProductos()
        {
            foreach (Producto item in listadoProductos)
            {
                item.MostrarDatos();
            }
        }

        /// <summary>
        /// Manejador del evento outOfStock de la clase Producto
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="producto"></param>
        public static void MostrarNotificacion(string mensaje, Producto producto)
        {
            Console.WriteLine($"El producto {producto.Descripcion} nos avisa que: {mensaje}");
        }
        public static void PonerStockEnCero()
        {
            int indice = random.Next(0, (listadoProductos.Count) - 1);
            if(listadoProductos[indice].Stock > 0)
            {
                listadoProductos[indice].Stock = 0;
                DB.GuardarProducto(listadoProductos[indice], EDbOperation.update);
            }
        }

        /// <summary>
        /// Serializa el listado de productos del negocio
        /// </summary>
        public static void SerializarProductos()
        {
            try
            {
                Serializador<List<Producto>>.Guardar("productos.xml", listadoProductos);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo serializar la lista de productos "+e.Message, e);
            }   
        }

        /// <summary>
        /// Deserializa el listado de productos del negocio
        /// </summary>
        public static List<Producto> DeserializarProductos()
        {
            List<Producto> listadoProductosDeserializados = new List<Producto>();
            try
            {
                Serializador<List<Producto>>.Leer("productos.xml", out listadoProductosDeserializados);
                return listadoProductosDeserializados;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo serializar la lista de productos " + e.Message, e);
            }
        }
    }
}
