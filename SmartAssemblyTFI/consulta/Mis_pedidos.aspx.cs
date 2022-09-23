using Aplicacion.Pedidos;
using System;
using System.Collections.Generic;
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
                GridView1.DataSource = _gestorPedido.TodosClienteLogueado.Select(pedido => new { pedido.Id, pedido.Fecha, pedido.Computadora.Precio });
                GridView1.DataBind();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            var index = FormHelper.ObtenerRowIndexGrid(sender);
            var computadora = _gestorPedido.TodosClienteLogueado.ElementAt(index).Computadora;
            var memoria = computadora.Componentes.Where(c => c.Tipo == "RAM").Sum(c => c.Capacidad);
            GridViewComputadoraSeleccionada.DataSource = new List<string>
            {
                $"CPU: {computadora["CPU"].Nombre}",
                $"Mother: {computadora["MOTHER"].Nombre}",
                $"GPU: {(computadora["GPU"]== null ? "Video integrado" : computadora["GPU"].Nombre)}",
                $"Memoria: {memoria}GB",
                $"HDD: {computadora["HDD"].Nombre}",
                $"SSD: {computadora["SSD"].Nombre}"
            };
            GridViewComputadoraSeleccionada.DataBind();
        }
    }
}