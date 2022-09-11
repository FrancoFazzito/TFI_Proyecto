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
            var id = Gestor.Todos.Max(c => c.Id);
            Gestor.Agregar(GetClienteTest(id));
            id = Gestor.Todos.Max(c => c.Id);

            //assert
            var cliente = Gestor.Todos.FirstOrDefault(c => c.Id == id);
            Assert.IsNotNull(cliente);
            Assert.IsTrue(new Login().IngresarCliente(cliente.Correo, "test"));

            //exit
            Gestor.Eliminar(Gestor.Todos.Max(c => c.Id));
        }
        //repetir con empleado

        private GestorCliente Gestor => new GestorCliente();

        private Cliente GetClienteTest(int rng) => new Cliente()
        {
            Id = 1,
            Nombre = "test",
            Apellido = "test",
            Contrasena = "test",
            Correo = $"test {rng}",
            Barrio = "test",
            FechaNacimiento = DateTime.Now,
            Provincia = "test",
            Telefono = "test"
        };
    }
}