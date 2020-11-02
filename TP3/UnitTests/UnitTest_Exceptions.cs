using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using ClasesAbstractas;
using Excepciones;
using Archivos;

namespace UnitTests
{
    [TestClass]
    public class UnitTest_Exceptions
    {
        /// <summary>
        /// Test para la Excepcion ArchivosException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestArchivosException()
        {
            //Arrange
            Xml<Universidad> xmlManager = new Xml<Universidad>();
            //Act
            xmlManager.Guardar("", null);
        }


        /// <summary>
        /// Test para la Excepcion AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException()
        {
            //Arrange
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno(1, "Pepe", "Peposo", "30000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            //Act
            universidad += alumno;
            universidad += alumno;
        }


        /// <summary>
        /// Test para la Excepcion SinProfesorException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesorException()
        {
            //Arrange
            Universidad universidad = new Universidad();
            //Act
            Profesor profesor = (universidad == Universidad.EClases.Laboratorio);
        }
    }
}
