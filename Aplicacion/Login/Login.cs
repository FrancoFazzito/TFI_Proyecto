using Repositorio;
using System.Linq;

namespace Aplicacion
{
    public class Login
    {
        private readonly GestorContrasena _gestorContrasena;

        public Login() => _gestorContrasena = new GestorContrasena();

        public bool IngresarCliente(string correo, string contrasenaIngresada)
        {
            //ver si agregar singleton y add cookies
            var cliente = new RepositorioClienteSoloLectura().ObtenerTodos.FirstOrDefault(c => c.Correo == correo);
            ClienteLogueado.Instancia.Logueado = cliente;
            return cliente == null || _gestorContrasena.Verificar(cliente.Contrasena, contrasenaIngresada);
        }

        public bool IngresarEmpleado(string nombreUsuario, string contrasenaIngresada)
        {
            var empleado = new RepositorioEmpleadoSoloLectura().Todos.FirstOrDefault(c => c.NombreUsuario == nombreUsuario);
            EmpleadoLogueado.Instancia.Logueado = empleado;
            return empleado == null || _gestorContrasena.Verificar(empleado.Contrasena, contrasenaIngresada);
        }

        public void SalirEmpleado()
        {
            EmpleadoLogueado.Salir();
        }

        public void SalirCliente()
        {
            ClienteLogueado.Salir();
        }
    }
}
