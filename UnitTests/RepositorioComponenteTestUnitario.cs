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
            //act
            var rows = new RepositorioComponenteAlta().Agregar(ComponenteTest);
            
            //assert
            Assert.IsTrue(rows == 1);

            //exit
            new RepositorioComponenteBaja().Eliminar(new RepositorioComponenteSoloLectura().ObtenerTodos.Max(c => c.Id));
        }

        [TestMethod]
        public void Baja()
        {
            //arrange
            new RepositorioComponenteAlta().Agregar(ComponenteTest);

            //act
            var rows = new RepositorioComponenteBaja().Eliminar(new RepositorioComponenteSoloLectura().ObtenerTodos.Max(c => c.Id));

            //assert
            Assert.IsTrue(rows == 1);
        }

        [TestMethod]
        public void Modificacion()
        {
            //arrange
            new RepositorioComponenteAlta().Agregar(ComponenteTest);
            var componente = ComponenteTest;
            componente.Nombre = "testModificado";
            componente.Id = new RepositorioComponenteSoloLectura().ObtenerTodos.Max(c => c.Id);

            //act
            var rows = new RepositorioComponenteModificacion().Actualizar(componente);

            //assert
            Assert.IsTrue(rows == 1);

            //exit
            new RepositorioComponenteBaja().Eliminar(new RepositorioComponenteSoloLectura().ObtenerTodos.Max(c => c.Id));
        }

        [TestMethod]
        public void Obtener()
        {
            //arrange
            var repositorio = new RepositorioComponenteSoloLectura();

            //act
            var componentes = repositorio.ObtenerTodos;

            //assert
            Assert.IsTrue(componentes.Any());
        }

        private static Componente ComponenteTest => new Componente()
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
