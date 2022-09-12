using Dapper;
using Dapper.Transaction;
using Dominio;

namespace Repositorio.Repositorios.Pedidos
{
    public class RepositorioPedidoAlta
    {
        public int Agregar(Computadora computadora, Cliente clienteLogueado)
        {
            using (System.Data.IDbConnection conexion = Db.Conexion)
            {
                conexion.Open();

                using (System.Data.IDbTransaction transaction = conexion.BeginTransaction())
                {
                    int rows = transaction.Execute("INSERT INTO[dbo].[Pedido] VALUES(@idCliente)", new ParametrosPedido().ObtenerIdCliente(clienteLogueado));
                    rows += transaction.Execute("INSERT INTO[dbo].[computadora] VALUES ((SELECT IDENT_CURRENT('pedido')), @TipoUso)", new ParametrosPedido().ObtenerTipoUso(computadora.TipoUso));
                    foreach (var componente in computadora.Componentes)
                    {
                        transaction.Execute("INSERT INTO[dbo].[ComponenteComputadora] VALUES(@idComponente, (SELECT IDENT_CURRENT('computadora')))", new ParametrosPedido().ObtenerIdComponente(componente));
                    }
                    transaction.Commit();
                    return rows;
                }
            }
        }
    }
}
