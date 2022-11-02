using Aplicacion.Pedidos;
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
                ActualizarGrid();
            }
        }

        private void ActualizarGrid()
        {
            GridView1.DataSource = ObtenterDatatableComponentes(_gestorPedido.TodosClienteLogueado);
            GridView1.DataBind();
        }

        private DataTable ObtenterDatatableComponentes(IEnumerable<Pedido> entrada)
        {
            using (DataTable datatable = new DataTable())
            {
                datatable.Columns.Add("Id", typeof(int));
                datatable.Columns.Add("Fecha", typeof(DateTime));
                datatable.Columns.Add("Precio", typeof(string));
                foreach (Pedido pedido in entrada)
                {
                    datatable.Rows.Add(pedido.Id, pedido.Fecha, $"${pedido.Computadora.Precio}");
                }
                return datatable;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Dominio.Computadora computadora = GetPedidoDataGrid(sender).Computadora;
            IEnumerable<Dominio.Componente> enumerable = computadora.Componentes.Where(c => c.Tipo == "RAM");
            GridViewComputadoraSeleccionada.DataSource = new List<string>
            {
                $"CPU: {computadora["CPU"].Nombre}",
                $"Mother: {computadora["MOTHER"].Nombre}",
                $"GPU: {(computadora["GPU"] == null ? "Video integrado" : computadora["GPU"].Nombre)}",
                $"Memoria: {enumerable.Sum(c => c.Capacidad)}GB",
                $"HDD: {computadora["HDD"].Nombre}",
                $"SSD: {computadora["SSD"].Nombre}"
            };
            GridViewComputadoraSeleccionada.DataBind();
        }

        protected void GridViewComputadoraSeleccionada_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = ObtenterDatatableComponentes(_gestorPedido.TodosClienteLogueado);
            GridView1.DataBind();
        }

        private Pedido GetPedidoDataGrid(object sender)
        {
            return _gestorPedido.TodosClienteLogueado.ElementAt(GridView1.PageIndex * GridView1.PageSize + FormHelper.ObtenerRowIndexGrid(sender));
        }
    }
}