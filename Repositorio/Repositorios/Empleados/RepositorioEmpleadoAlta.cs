using Dapper;
using Dominio;

namespace Repositorio
{
    public class RepositorioEmpleadoAlta
    {
        private const string command = "INSERT INTO [dbo].[Empleado] VALUES (@nombreUsuario,@correo,@nombre,@apellido,@contrasena)";

        public int Agregar(Empleado empleado) => Db.Conexion.Execute(command, new ParametrosEmplado().Obtener(empleado));
    }
}