using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
