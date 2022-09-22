using Dapper;
using Dominio;

namespace Repositorio.Repositorios.Pedidos
{
    public class ParametrosPedido
    {
        public DynamicParameters ObtenerIdCliente(Cliente cliente)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idCliente", cliente.Id);
            return parameters;
        }

        public DynamicParameters ObtenerTipoUso(string tipoUso)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@tipoUso", tipoUso);
            return parameters;
        }

        public DynamicParameters ObtenerIdComponente(Componente componente)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idComponente", componente.Id);
            return parameters;
        }

        public DynamicParameters GetIdComputadora(PedidoConsulta pedido)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idComputadora", pedido.IdComputadora);
            return parametros;
        }
    }
}