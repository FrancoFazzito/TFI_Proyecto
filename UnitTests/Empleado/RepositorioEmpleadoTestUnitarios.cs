using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class RepositorioEmpleadoTestUnitario
    {
        [TestMethod]
        public void Alta()
        {
            //act assert
            Assert.IsTrue(RepositorioAlta.Agregar(EmpleadoTest) == 1);

            //exit
            RepositorioBaja.Eliminar(RepositorioLectura.Todos.Max(c => c.Id));
        }

        [TestMethod]
        public void Baja()
        {
            //arrange
            RepositorioAlta.Agregar(EmpleadoTest);

            //act assert
            Assert.IsTrue(RepositorioBaja.Eliminar(RepositorioLectura.Todos.Max(c => c.Id)) == 1);
        }

        [TestMethod]
        public void Modificacion()
        {
            //arrange
            RepositorioAlta.Agregar(EmpleadoTest);
            var cliente = EmpleadoTest;
            cliente.Nombre = "testModificado";
            cliente.Id = RepositorioLectura.Todos.Max(c => c.Id);

            //act assert
            Assert.IsTrue(RepositorioModificacion.Modificar(cliente) == 1);

            //exit
            RepositorioBaja.Eliminar(RepositorioLectura.Todos.Max(c => c.Id));
        }

        [TestMethod]
        public void Obtener() =>
            //arrange act assert
            Assert.IsTrue(RepositorioLectura.Todos.Any());

        private RepositorioEmpleadoSoloLectura RepositorioLectura => new RepositorioEmpleadoSoloLectura();
        private RepositorioEmpleadoAlta RepositorioAlta => new RepositorioEmpleadoAlta();
        private RepositorioEmpleadoModificacion RepositorioModificacion => new RepositorioEmpleadoModificacion();
        private RepositorioEmpleadoBaja RepositorioBaja => new RepositorioEmpleadoBaja();

        private Empleado EmpleadoTest => new Empleado()
        {
            Id = 1,
            Nombre = "test",
            Apellido = "test",
            NombreUsuario = "test",
            Contrasena = "Test123",
            Correo = "test",
        };
    }
}