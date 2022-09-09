using Dapper;
using Dominio;

namespace Repositorio
{
    public class RepositorioTipoUsoModificacion
    {
        private const string command = "UPDATE [dbo].[TipoUso] SET [Nombre] = @Nombre ,[Cpu] = @cpu,[Ram] = @ram,[Gpu] = @gpu,[Hdd] = @hdd,[Ssd] = @ssd WHERE Id = @id";

        public int Modificar(TipoUso tipoUso)
        {
            var rows = Db.Conexion.Execute(command, new ParametrosTipoUso().Obtener(tipoUso));
            return rows;
        }
    }
}