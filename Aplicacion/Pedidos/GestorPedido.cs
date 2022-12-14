using Dominio;
using Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion
{
    public class GestorPedido
    {
        public void Subir(Computadora computadora, Cliente clienteLogueado) => new RepositorioPedidoAlta().Agregar(computadora, clienteLogueado);

        public IEnumerable<Pedido> Todos => new RepositorioPedidoSoloLectura().Todos;

        public IEnumerable<Pedido> TodosClienteLogueado => new RepositorioPedidoSoloLectura().Todos.Where(e => e.IdCliente == SesionCliente.Logueado.Id);
    }
}