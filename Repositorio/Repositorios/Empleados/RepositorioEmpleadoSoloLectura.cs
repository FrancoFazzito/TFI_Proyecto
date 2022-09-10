using Dapper;
using Dominio;
using System.Collections.Generic;

namespace Repositorio
{
    public class RepositorioEmpleadoSoloLectura
    {
        public IEnumerable<Empleado> Todos => Db.Conexion.Query<Empleado>("SELECT * FROM Empleado");
    }
}