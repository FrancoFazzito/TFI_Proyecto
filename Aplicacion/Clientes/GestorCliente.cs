using Dominio;
using Repositorio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class GestorCliente
    {
        //add hashing
        public void Agregar(Cliente cliente) => new RepositorioClienteAlta().Agregar(cliente);

        public void Eliminar(Cliente cliente) => new RepositorioClienteBaja().Eliminar(cliente.Id);

        public void Modificar(Cliente cliente) => new RepositorioClienteModificacion().Modificar(cliente);

        public IEnumerable<Cliente> Todos => new RepositorioClienteSoloLectura().ObtenerTodos;
    }
}