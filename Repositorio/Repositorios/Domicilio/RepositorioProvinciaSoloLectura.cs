using Dapper;
using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio
{
    public class RepositorioProvinciaSoloLectura
    {
        private const string commandTodos = "SELECT * FROM Provincia";
        private const string commandPorProvincia = "SELECT * FROM Barrio WHERE IdProvincia = @id";

        public IEnumerable<Provincia> Todos
        {
            get
            {
                var provincias = Db.Conexion.Query<Provincia>(commandTodos);
                foreach (var (provincia, barrio) in provincias.SelectMany(provincia => Db.Conexion.Query<Barrio>(commandPorProvincia, new ParametroId().Obtener(provincia.Id))
                                                              .Select(barrio => (provincia, barrio))))
                {
                    provincia.AddBarrio(barrio);
                }
                return provincias;
            }
        }
    }
}