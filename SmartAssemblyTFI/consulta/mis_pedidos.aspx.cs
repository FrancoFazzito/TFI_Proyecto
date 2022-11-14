using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web17 : Page
    {
        private readonly GestorPedido _gestorPedido = new GestorPedido();

        protected void Page_Load(object sender, EventArgs e)
        {
            FormHelper.ChequearClienteLogueado(this);
            if (!Page.IsPostBack)
            {
                GridView1.DataSource = ObtenerDatatablePedidos(_gestorPedido.TodosClienteLogueado);
                GridView1.DataBind();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            var computadora = GetPedidoDataGrid(sender).Computadora;
            GridViewComputadoraSeleccionada.DataSource = new List<string>
            {
                $"CPU: {computadora["CPU"].Nombre}",
                $"Mother: {computadora["MOTHER"].Nombre}",
                $"GPU: {(computadora["GPU"] == null ? "Video integrado" : computadora["GPU"].Nombre)}",
                $"Memoria: {computadora.Componentes.Where(c => c.Tipo == "RAM").Sum(c => c.Capacidad)}GB",
                $"HDD: {computadora["HDD"].Nombre}",
                $"SSD: {computadora["SSD"].Nombre}"
            };
            GridViewComputadoraSeleccionada.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = ObtenerDatatablePedidos(_gestorPedido.TodosClienteLogueado);
            GridView1.DataBind();
        }

        private Pedido GetPedidoDataGrid(object sender) => _gestorPedido.TodosClienteLogueado.ElementAt((GridView1.PageIndex * GridView1.PageSize) + FormHelper.ObtenerRowIndexGrid(sender));

        private DataTable ObtenerDatatablePedidos(IEnumerable<Pedido> entrada)
        {
            using (var datatable = new DataTable())
            {
                datatable.Columns.Add("Id", typeof(int));
                datatable.Columns.Add("Fecha de pedido", typeof(string));
                datatable.Columns.Add("Precio", typeof(string));
                foreach (var pedido in entrada)
                {
                    datatable.Rows.Add(pedido.Id, pedido.Fecha.Date, $"${pedido.Computadora.Precio}");
                }
                return datatable;
            }
        }
    }
}