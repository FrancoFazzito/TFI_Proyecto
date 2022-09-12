using Dapper;
using Dominio;

namespace Repositorio
{
    public class RepositorioTipoUsoAlta
    {
        private const string command = "INSERT INTO [dbo].[TipoUso] VALUES (@Nombre,@cpu,@ram,@gpu,@hdd,@ssd)";

        public int Agregar(TipoUso tipoUso)
        {
            int rows = Db.Conexion.Execute(command, new ParametrosTipoUso().Obtener(tipoUso));
            return rows;
        }
    }
}