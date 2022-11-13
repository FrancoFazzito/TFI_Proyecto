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
            var cliente = _repositorioClienteSoloLectura.Todos.FirstOrDefault(c => c.Correo.ToLower() == correo.ToLower());
            if (ClienteInvalido(contrasena, cliente))
            {
                return false;
            }
            SesionCliente.Ingresar(cliente);
            return true;
        }

        private bool ClienteInvalido(string contrasena, Dominio.Cliente cliente) => cliente == null || !_gestorContrasena.Verificar(cliente.Contrasena, contrasena);

        public bool IngresarEmpleado(string nombreUsuario, string contrasena)
        {
            var empleado = _repositorioEmpleadoSoloLectura.Todos.FirstOrDefault(c => c.NombreUsuario.ToLower() == nombreUsuario.ToLower());
            if (EmpleadoInvalido(contrasena, empleado))
            {
                return false;
            }
            SesionEmpleado.Ingresar(empleado);
            return true;
        }

        private bool EmpleadoInvalido(string contrasena, Dominio.Empleado empleado) => empleado == null || !_gestorContrasena.Verificar(empleado.Contrasena, contrasena);

        public void SalirEmpleado() => SesionEmpleado.Salir();

        public void SalirCliente() => SesionCliente.Salir();
    }
}