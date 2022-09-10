using Dominio;
using Repositorio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class GestorCliente
    {
        //add hashing
        public void Agregar(Cliente cliente) => new RepositorioClienteAlta().Agregar(GetClienteHasheado(cliente));
        
        public void Eliminar(int id) => new RepositorioClienteBaja().Eliminar(id);

        public void Modificar(Cliente cliente) => new RepositorioClienteModificacion().Modificar(cliente);

        public IEnumerable<Cliente> Todos => new RepositorioClienteSoloLectura().ObtenerTodos;

        private Cliente GetClienteHasheado(Cliente cliente)
        {
            cliente.Contrasena = new GestorContrasena().Hashear(cliente.Contrasena);
            return cliente;
        }
    }
}