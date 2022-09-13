using Dapper;
using Dominio;

namespace Repositorio.Repositorios.Pedidos
{
    public class ParametrosPedido
    {
        public DynamicParameters ObtenerIdCliente(Cliente cliente)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idCliente", cliente.Id);
            return parameters;
        }

        public DynamicParameters ObtenerTipoUso(string tipoUso)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@tipoUso", tipoUso);
            return parameters;
        }

        public DynamicParameters ObtenerIdComponente(Componente componente)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@idComponente", componente.Id);
            return parameters;
        }
    }
}
