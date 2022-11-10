using Dominio;
using Repositorio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class GestorDomicilio
    {
        public IEnumerable<Provincia> Provincias => new RepositorioProvinciaSoloLectura().Todos;
    }
}