using Aplicacion;
using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio;
using System;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class GestorClienteTestUnitario
    {
        [TestMethod]
        public void Alta()
        {
            //arrange act
            Gestor.Agregar(ClienteTest);
            var id = Gestor.Todos.Max(c => c.Id);

            //assert
            Assert.IsNotNull(Gestor.Todos.FirstOrDefault(c => c.Id == id));

            //exit
            Gestor.Eliminar(Gestor.Todos.Max(c => c.Id));
        }

        [TestMethod]
        public void Baja()
        {
            //arrange
            Gestor.Agregar(ClienteTest);
            var id = Gestor.Todos.Max(c => c.Id);

            //act assert
            Assert.IsNotNull(Gestor.Todos.FirstOrDefault(c => c.Id == id));
            Gestor.Eliminar(Gestor.Todos.Max(c => c.Id));
        }

        [TestMethod]
        public void Modificacion()
        {
            //arrange
            Gestor.Agregar(ClienteTest);
            var cliente = ClienteTest;
            cliente.Nombre = "testModificado";
            var id = Gestor.Todos.Max(c => c.Id);
            cliente.Id = id;

            //act
            Gestor.Modificar(cliente);

            //assert
            Assert.IsNotNull(Gestor.Todos.FirstOrDefault(c => c.Id == id));

            //exit
            Gestor.Eliminar(Gestor.Todos.Max(c => c.Id));
        }

        [TestMethod]
        public void Obtener() =>
            //arrange act assert
            Assert.IsTrue(Gestor.Todos.Any());

        private GestorCliente Gestor => new GestorCliente();

        private Cliente ClienteTest => new Cliente()
        {
            Id = 1,
            Nombre = "test",
            Apellido = "test",
            Contrasena = "test",
            Correo = "test",
            Barrio = "test",
            FechaNacimiento = DateTime.Now,
            Provincia = "test",
            Telefono = "test"
        };
    }
}