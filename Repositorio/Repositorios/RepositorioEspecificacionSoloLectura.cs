using Dapper;
using Dominio;
using System.Collections.Generic;

namespace Repositorio
{
    public class RepositorioEspecificacionSoloLectura
    {
        public IEnumerable<Especificacion> ObtenerTodos => Db.Conexion.Query<Especificacion>("SELECT * FROM Especificaciones");
    }
}
