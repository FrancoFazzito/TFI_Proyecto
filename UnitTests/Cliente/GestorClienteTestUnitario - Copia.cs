using Aplicacion;
using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio;
using System;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class GestorLoginTestUnitario
    {
        [TestMethod]
        public void Ingresar()
        {
            //arrange act
            Gestor.Agregar(ClienteTest);
            var id = Gestor.Todos.Max(c => c.Id);

            //assert
            var cliente = Gestor.Todos.FirstOrDefault(c => c.Id == id);
            Assert.IsNotNull(cliente);
            Assert.IsTrue(new Login().IngresarCliente(cliente.Contrasena, "test"));

            //exit
            Gestor.Eliminar(Gestor.Todos.Max(c => c.Id));
        }

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