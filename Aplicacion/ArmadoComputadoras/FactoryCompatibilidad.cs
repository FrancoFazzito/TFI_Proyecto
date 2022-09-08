using Dominio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class FactoryCompatibilidad
    {
        private readonly Dictionary<string, ICompatibilidad> CompatibilidadNombre = new Dictionary<string, ICompatibilidad>();

        public ICompatibilidad GetCompatibilidadPorNombre(string nombre) => CompatibilidadNombre[nombre];
    }

}


