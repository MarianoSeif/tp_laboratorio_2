using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;

namespace UnitTests
{
    [TestClass]
    public class UnitTest_Collections
    {

        /// <summary>
        /// Test para corroborar un atributo del tipo Collection
        /// </summary>
        [TestMethod]
        public void TestUniversidadAlumnosCollection()
        {
            //Act
            Universidad universidad = new Universidad();
            //Assert
            Assert.IsNotNull(universidad.Alumnos);
        }
    }
}
