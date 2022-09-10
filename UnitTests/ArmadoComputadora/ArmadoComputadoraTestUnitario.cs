using Aplicacion;
using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class ArmadoComputadoraTestUnitario
    {
        [TestMethod]
        public void ArmarComputadoraGamaBajaPrecio()
        {
            var requerimiento = new RequerimientoArmado("Gaming juegos competitivos", "precio", 150000);
            var director = new DirectorArmadorComputadora(requerimiento);
            var computadora = director.Computadora;

            Assert.IsNotNull(computadora);
            Assert.IsTrue(computadora.Componentes.Count() > 6);
            Assert.IsTrue(computadora.Precio <= 150000);
        }

        [TestMethod]
        public void ArmarComputadoraGamaBajaCalidad()
        {
            var requerimiento = new RequerimientoArmado("Gaming juegos competitivos", "calidad", 150000);
            var director = new DirectorArmadorComputadora(requerimiento);
            var computadora = director.Computadora;

            Assert.IsNotNull(computadora);
            Assert.IsTrue(computadora.Componentes.Count() > 6);
            Assert.IsTrue(computadora.Precio <= 150000);
        }

        [TestMethod]
        public void ArmarComputadoraGamaMediaPrecio()
        {
            var requerimiento = new RequerimientoArmado("Arquitectura", "precio", 300000);
            var director = new DirectorArmadorComputadora(requerimiento);
            var computadora = director.Computadora;

            Assert.IsNotNull(computadora);
            Assert.IsTrue(computadora.Componentes.Count() > 6);
            Assert.IsTrue(computadora.Precio <= 300000);
        }

        [TestMethod]
        public void ArmarComputadoraGamaMediaCalidad()
        {
            var requerimiento = new RequerimientoArmado("Arquitectura", "calidad", 300000);
            var director = new DirectorArmadorComputadora(requerimiento);
            var computadora = director.Computadora;

            Assert.IsNotNull(computadora);
            Assert.IsTrue(computadora.Componentes.Count() > 6);
            Assert.IsTrue(computadora.Precio <= 300000);
        }

        [TestMethod]
        public void ArmarComputadoraGamaAltaPrecio()
        {
            var requerimiento = new RequerimientoArmado("Arquitectura", "precio", 450000);
            var director = new DirectorArmadorComputadora(requerimiento);
            var computadora = director.Computadora;

            Assert.IsNotNull(computadora);
            Assert.IsTrue(computadora.Componentes.Count() > 6);
            Assert.IsTrue(computadora.Precio <= 450000);
        }

        [TestMethod]
        public void ArmarComputadoraGamaAltaCalidad()
        {
            var requerimiento = new RequerimientoArmado("Edicion de video", "calidad", 450000);
            var director = new DirectorArmadorComputadora(requerimiento);
            var computadora = director.Computadora;

            Assert.IsNotNull(computadora);
            Assert.IsTrue(computadora.Componentes.Count() > 6);
            Assert.IsTrue(computadora.Precio <= 450000);
        }
    }
}