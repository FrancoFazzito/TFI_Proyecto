using System.Collections.Generic;

namespace Dominio
{
    public class FactoryCompatibilidad
    {
        private readonly Dictionary<string, ICompatibilidad> CompatibilidadNombre = new Dictionary<string, ICompatibilidad>();

        public ICompatibilidad GetCompatibilidadPorNombre(string nombre)
        {
            return CompatibilidadNombre[nombre];
        }
    }

}


