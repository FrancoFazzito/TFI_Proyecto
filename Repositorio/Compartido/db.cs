using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repositorio
{
    public class Db
    {
        public static IDbConnection Conexion => new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
    }
}