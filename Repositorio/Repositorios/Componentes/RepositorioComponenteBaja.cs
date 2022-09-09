using Dapper;

namespace Repositorio
{
    public class RepositorioComponenteBaja
    {
        private const string command = "DELETE FROM [dbo].[Componente] WHERE Id = @id";

        public int Eliminar(int id) => Db.Conexion.Execute(command, ObtenerParametrosId(id));

        private static DynamicParameters ObtenerParametrosId(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            return parameters;
        }
    }
}