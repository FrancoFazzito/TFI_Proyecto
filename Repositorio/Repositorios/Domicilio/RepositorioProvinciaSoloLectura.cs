using Dapper;
using Dominio;
using System.Collections.Generic;

namespace Repositorio
{
    public class RepositorioProvinciaSoloLectura
    {
        public IEnumerable<Provincia> Todos => Db.Conexion.Query<Provincia>("SELECT * FROM Provincia");
    }
}