using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio;
using System;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class RepositorioClienteTestUnitario
    {
        [TestMethod]
        public void Alta()
        {
            //act assert
            Assert.IsTrue(RepositorioAlta.Agregar(ClienteTest) == 1);

            //exit
            RepositorioBaja.Eliminar(RepositorioLectura.ObtenerTodos.Max(c => c.Id));
        }

        [TestMethod]
        public void Baja()
        {
            //arrange
            RepositorioAlta.Agregar(ClienteTest);

            //act assert
            Assert.IsTrue(RepositorioBaja.Eliminar(RepositorioLectura.ObtenerTodos.Max(c => c.Id)) == 1);
        }

        [TestMethod]
        public void Modificacion()
        {
            //arrange
            RepositorioAlta.Agregar(ClienteTest);
            Cliente cliente = ClienteTest;
            cliente.Nombre = "testModificado";
            cliente.Id = RepositorioLectura.ObtenerTodos.Max(c => c.Id);

            //act assert
            Assert.IsTrue(RepositorioModificacion.Modificar(cliente) == 1);

            //exit
            RepositorioBaja.Eliminar(RepositorioLectura.ObtenerTodos.Max(c => c.Id));
        }

        [TestMethod]
        public void Obtener()
        {
            //arrange act assert
            Assert.IsTrue(RepositorioLectura.ObtenerTodos.Any());
        }

        private RepositorioClienteSoloLectura RepositorioLectura => new RepositorioClienteSoloLectura();
        private RepositorioClienteAlta RepositorioAlta => new RepositorioClienteAlta();
        private RepositorioClienteModificacion RepositorioModificacion => new RepositorioClienteModificacion();
        private RepositorioClienteBaja RepositorioBaja => new RepositorioClienteBaja();

        private Cliente ClienteTest => new Cliente()
        {
            Id = 1,
            Nombre = "test",
            Apellido = "test",
            Barrio = "test",
            Contrasena = "test",
            Correo = "test",
            FechaNacimiento = DateTime.Now,
            Provincia = "test",
            Telefono = "test"
        };
    }
}