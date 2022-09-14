using Dominio;
using Repositorio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class GestorTipoUso
    {
        public void Agregar(TipoUso tipoUso) => new RepositorioTipoUsoAlta().Agregar(tipoUso);

        public void Eliminar(int id) => new RepositorioTipoUsoBaja().Eliminar(id);

        public void Modificar(TipoUso tipoUso) => new RepositorioTipoUsoModificacion().Modificar(tipoUso);

        public IEnumerable<TipoUso> Todos => new RepositorioTipoUsoSoloLectura().ObtenerTodos;
    }
}