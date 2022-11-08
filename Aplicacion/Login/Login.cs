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
            if (cliente == null || !_gestorContrasena.Verificar(cliente.Contrasena, contrasena))
            {
                return false;
            }
            SesionCliente.Ingresar(cliente);
            return true;
        }

        public bool IngresarEmpleado(string nombreUsuario, string contrasena)
        {
            Dominio.Empleado empleado = _repositorioEmpleadoSoloLectura.Todos.FirstOrDefault(c => c.NombreUsuario == nombreUsuario);
            if (empleado == null || !_gestorContrasena.Verificar(empleado.Contrasena, contrasena))
            {
                return false;
            }
            SesionEmpleado.Ingresar(empleado);
            return true;
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