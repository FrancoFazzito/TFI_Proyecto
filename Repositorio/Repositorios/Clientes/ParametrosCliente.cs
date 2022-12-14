using Dapper;
using Dominio;

namespace Repositorio
{
    public class ParametrosCliente
    {
        public DynamicParameters Obtener(Cliente cliente)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", cliente.Id);
            parameters.Add("@Nombre", cliente.Nombre);
            parameters.Add("@apellido", cliente.Apellido);
            parameters.Add("@fechaNacimiento", cliente.FechaNacimiento.Date);
            parameters.Add("@telefono", cliente.Telefono);
            parameters.Add("@correo", cliente.Correo);
            parameters.Add("@provincia", cliente.Provincia);
            parameters.Add("@barrio", cliente.Barrio);
            parameters.Add("@contrasena", cliente.Contrasena);
            return parameters;
        }
    }
}