using Dapper;
using Dominio;
using System.Collections.Generic;

namespace Repositorio
{
    public class RepositorioClienteSoloLectura
    {
        public IEnumerable<Cliente> ObtenerTodos => Db.Conexion.Query<Cliente>("SELECT * FROM Cliente");
    }
}