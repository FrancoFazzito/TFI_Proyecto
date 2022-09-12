using Dapper;

namespace Repositorio
{
    public class ParametroId
    {
        public DynamicParameters Obtener(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            return parameters;
        }
    }
}