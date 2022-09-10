using Dapper;

namespace Repositorio
{
    public class RepositorioEmpleadoBaja
    {
        private const string command = "DELETE FROM [dbo].[Empleado] WHERE Id = @id";

        public int Eliminar(int id) => Db.Conexion.Execute(command, new ParametroId().Obtener(id));
    }
}