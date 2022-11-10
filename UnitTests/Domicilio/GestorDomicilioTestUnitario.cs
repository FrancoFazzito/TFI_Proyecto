using Aplicacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class GestorDomicilioTestUnitario
    {

        [TestMethod]
        public void ObtenerBarrios() =>
            //arrange act assert
            Assert.IsTrue(new GestorDomicilio().Barrios.Any());

        [TestMethod]
        public void ObtenerProvincias() =>
            //arrange act assert
            Assert.IsTrue(new GestorDomicilio().Provincias.Any());
    }
}