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

        public void Modificar(Empleado empleado) => new RepositorioEmpleadoModificacion().Modificar(empleado);

        public IEnumerable<Empleado> Todos => new RepositorioEmpleadoSoloLectura().Todos;

        private Empleado GetEmpleadoHasheado(Empleado empleado)
        {
            empleado.Contrasena = new GestorContrasena().Hashear(empleado.Contrasena);
            return empleado;
        }
    }
}