using Dapper;
using Dominio;
using System.Collections.Generic;

namespace Repositorio
{
    public class RepositorioComponenteSoloLectura
    {
        private const string query = "SELECT * FROM Componente";

        public IEnumerable<Componente> ObtenerTodos => Db.Conexion.Query<Componente>(query);
    }
}