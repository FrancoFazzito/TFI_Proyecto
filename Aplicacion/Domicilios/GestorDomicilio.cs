using System.Collections.Generic;

namespace Aplicacion
{
    public class GestorDomicilio
    {
        public List<string> Barrios => new List<string>()
        {
            "San telmo",
            "Villa ballester"
        };

        public List<string> Provincias => new List<string>()
        {
            "Buenos aires",
            "CABA"
        };
    }
}