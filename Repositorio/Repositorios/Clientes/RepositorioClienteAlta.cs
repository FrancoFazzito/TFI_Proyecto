using Dapper;
using Dominio;

namespace Repositorio
{
    public class RepositorioClienteAlta
    {
        private const string command = "INSERT INTO [dbo].[Cliente] VALUES (@nombre,@apellido,@fechaNacimiento,@telefono,@correo,@provincia,@barrio,@contrasena)";

        public int Agregar(Cliente cliente)
        {
            return Db.Conexion.Execute(command, new ParametrosCliente().Obtener(cliente));
        }
    }
}
