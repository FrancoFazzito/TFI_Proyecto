using Dominio;
using Repositorio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class GestorTipoUso
    {
        public void Agregar(TipoUso tipoUso) => new RepositorioTipoUsoAlta().Agregar(tipoUso);

        public void Eliminar(TipoUso tipoUso) => new RepositorioTipoUsoBaja().Eliminar(tipoUso.Id);

        public void Modificar(TipoUso tipoUso) => new RepositorioTipoUsoModificacion().Modificar(tipoUso);

        public IEnumerable<TipoUso> Todos => new RepositorioTipoUsoSoloLectura().ObtenerTodos;
    }
}