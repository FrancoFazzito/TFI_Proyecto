using Repositorio;
using System.Linq;

namespace Aplicacion
{
    public class Login
    {
        private readonly GestorContrasena _gestorContrasena;

        public Login()
        {
            _gestorContrasena = new GestorContrasena();
        }

        public bool IngresarCliente(string correo, string contrasena)
        {
            //ver si agregar singleton y add cookies
            Dominio.Cliente cliente = new RepositorioClienteSoloLectura().ObtenerTodos.FirstOrDefault(c => c.Correo == correo);
            SesionCliente.Ingresar(cliente);
            return cliente != null && _gestorContrasena.Verificar(cliente.Contrasena, contrasena);
        }

        public bool IngresarEmpleado(string nombreUsuario, string contrasena)
        {
            Dominio.Empleado empleado = new RepositorioEmpleadoSoloLectura().Todos.FirstOrDefault(c => c.NombreUsuario == nombreUsuario);
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