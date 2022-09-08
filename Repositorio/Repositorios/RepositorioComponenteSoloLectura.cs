using Dapper;
using Dominio;
using System.Collections.Generic;

namespace Repositorio
{
    public class RepositorioComponenteSoloLectura
    {
        public IEnumerable<Componente> ObtenerTodos => Db.Conexion.Query<Componente>("SELECT * FROM Componente");
    }
}
