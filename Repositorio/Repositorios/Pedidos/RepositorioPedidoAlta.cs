using Dapper;
using Dapper.Transaction;
using Dominio;
using System.Data;

namespace Repositorio.Repositorios.Pedidos
{
    public class RepositorioPedidoAlta
    {
        private const string commandPedido = "INSERT INTO[dbo].[Pedido] VALUES(@idCliente)";
        private const string commandComputadora = "INSERT INTO[dbo].[computadora] VALUES ((SELECT IDENT_CURRENT('pedido')), @TipoUso)";
        private const string commandComponenteComputadora = "INSERT INTO[dbo].[ComponenteComputadora] VALUES(@idComponente, (SELECT IDENT_CURRENT('computadora')))";

        public int Agregar(Computadora computadora, Cliente clienteLogueado)
        {
            using (IDbConnection conexion = Db.Conexion)
            {
                conexion.Open();

                using (IDbTransaction transaction = conexion.BeginTransaction())
                {
                    int rows = transaction.Execute(commandPedido, new ParametrosPedido().ObtenerIdCliente(clienteLogueado));
                    rows += transaction.Execute(commandComputadora, new ParametrosPedido().ObtenerTipoUso(computadora.TipoUso));
                    foreach (Componente componente in computadora.Componentes)
                    {
                        transaction.Execute(commandComponenteComputadora, new ParametrosPedido().ObtenerIdComponente(componente));
                    }
                    transaction.Commit();
                    return rows;
                }
            }
        }
    }
}