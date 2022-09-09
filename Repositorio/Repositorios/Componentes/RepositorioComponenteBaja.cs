using Dapper;

namespace Repositorio
{
    public class RepositorioComponenteBaja
    {
        private const string command = "DELETE FROM [dbo].[Componente] WHERE Id = @id";

        public int Eliminar(int id) => Db.Conexion.Execute(command, new ParametroId().Obtener(id));
    }
}