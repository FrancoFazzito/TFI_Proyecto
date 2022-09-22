using Dapper;
using Dapper.Transaction;
using Dominio;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Repositorio.Repositorios.Pedidos
{
    public class RepositorioPedidoSoloLectura
    {
        public IEnumerable<Pedido> Todos
        {
            get
            {
                var pedidos = new List<Pedido>();
                foreach (var pedidoConsulta in Db.Conexion.Query<ConsultaPedido>("SELECT c.Id as idComputadora, c.TipoUso, p.Id as IdPedido, p.IdCliente, p.FechaPedido FROM Pedido p inner join Computadora c on p.Id = c.Id_Pedido"))
                {
                    var computadora = new Computadora()
                    {
                        Id = pedidoConsulta.IdComputadora,
                        TipoUso = pedidoConsulta.TipoUso,
                        CostoArmado = decimal.Parse(ConfigurationManager.AppSettings["costoArmado"]),
                    };

                    foreach (var idComponente in Db.Conexion.Query<int>("SELECT cc.Id_Component FROM Computadora c inner join ComponenteComputadora cc on cc.Id_Computer = c.Id where c.Id = @idComputadora", new ParametrosPedido().GetIdComputadora(pedidoConsulta)))
                    {
                        computadora.Add(new RepositorioComponenteSoloLectura().ObtenerTodos.First(e => e.Id == idComponente), 1);
                    }
                    pedidos.Add(new Pedido
                    {
                        Id = pedidoConsulta.IdPedido,
                        Computadora = computadora,
                        IdCliente = pedidoConsulta.IdCliente,
                        Fecha = pedidoConsulta.FechaPedido
                    });
                }
                return pedidos;
            }
        }
    }
}