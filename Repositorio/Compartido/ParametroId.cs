using Dapper;

namespace Repositorio
{
    public class ParametroId
    {
        public DynamicParameters Obtener(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            return parameters;
        }
    }
}