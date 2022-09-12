using Dapper;

namespace Repositorio
{
    public class RepositorioClienteBaja
    {
        private const string command = "DELETE FROM [dbo].[Cliente] WHERE Id = @id";

        public int Eliminar(int id)
        {
            return Db.Conexion.Execute(command, new ParametroId().Obtener(id));
        }
    }
}