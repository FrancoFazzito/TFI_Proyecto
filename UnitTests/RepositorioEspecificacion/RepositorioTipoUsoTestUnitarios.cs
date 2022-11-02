using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class RepositorioTipoUsoTestUnitario
    {
        [TestMethod]
        public void Alta()
        {
            //arrange act assert
            Assert.IsTrue(RepositorioAlta.Agregar(TipoUsoTest) == 1);

            //exit
            RepositorioBaja.Eliminar(RepositorioLectura.ObtenerTodos.Max(c => c.Id));
        }

        [TestMethod]
        public void Baja()
        {
            //arrange
            RepositorioAlta.Agregar(TipoUsoTest);

            //act assert
            Assert.IsTrue(RepositorioBaja.Eliminar(RepositorioLectura.ObtenerTodos.Max(c => c.Id)) == 1);
        }

        [TestMethod]
        public void Modificacion()
        {
            //arrange
            RepositorioAlta.Agregar(TipoUsoTest);
            TipoUso tipoUso = TipoUsoTest;
            tipoUso.Nombre = "testModificado";
            tipoUso.Id = RepositorioLectura.ObtenerTodos.Max(c => c.Id);

            //act assert
            Assert.IsTrue(RepositorioModificacion.Modificar(tipoUso) == 1);

            //exit
            RepositorioBaja.Eliminar(RepositorioLectura.ObtenerTodos.Max(c => c.Id));
        }

        [TestMethod]
        public void Obtener()
        {
            //arrange act assert
            Assert.IsTrue(RepositorioLectura.ObtenerTodos.Any());
        }

        private RepositorioTipoUsoSoloLectura RepositorioLectura => new RepositorioTipoUsoSoloLectura();
        private RepositorioTipoUsoBaja RepositorioBaja => new RepositorioTipoUsoBaja();
        private RepositorioTipoUsoAlta RepositorioAlta => new RepositorioTipoUsoAlta();
        private RepositorioTipoUsoModificacion RepositorioModificacion => new RepositorioTipoUsoModificacion();

        private TipoUso TipoUsoTest => new TipoUso()
        {
            Id = 1,
            Cpu = 1,
            Gpu = 1,
            Hdd = 1,
            Ram = 1,
            Ssd = 1,
            Nombre = "Test"
        };
    }
}