using Dapper;
using Dominio;
using System.Collections.Generic;

namespace Repositorio
{
    public class RepositorioEmpleadoSoloLectura
    {
        private const string command = "SELECT * FROM Empleado";

        public IEnumerable<Empleado> Todos => Db.Conexion.Query<Empleado>(command);
    }
}