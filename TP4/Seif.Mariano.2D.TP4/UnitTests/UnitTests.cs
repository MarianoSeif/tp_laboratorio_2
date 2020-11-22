using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestCrearProducto()
        {
            //Arrange
            Producto producto = new Producto("Producto_" + DateTime.Now.Millisecond.ToString(), 20, 20);
            //Act
            SuperMercado.AgregarProducto(producto);
            //Assert
            Assert.AreEqual<Producto>(SuperMercado.listadoProductos[SuperMercado.listadoProductos.Count-1], producto);
        }

        [TestMethod]
        public void TestCrearVentaSerializarDeserializar()
        {
            //Arrange
            Cliente cliente = new Cliente(1, "Un cliente");
            List<ItemVenta> items = new List<ItemVenta>();
            items.Add(new ItemVenta(new Producto("Producto_" + DateTime.Now.Millisecond.ToString(), 20, 20), 1));
            //Act
            Venta venta = new Venta(cliente, items);
            Venta objetoDeserializado;
            Serializador<Venta>.Guardar("venta.xml", venta);
            Serializador<Venta>.Leer("venta.xml", out objetoDeserializado);
            //Assert
            Assert.AreEqual(objetoDeserializado.Cliente.Id , venta.Cliente.Id);    
        }
    }
}
