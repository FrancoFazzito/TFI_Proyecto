using Aplicacion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        private readonly GestorReporting _gestorReporting = new GestorReporting();

        protected void Page_Load(object sender, EventArgs e) => FormHelper.ChequearAdminLogueado(this);

        public string LineData
        {
            get
            {
                var data = "[";
                foreach (var valorMes in _gestorReporting.ObtenerValorPedidosDoceMeses)
                {
                    data += $"[{valorMes.Key},{valorMes.Value}], ";
                }
                data = data.Remove(data.Length - 2);
                data += "]";
                return data;
            }
        }

        public Dictionary<string, decimal> ClientesSegmentados => _gestorReporting.ClientesSegmentados;

        public Dictionary<string, string> TiposUsoMasSolicitados => _gestorReporting.TiposUsoMasSolicitados;

        public Dictionary<string, decimal> MesesGanancias => _gestorReporting.GananciasUltimosMeses.ToDictionary(x => NumeroDeMesANombre(x), x => x.Value);

        public Dictionary<string, string> Componentes => _gestorReporting.ComponentesMasVendidos;

        private static string NumeroDeMesANombre(KeyValuePair<string, decimal> x)
        {
            return new CultureInfo("es-ES", false).DateTimeFormat.GetMonthName(int.Parse(x.Key));
        }
    }
}