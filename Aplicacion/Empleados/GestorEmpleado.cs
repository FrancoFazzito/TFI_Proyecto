using Dominio;
using Repositorio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class GestorEmpleado
    {
        public void Agregar(Empleado empleado) => new RepositorioEmpleadoAlta().Agregar(GetEmpleadoHasheado(empleado));

        public void Eliminar(int id) => new RepositorioEmpleadoBaja().Eliminar(id);

        public void Modificar(Empleado empleado, string nuevaContrasena = null)
        {
            if (nuevaContrasena != null)
            {
                new RepositorioEmpleadoModificacion().ModificarConContrasena(GetEmpleadoHasheadoModificado(empleado, nuevaContrasena));
                return;
            }
            new RepositorioEmpleadoModificacion().Modificar(empleado);
        }

        public IEnumerable<Empleado> Todos => new RepositorioEmpleadoSoloLectura().Todos;

        private Empleado GetEmpleadoHasheado(Empleado empleado)
        {
            empleado.Contrasena = new GestorContrasena().Hashear(empleado.Contrasena);
            return empleado;
        }

        private Empleado GetEmpleadoHasheadoModificado(Empleado empleado, string nuevaContrasena = null)
        {
            empleado.Contrasena = new GestorContrasena().Hashear(nuevaContrasena);
            return empleado;
        }
    }
}