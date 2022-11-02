using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class RepositorioComponenteTestUnitario
    {
        [TestMethod]
        public void Alta()
        {
            //act assert
            Assert.IsTrue(RepositorioAlta.Agregar(ComponenteTest) == 1);

            //exit
            RepositorioBaja.Eliminar(RepositorioLectura.ObtenerTodos.Max(c => c.Id));
        }

        [TestMethod]
        public void Baja()
        {
            //arrange
            RepositorioAlta.Agregar(ComponenteTest);

            //act assert
            Assert.IsTrue(RepositorioBaja.Eliminar(RepositorioLectura.ObtenerTodos.Max(c => c.Id)) == 1);
        }

        [TestMethod]
        public void Modificacion()
        {
            //arrange
            RepositorioAlta.Agregar(ComponenteTest);
            var componente = ComponenteTest;
            componente.Nombre = "testModificado";
            componente.Id = RepositorioLectura.ObtenerTodos.Max(c => c.Id);

            //act assert
            Assert.IsTrue(RepositorioModificacion.Modificar(componente) == 1);

            //exit
            RepositorioBaja.Eliminar(RepositorioLectura.ObtenerTodos.Max(c => c.Id));
        }

        [TestMethod]
        public void Obtener() =>
            //arrange act assert
            Assert.IsTrue(RepositorioLectura.ObtenerTodos.Any());

        private RepositorioComponenteSoloLectura RepositorioLectura => new RepositorioComponenteSoloLectura();
        private RepositorioComponenteBaja RepositorioBaja => new RepositorioComponenteBaja();
        private RepositorioComponenteAlta RepositorioAlta => new RepositorioComponenteAlta();
        private RepositorioComponenteModificacion RepositorioModificacion => new RepositorioComponenteModificacion();

        private Componente ComponenteTest => new Componente()
        {
            Id = 1,
            Canales = 1,
            Capacidad = 1,
            ConsumoEnWatts = 1,
            MaximaFrecuencia = 1,
            NecesitaAltaFrecuencia = true,
            NivelFanIntegrado = 1,
            NivelVideoIntegrado = 1,
            Nombre = "test",
            Perfomance = 1,
            Precio = 1,
            Socket = "test",
            Stock = 1,
            StockLimite = 1,
            TamanoFan = 1,
            TieneVideoIntegrado = true,
            Tipo = "test",
            TipoFormato = "test",
            TipoMemoria = "test"
        };
    }
}