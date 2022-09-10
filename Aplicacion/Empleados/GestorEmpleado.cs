using Dominio;
using Repositorio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class GestorEmpleado
    {
        //add hashing
        public void Agregar(Empleado empleado) => new RepositorioEmpleadoAlta().Agregar(empleado);

        public void Eliminar(Empleado empleado) => new RepositorioEmpleadoBaja().Eliminar(empleado.Id);

        public void Modificar(Empleado empleado) => new RepositorioEmpleadoModificacion().Modificar(empleado);

        public IEnumerable<Empleado> Todos => new RepositorioEmpleadoSoloLectura().ObtenerTodos;
    }
}