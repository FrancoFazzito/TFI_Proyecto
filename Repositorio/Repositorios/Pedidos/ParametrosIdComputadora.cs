using Dapper;

namespace Repositorio.Repositorios.Pedidos
{
    public class ParametrosIdComputadora
    {
        public DynamicParameters GetIdComputadora(PedidoConsultaResultado pedido)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idComputadora", pedido.IdComputadora);
            return parametros;
        }
    }
}