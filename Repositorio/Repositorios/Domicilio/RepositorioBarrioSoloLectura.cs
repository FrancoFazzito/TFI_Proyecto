using Dapper;
using Dominio;
using System.Collections.Generic;

namespace Repositorio
{
    public class RepositorioBarrioSoloLectura
    {
        public IEnumerable<Barrio> Todos => Db.Conexion.Query<Barrio>("SELECT * FROM Barrio");
    }
}