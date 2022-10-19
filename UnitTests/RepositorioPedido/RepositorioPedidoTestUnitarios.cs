using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio.Repositorios.Pedidos;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class RepositorioPedidoTestUnitarios
    {
        [TestMethod]
        public void ObtenerTodos() => Assert.IsTrue(new RepositorioPedidoSoloLectura().Todos.Any());
    }
}