using Dapper;
using Dominio;
using System.Collections.Generic;

namespace Repositorio
{
    public class RepositorioClienteSoloLectura
    {
        public IEnumerable<Cliente> Todos => Db.Conexion.Query<Cliente>("SELECT * FROM Cliente");
    }
}