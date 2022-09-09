using Dapper;
using Dominio;
using System.Collections.Generic;

namespace Repositorio
{
    public class RepositorioTipoUsoSoloLectura
    {
        public IEnumerable<TipoUso> ObtenerTodos => Db.Conexion.Query<TipoUso>("SELECT * FROM TipoUso");
    }
}