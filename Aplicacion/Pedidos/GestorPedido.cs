using Dominio;
using Repositorio.Repositorios.Pedidos;

namespace Aplicacion.Pedidos
{
    public class GestorPedido
    {
        public void Subir(Computadora computadora, Cliente clienteLogueado)
        {
            new RepositorioPedidoAlta().Agregar(computadora, clienteLogueado);
        }
    }
}