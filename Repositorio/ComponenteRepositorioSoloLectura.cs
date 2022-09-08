using Dapper;
using Dominio;
using System.Collections.Generic;

namespace Repositorio
{
    public class ComponenteRepositorioSoloLectura
    {
        public IEnumerable<Componente> ObtenerTodos => Db.Conexion.Query<Componente>("SELECT * FROM Componentes");
    }
}
