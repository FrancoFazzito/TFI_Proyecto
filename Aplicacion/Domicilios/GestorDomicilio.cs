using Dominio;
using Repositorio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class GestorDomicilio
    {
        public IEnumerable<Barrio> Barrios => new RepositorioBarrioSoloLectura().Todos;

        public IEnumerable<Provincia> Provincias => new RepositorioProvinciaSoloLectura().Todos;
    }
}