using Dapper;
using Dominio;

namespace Repositorio
{
    public class RepositorioEmpleadoModificacion
    {
        private const string command = "UPDATE [dbo].[Empleado] SET [NombreUsuario] = @NombreUsuario,[Correo] = @Correo,[Nombre] = @Nombre,[Apellido] = @Apellido,[Contrasena] = @Contrasena WHERE Id = @id";

        public int Modificar(Empleado empleado) => Db.Conexion.Execute(command, new ParametrosEmplado().Obtener(empleado));
    }
}