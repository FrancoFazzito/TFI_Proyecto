using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio;
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