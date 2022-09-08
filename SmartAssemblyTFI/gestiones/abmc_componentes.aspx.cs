using System;
using System.Collections.Generic;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web18 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList2.DataSource = new List<string>()
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
                DropDownList2.DataBind();
                DropDownList2_SelectedIndexChanged(null, null);

                DropDownList1.DataSource = new List<string>()
                {
                        "DDR3",
                        "DDR4",
                        "DDR5"
                };
                DropDownList1.DataBind();

                DropDownList3.DataSource = new List<string>()
                {
                        "ATX",
                        "ITX",
                        "M-ITX"
                };
                DropDownList3.DataBind();

                GridView1.DataSource = new List<Componente>()
                {
                    new Componente() { Id=1, Nombre = "R5 3400G" },
                    new Componente() { Id=2, Nombre = "RAM 8GB Kingston" },
                    new Componente() { Id=3, Nombre = "HDD 1TB WD" },
                    new Componente() { Id=4, Nombre = "SSD 256GB Crucial" }
                };
                GridView1.DataBind();
            }
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
    }
}