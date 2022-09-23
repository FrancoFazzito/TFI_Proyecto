using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormHelper.ChequearAdminLogueado(this);
        }

        public string LineData = "[[1, 1000000], [2, 1500000], [3, 1800000], [4, 1800000], [5, 1200000],[6, 1800000], [7, 1400000], [8, 1800000], [9, 1150000], [10, 1350000], [11, 2000000], [12, 1185000]]";

        public Dictionary<string, int> TiposUso => new Dictionary<string, int>()
        {
            { "Edicion de video", 145000 },
            { "Arquitectura", 127000 },
            { "Gaming", 101000 }
        };

        public Dictionary<string, int> MesesGanancias => new Dictionary<string, int>()
        {
            { "Junio", 1270000 },
            { "Julio", 1010000 },
            { "Agosto", 1450000 }
        };

        public IEnumerable<Componente> Componentes => new GestorComponente().Todos.Take(3);
    }
}