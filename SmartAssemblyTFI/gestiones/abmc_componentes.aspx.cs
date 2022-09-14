using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web18 : System.Web.UI.Page
    {
        private readonly GestorComponente gestorComponente = new GestorComponente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList2.DataSource = ObtenerTiposDeComponente();
                DropDownList2.DataBind();
                DropDownList2_SelectedIndexChanged(null, null);

                DropDownList1.DataSource = ObtenerTiposDeMemoria();
                DropDownList1.DataBind();

                DropDownList3.DataSource = ObtenerTiposDeFormato();
                DropDownList3.DataBind();
                GridView1.DataSource = ObtenterDatatableComponentes(Componentes);
                GridView1.DataBind();
            }
        }

        private IEnumerable<Componente> Componentes => gestorComponente.Todos;

        private DataTable ObtenterDatatableComponentes(IEnumerable<Componente> entrada)
        {
            using (var datatable = new DataTable())
            {
                datatable.Columns.Add("Id", typeof(int));
                datatable.Columns.Add("Nombre", typeof(string));
                var pageSize = GridView1.PageSize;
                foreach (var componente in entrada)
                {
                    datatable.Rows.Add(componente.Id, componente.Nombre);
                }
                return datatable;
            }
        }

        private static List<string> ObtenerTiposDeFormato()
        {
            return new List<string>()
                {
                        "ATX",
                        "ITX",
                        "MATX"
                };
        }

        private static List<string> ObtenerTiposDeMemoria()
        {
            return new List<string>()
                {
                        "DDR3",
                        "DDR4",
                        "DDR5"
                };
        }

        private static List<string> ObtenerTiposDeComponente()
        {
            return new List<string>()
                {
                        "GPU",
                        "CPU",
                        "RAM",
                        "Mother",
                        "PSU",
                        "SSD",
                        "HDD",
                        "Tower",
                        "FAN"
                };
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarFiltro();
            switch (DropDownList2.SelectedValue)
            {
                case "CPU":
                    Socket.Visible = true;
                    TieneVideoIntegrado.Visible = true;
                    Canales.Visible = true;
                    AltaFrecuencia.Visible = true;
                    TipoMemoria.Visible = true;
                    NivelVideoIntegrado.Visible = true;
                    NivelFan.Visible = true;
                    FrecuenciaMaxima.Visible = true;
                    TipoMemoria.Visible = true;
                    TieneVideoIntegrado.Visible = true;
                    break;

                case "Mother":
                    Socket.Visible = true;
                    TieneVideoIntegrado.Visible = true;
                    Canales.Visible = true;
                    TipoMemoria.Visible = true;
                    FrecuenciaMaxima.Visible = true;
                    TipoFormato.Visible = true;
                    TipoMemoria.Visible = true;
                    TieneVideoIntegrado.Visible = true;
                    break;

                case "RAM":
                    FrecuenciaMaxima.Visible = true;
                    TipoMemoria.Visible = true;
                    Capacidad.Visible = true;
                    break;

                case "SSD":
                    Capacidad.Visible = true;
                    break;

                case "HDD":
                    Capacidad.Visible = true;
                    break;

                case "PSU":
                    Capacidad.Visible = true;
                    break;

                case "Tower":
                    TamanoFan.Visible = true;
                    TipoFormato.Visible = true;
                    break;

                case "FAN":
                    TamanoFan.Visible = true;
                    Socket.Visible = true;
                    LabelSocket.Text = $"Separar con - cada socket valido (Ej.: AM4-1151-1155)";
                    break;
            }
        }

        private void LimpiarFiltro()
        {
            Socket.Visible = false;
            TieneVideoIntegrado.Visible = false;
            Canales.Visible = false;
            AltaFrecuencia.Visible = false;
            TipoMemoria.Visible = false;
            NivelVideoIntegrado.Visible = false;
            NivelFan.Visible = false;
            FrecuenciaMaxima.Visible = false;
            Capacidad.Visible = false;
            TipoFormato.Visible = false;
            TieneVideoIntegrado.Visible = false;
            TamanoFan.Visible = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = ObtenterDatatableComponentes(Componentes);
            GridView1.DataBind();
        }

        protected void BajaButton_Click(object sender, EventArgs e)
        {
            var index = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            var componente = Componentes.ElementAt(GridView1.PageIndex * GridView1.PageSize + index);
            gestorComponente.Eliminar(componente.Id);
        }
    }
}