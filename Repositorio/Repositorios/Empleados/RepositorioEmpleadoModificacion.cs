using Dapper;
using Dominio;

namespace Repositorio
{
    public class RepositorioEmpleadoModificacion
    {
        private const string commandContrasena = "UPDATE [dbo].[Empleado] SET [NombreUsuario] = @NombreUsuario,[Correo] = @Correo,[Nombre] = @Nombre,[Apellido] = @Apellido,[Contrasena] = @Contrasena WHERE Id = @id";
        private const string command = "UPDATE [dbo].[Empleado] SET [NombreUsuario] = @NombreUsuario,[Correo] = @Correo,[Nombre] = @Nombre,[Apellido] = @Apellido WHERE Id = @id";

        public int ModificarConContrasena(Empleado empleado) => Db.Conexion.Execute(commandContrasena, new ParametrosEmplado().Obtener(empleado));

        public int Modificar(Empleado empleado) => Db.Conexion.Execute(command, new ParametrosEmplado().Obtener(empleado));
    }
}