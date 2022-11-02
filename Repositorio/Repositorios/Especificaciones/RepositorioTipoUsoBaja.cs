using Dapper;

namespace Repositorio
{
    public class RepositorioTipoUsoBaja
    {
        private const string commmand = "DELETE FROM [dbo].[TipoUso] WHERE Id = @id";

        public int Eliminar(int id)
        {
            return Db.Conexion.Execute(commmand, new ParametroId().Obtener(id));
        }
    }
}