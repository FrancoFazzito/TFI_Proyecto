using Dominio;
using Repositorio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class GestorCliente
    {
        public void Agregar(Cliente cliente)
        {
            new RepositorioClienteAlta().Agregar(GetClienteHasheado(cliente));
        }

        public void Eliminar(int id)
        {
            new RepositorioClienteBaja().Eliminar(id);
        }

        public void Modificar(Cliente cliente, string nuevaContrasena = null)
        {
            new RepositorioClienteModificacion().Modificar(GetClienteHasheadoModificado(cliente, nuevaContrasena));
        }

        public IEnumerable<Cliente> Todos => new RepositorioClienteSoloLectura().Todos;

        private Cliente GetClienteHasheado(Cliente cliente)
        {
            cliente.Contrasena = new GestorContrasena().Hashear(cliente.Contrasena);
            return cliente;
        }

        private Cliente GetClienteHasheadoModificado(Cliente cliente, string nuevaContrasena)
        {
            if (nuevaContrasena == null)
            {
                return cliente;
            }
            cliente.Contrasena = new GestorContrasena().Hashear(nuevaContrasena);
            return cliente;
        }
    }
}