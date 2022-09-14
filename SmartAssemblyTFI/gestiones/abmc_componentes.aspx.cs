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
    public partial class Formulario_web19 : Page
    {
        private readonly GestorComponente gestorComponente = new GestorComponente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FormHelper.RellenarDropDownList(tiposComponenteDll, TiposDeComponente);
                FormHelper.RellenarDropDownList(tiposFormatoDll, TiposDeFormato);
                FormHelper.RellenarDropDownList(tiposMemoriaDll, TiposDeMemoria);
                ActualizarGrid();

                DropDownList2_SelectedIndexChanged(null, null);
            }
        }

        private void ActualizarGrid()
        {
            ComponentesGrid.DataSource = ObtenterDatatableComponentes(Componentes);
            ComponentesGrid.DataBind();
        }

        private DataTable ObtenterDatatableComponentes(IEnumerable<Componente> entrada)
        {
            using (var datatable = new DataTable())
            {
                datatable.Columns.Add("Id", typeof(int));
                datatable.Columns.Add("Nombre", typeof(string));
                foreach (var componente in entrada)
                {
                    datatable.Rows.Add(componente.Id, componente.Nombre);
                }
                return datatable;
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarFiltro();
            switch (tiposComponenteDll.SelectedValue)
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

                case "MOTHER":
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

                case "TOWER":
                    TamanoFan.Visible = true;
                    TipoFormato.Visible = true;
                    break;

                case "FAN":
                    TamanoFan.Visible = true;
                    Socket.Visible = true;
                    LabelSocket.Text = $"Separar con - cada socket valido (Ej.: AM4-1151-1155)";
                    break;

                default:
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
            ComponentesGrid.PageIndex = e.NewPageIndex;
            ComponentesGrid.DataSource = ObtenterDatatableComponentes(Componentes);
            ComponentesGrid.DataBind();
        }

        protected void BajaButton_Click(object sender, EventArgs e)
        {
            gestorComponente.Eliminar(GetComponenteDataGrid(sender).Id);
            ActualizarGrid();
        }

        protected void Button2_Click(object sender, EventArgs e) //agregar validaciones
        {
            gestorComponente.Agregar(ComponenteCargado);
            ActualizarGrid();
        }

        protected void Button3_Click(object sender, EventArgs e) //agregar validaciones
        {
            gestorComponente.Modificar(ComponenteCargado);
            ActualizarGrid();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DetallarComponenteEnFormulario(GetComponenteDataGrid(sender));
        }

        private void DetallarComponenteEnFormulario(Componente componente)
        {
            idtxt.Text = componente.Id.ToString();
            canalestxt.Text = componente.Canales.ToString();
            capacidadtxt.Text = componente.Capacidad.ToString();
            consumotxt.Text = componente.ConsumoEnWatts.ToString();
            frecuenciaMaximatxt.Text = componente.MaximaFrecuencia.ToString();
            nivelFantxt.Text = componente.NivelFanIntegrado.ToString();
            nivelVideoIntregadotxt.Text = componente.NivelVideoIntegrado.ToString();
            perfomancetxt.Text = componente.Perfomance.ToString();
            stocktxt.Text = componente.Stock.ToString();
            limiteStocktxt.Text = componente.StockLimite.ToString();
            tamanoFantxt.Text = componente.TamanoFan.ToString();
            preciotxt.Text = componente.Precio.ToString();
            nombretxt.Text = componente.Nombre ?? "";
            sockettxt.Text = componente.Socket ?? "";
            altaFrecuenciaCheck.Checked = componente.NecesitaAltaFrecuencia;
            videoIntegradoCheck.Checked = componente.TieneVideoIntegrado;
            tiposComponenteDll.SelectedValue = tiposComponenteDll.Items.FindByValue(componente.Tipo ?? TiposDeComponente[0]).Value;
            tiposFormatoDll.SelectedValue = tiposFormatoDll.Items.FindByValue(componente.TipoFormato ?? TiposDeFormato[0]).Value;
            tiposMemoriaDll.SelectedValue = tiposMemoriaDll.Items.FindByValue(componente.TipoMemoria ?? TiposDeMemoria[0]).Value;
            DropDownList2_SelectedIndexChanged(null, null);
        }

        public Componente ComponenteCargado => new Componente()
        {
            Id = FormHelper.ObtenerValorTextInt(idtxt),
            Canales = FormHelper.ObtenerValorTextInt(canalestxt),
            Capacidad = FormHelper.ObtenerValorTextInt(capacidadtxt),
            ConsumoEnWatts = FormHelper.ObtenerValorTextInt(consumotxt),
            MaximaFrecuencia = FormHelper.ObtenerValorTextInt(frecuenciaMaximatxt),
            NivelFanIntegrado = FormHelper.ObtenerValorTextInt(nivelFantxt),
            NivelVideoIntegrado = FormHelper.ObtenerValorTextInt(nivelVideoIntregadotxt),
            Perfomance = FormHelper.ObtenerValorTextInt(perfomancetxt),
            Stock = FormHelper.ObtenerValorTextInt(stocktxt),
            StockLimite = FormHelper.ObtenerValorTextInt(stocktxt),
            TamanoFan = FormHelper.ObtenerValorTextInt(tamanoFantxt),
            Precio = FormHelper.ObtenerValorTextDecimal(preciotxt),
            Nombre = FormHelper.ObtenerValorText(nombretxt),
            Socket = FormHelper.ObtenerValorText(sockettxt),
            NecesitaAltaFrecuencia = altaFrecuenciaCheck.Checked,
            TieneVideoIntegrado = videoIntegradoCheck.Checked,
            Tipo = tiposComponenteDll.SelectedValue,
            TipoFormato = tiposFormatoDll.SelectedValue,
            TipoMemoria = tiposMemoriaDll.SelectedValue
        };

        private Componente GetComponenteDataGrid(object sender) => Componentes.ElementAt(ComponentesGrid.PageIndex * ComponentesGrid.PageSize + FormHelper.ObtenerRowIndexGrid(sender));

        private IEnumerable<Componente> Componentes => gestorComponente.Todos;
        private static List<string> TiposDeFormato => new List<string>() { "ATX", "ITX", "MATX" };
        private static List<string> TiposDeMemoria => new List<string>() { "DDR3", "DDR4", "DDR5" };
        private static List<string> TiposDeComponente => new List<string>() { "GPU", "CPU", "RAM", "MOTHER", "PSU", "SSD", "HDD", "TOWER", "FAN" };
    }
}