using Dapper;
using Dominio;

namespace Repositorio
{
    public class ParametrosEmplado
    {
        public DynamicParameters Obtener(Empleado empleado)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", empleado.Id);
            parameters.Add("@NombreUsuario", empleado.NombreUsuario);
            parameters.Add("@correo", empleado.Correo);
            parameters.Add("@nombre", empleado.Nombre);
            parameters.Add("@apellido", empleado.Apellido);
            parameters.Add("@contrasena", empleado.Contrasena);
            return parameters;
        }
    }
}