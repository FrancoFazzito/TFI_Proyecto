using Aplicacion;
using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class GestorLoginTestUnitario
    {
        [TestMethod]
        public void IngresarCliente()
        {
            //arrange act
            var id = GestorCliente.Todos.Max(c => c.Id);
            GestorCliente.Agregar(GetClienteTest(id));
            id = GestorCliente.Todos.Max(c => c.Id);

            //assert
            var cliente = GestorCliente.Todos.FirstOrDefault(c => c.Id == id);
            Assert.IsNotNull(cliente);
            Assert.IsTrue(new Login().IngresarCliente(cliente.Correo, "Test123"));

            //exit
            GestorCliente.Eliminar(cliente.Id);
        }

        [TestMethod]
        public void IngresarEmpleado()
        {
            //arrange act
            var id = GestorEmpleado.Todos.Max(c => c.Id);
            GestorEmpleado.Agregar(GetEmpleadoTest(id));
            id = GestorEmpleado.Todos.Max(c => c.Id);

            //assert
            var empleado = GestorEmpleado.Todos.FirstOrDefault(c => c.Id == id);
            Assert.IsNotNull(empleado);
            Assert.IsTrue(new Login().IngresarEmpleado(empleado.Correo, "Test123"));

            //exit
            GestorEmpleado.Eliminar(empleado.Id);
        }

        private GestorCliente GestorCliente => new GestorCliente();

        private Cliente GetClienteTest(int rng)
        {
            return new Cliente()
            {
                Id = 1,
                Nombre = "test",
                Apellido = "test",
                Contrasena = "Test123",
                Correo = $"test {rng}",
                Barrio = "test",
                FechaNacimiento = DateTime.Now,
                Provincia = "test",
                Telefono = "test"
            };
        }

        private GestorEmpleado GestorEmpleado => new GestorEmpleado();

        private Empleado GetEmpleadoTest(int rng)
        {
            return new Empleado()
            {
                Id = 1,
                Nombre = "test",
                Apellido = "test",
                Contrasena = "Test123",
                Correo = $"test {rng}",
                NombreUsuario = $"test {rng}"
            };
        }
    }
}