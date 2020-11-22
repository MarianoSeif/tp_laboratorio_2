using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Test
{
    class Test
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Prueba de funcionalidades del TP4");
                Console.WriteLine("---------------------------------");
                //Generar una venta con datos aleatorios
                SuperMercado.GenerarVenta();
                //Mostrar la venta creada
                Console.WriteLine("Se trajeron datos de productos y clientes desde la base de datos");
                Console.WriteLine("Se generó una venta con datos random: ");
                SuperMercado.listadoVentas[SuperMercado.listadoVentas.Count() - 1].MostrarDatos();
                Console.WriteLine("A continuación se creará un producto para prueba: ");
                Producto producto = new Producto("Producto_"+DateTime.Now.Millisecond.ToString(), 10, 10);
                SuperMercado.AgregarProducto(producto);
                producto.MostrarDatos();
                Console.WriteLine("Se creó el producto, se guardó en la base de datos y se dejó registro en el log");

                Console.WriteLine("Se lanza el formulario...");
                FormAgregarProducto formAgregarProducto = new FormAgregarProducto();
                DialogResult resultado = formAgregarProducto.ShowDialog();
                
                if(resultado == DialogResult.Abort)
                {
                    Console.WriteLine("No se pudo guardar el producto");
                }

                Console.WriteLine("Saliendo...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Pasaron cosas..." + ex.Message);
                Logger.RegistrarEvento(ex);
            }
        }
    }
}
