using Dominio;
using Repositorio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class GestorEmpleado
    {
        //add hashing
        public void Agregar(Empleado empleado) => new RepositorioEmpleadoAlta().Agregar(GetEmpleadoHasheado(empleado));

        public void Eliminar(int id) => new RepositorioEmpleadoBaja().Eliminar(id);

        public void Modificar(Empleado empleado, string nuevaContrasena) => new RepositorioEmpleadoModificacion().Modificar(GetEmpleadoHasheado(empleado, nuevaContrasena));

        public IEnumerable<Empleado> Todos => new RepositorioEmpleadoSoloLectura().Todos;

        private Empleado GetEmpleadoHasheado(Empleado empleado, string nuevaContrasena)
        {
            if (nuevaContrasena == null)
            {
                return empleado;
            }
            empleado.Contrasena = new GestorContrasena().Hashear(nuevaContrasena);
            return empleado;
        }
    }
}