using Dominio;
using Repositorio.Repositorios.Pedidos;
using System.Collections.Generic;

namespace Aplicacion.Pedidos
{
    public class GestorPedido
    {
        public void Subir(Computadora computadora, Cliente clienteLogueado) => new RepositorioPedidoAlta().Agregar(computadora, clienteLogueado);

        public IEnumerable<Pedido> Todos => new RepositorioPedidoSoloLectura().Todos;
    }
}