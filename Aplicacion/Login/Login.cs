using Repositorio;
using System.Linq;

namespace Aplicacion
{
    public class Login
    {
        private readonly GestorContrasena _gestorContrasena;
        private readonly RepositorioClienteSoloLectura _repositorioClienteSoloLectura;
        private readonly RepositorioEmpleadoSoloLectura _repositorioEmpleadoSoloLectura;

        public Login()
        {
            _gestorContrasena = new GestorContrasena();
            _repositorioClienteSoloLectura = new RepositorioClienteSoloLectura();
            _repositorioEmpleadoSoloLectura = new RepositorioEmpleadoSoloLectura();
        }

        public bool IngresarCliente(string correo, string contrasena)
        {
            Dominio.Cliente cliente = _repositorioClienteSoloLectura.Todos.FirstOrDefault(c => c.Correo == correo);
            SesionCliente.Ingresar(cliente);
            return cliente != null && _gestorContrasena.Verificar(cliente.Contrasena, contrasena);
        }

        public bool IngresarEmpleado(string nombreUsuario, string contrasena)
        {
            Dominio.Empleado empleado = _repositorioEmpleadoSoloLectura.Todos.FirstOrDefault(c => c.NombreUsuario == nombreUsuario);
            SesionEmpleado.Ingresar(empleado);
            return empleado != null && _gestorContrasena.Verificar(empleado.Contrasena, contrasena);
        }

        public void SalirEmpleado()
        {
            SesionEmpleado.Salir();
        }

        public void SalirCliente()
        {
            SesionCliente.Salir();
        }
    }
}