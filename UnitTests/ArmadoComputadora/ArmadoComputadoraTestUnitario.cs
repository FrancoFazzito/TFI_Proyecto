using Aplicacion;
using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        [TestMethod]
        public void ArmarComputadoraGamaBajaCalidad()
        {
            var requerimiento = new RequerimientoArmado("Gaming juegos competitivos", "calidad", 150000);
            var director = new DirectorArmadorComputadora(requerimiento);
            var computadora = director.Computadora;

            Assert.IsNotNull(computadora);
            Assert.IsTrue(computadora.Componentes.Count() > 6);
        }

        [TestMethod]
        public void ArmarComputadoraGamaMediaPrecio()
        {
            var requerimiento = new RequerimientoArmado("Arquitectura", "precio", 300000);
            var director = new DirectorArmadorComputadora(requerimiento);
            var computadora = director.Computadora;

            Assert.IsNotNull(computadora);
            Assert.IsTrue(computadora.Componentes.Count() > 6);
        }

        [TestMethod]
        public void ArmarComputadoraGamaMediaCalidad()
        {
            var requerimiento = new RequerimientoArmado("Arquitectura", "calidad", 300000);
            var director = new DirectorArmadorComputadora(requerimiento);
            var computadora = director.Computadora;

            Assert.IsNotNull(computadora);
            Assert.IsTrue(computadora.Componentes.Count() > 6);
        }

        [TestMethod]
        public void ArmarComputadoraGamaAltaPrecio()
        {
            var requerimiento = new RequerimientoArmado("Arquitectura", "precio", 450000);
            var director = new DirectorArmadorComputadora(requerimiento);
            var computadora = director.Computadora;

            Assert.IsNotNull(computadora);
            Assert.IsTrue(computadora.Componentes.Count() > 6);
        }

        [TestMethod]
        public void ArmarComputadoraGamaAltaCalidad()
        {
            var requerimiento = new RequerimientoArmado("Edicion de video", "calidad", 450000);
            var director = new DirectorArmadorComputadora(requerimiento);
            var computadora = director.Computadora;

            Assert.IsNotNull(computadora);
            Assert.IsTrue(computadora.Componentes.Count() > 6);
        }
    }
}
