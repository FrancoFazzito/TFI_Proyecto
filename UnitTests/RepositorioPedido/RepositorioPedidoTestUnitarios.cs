using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio.Repositorios.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class RepositorioPedidoTestUnitarios
    {
        [TestMethod]
        public void ObtenerTodos()
        {
            Assert.IsTrue(new RepositorioPedidoSoloLectura().Todos.Any());
        }
    }
}
