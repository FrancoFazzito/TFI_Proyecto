using Aplicacion;
using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class GestorEmpleadoTestUnitario
    {
        [TestMethod]
        public void Alta()
        {
            //arrange act
            Gestor.Agregar(EmpleadoTest);
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
            Gestor.Agregar(EmpleadoTest);
            var id = Gestor.Todos.Max(c => c.Id);

            //act assert
            Assert.IsNotNull(Gestor.Todos.FirstOrDefault(c => c.Id == id));
            Gestor.Eliminar(Gestor.Todos.Max(c => c.Id));
        }

        [TestMethod]
        public void Modificacion()
        {
            //arrange
            Gestor.Agregar(EmpleadoTest);
            var empleado = EmpleadoTest;
            empleado.Nombre = "testModificado";
            var id = Gestor.Todos.Max(c => c.Id);
            empleado.Id = id;

            //act
            Gestor.Modificar(empleado);

            //assert
            Assert.IsNotNull(Gestor.Todos.FirstOrDefault(c => c.Id == id));

            //exit
            Gestor.Eliminar(Gestor.Todos.Max(c => c.Id));
        }

        [TestMethod]
        public void Obtener() =>
            //arrange act assert
            Assert.IsTrue(Gestor.Todos.Any());

        private GestorEmpleado Gestor => new GestorEmpleado();

        private Empleado EmpleadoTest => new Empleado()
        {
            Id = 1,
            Nombre = "test",
            Apellido = "test",
            NombreUsuario = "test",
            Contrasena = "test",
            Correo = "test",
        };
    }
}