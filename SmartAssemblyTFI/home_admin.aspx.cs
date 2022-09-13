using System;
using System.Collections.Generic;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LineData = "[[1, 1000000], [2, 1500000], [3, 1800000], [4, 1800000], [5, 1200000],[6, 1800000], [7, 1400000], [8, 1800000], [9, 1150000], [10, 1350000], [11, 2000000], [12, 1185000]]";
            TiposUso = new Dictionary<string, int>()
            {
                { "Edicion de video", 145000 },
                { "Arquitectura", 127000 },
                { "Gaming", 101000 }
            };
            MesesGanancias = new Dictionary<string, int>()
            {
                { "Junio", 1270000 },
                { "Julio", 1010000 },
                { "Agosto", 1450000 }
            };
            Componentes = new List<ComponenteVista>()
            {
                new ComponenteVista() { Nombre = "SSD 256GB Crucial" },
                new ComponenteVista() { Nombre = "RAM 8GB Kingston" },
                new ComponenteVista() { Nombre = "HDD 1TB WD" },
                new ComponenteVista() { Nombre = "R5 3400G" }
            };
        }

        public string LineData;
        public Dictionary<string, int> TiposUso;
        public Dictionary<string, int> MesesGanancias;
        public List<ComponenteVista> Componentes;
    }

    public class ComponenteVista
    {
        public string Nombre { get; set; }
        public int Id { get; internal set; }
    }
}