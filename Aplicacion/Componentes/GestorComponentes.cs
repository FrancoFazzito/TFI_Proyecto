using Dominio;
using Repositorio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class GestorComponentes
    {
        public void Agregar(Componente componente)
        {
            new RepositorioComponenteAlta().Agregar(componente);
        }

        public void Eliminar(int id)
        {
            new RepositorioComponenteBaja().Eliminar(id);
        }

        public void Modificar(Componente componente)
        {
            new RepositorioComponenteModificacion().Modificar(componente);
        }

        public IEnumerable<Componente> Todos => new RepositorioComponenteSoloLectura().ObtenerTodos;
    }
}