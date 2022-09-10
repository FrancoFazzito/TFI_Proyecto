using Dapper;
using Dominio;

namespace Repositorio
{
    public class RepositorioClienteModificacion
    {
        private const string command = "UPDATE [dbo].[Cliente] SET [Nombre] = @nombre,[Apellido] = @apellido,[FechaNacimiento] = @fechaNacimiento,[Telefono] = @telefono,[Correo] = @correo,[Provincia] = @provincia,[Barrio] = @barrio,[Contrasena] = @contrasena WHERE Id = @id";

        public int Modificar(Cliente cliente)
        {
            return Db.Conexion.Execute(command, new ParametrosCliente().Obtener(cliente));
        }
    }
}
