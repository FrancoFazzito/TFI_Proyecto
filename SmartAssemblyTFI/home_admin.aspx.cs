using Aplicacion;
using System;
using System.Collections.Generic;

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

        public Dictionary<string, decimal> MesesGanancias => _gestorReporting.GananciasUltimosMeses;

        public Dictionary<string, string> Componentes => _gestorReporting.ComponentesMasVendidos;
    }
}