using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        private readonly GestorTipoUso _gestorTipoUso = new GestorTipoUso();

        protected void Page_Load(object sender, EventArgs e)
        {
            FormHelper.ChequearAdminLogueado(this);
            if (!Page.IsPostBack)
            {
                ActualizarDataGrid();
            }
        }

        private void ActualizarDataGrid()
        {
            GridView1.DataSource = ObtenerDatatableTiposUso(TiposUso);
            GridView1.DataBind();
        }

        private IEnumerable<TipoUso> TiposUso => _gestorTipoUso.Todos;

        private DataTable ObtenerDatatableTiposUso(IEnumerable<TipoUso> entrada)
        {
            using (var datatable = new DataTable())
            {
                datatable.Columns.Add("Id", typeof(int));
                datatable.Columns.Add("Nombre", typeof(string));
                foreach (var tipoUso in entrada)
                {
                    datatable.Rows.Add(tipoUso.Id, tipoUso.Nombre);
                }
                return datatable;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = ObtenerDatatableTiposUso(_gestorTipoUso.Todos);
            GridView1.DataBind();
        }

        protected void BajaButton_Click(object sender, EventArgs e)
        {
            _gestorTipoUso.Eliminar(GetTiposUsoDataGrid(sender).Id);
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            GridView1.DataSource = ObtenerDatatableTiposUso(TiposUso);
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DetallarTipoUsoEnFormulario(GetTiposUsoDataGrid(sender));
            ActualizarGrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            _gestorTipoUso.Agregar(TipoUsoCargado);
            ActualizarGrid();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            _gestorTipoUso.Modificar(TipoUsoCargado);
            ActualizarGrid();
        }

        private void DetallarTipoUsoEnFormulario(TipoUso tipoUso)
        {
            TextBox3.Text = tipoUso.Id.ToString();
            TextBox1.Text = tipoUso.Nombre;
            TextBox2.Text = tipoUso.Cpu.ToString();
            TextBox4.Text = tipoUso.Gpu.ToString();
            TextBox5.Text = tipoUso.Ram.ToString();
            TextBox6.Text = tipoUso.Hdd.ToString();
            TextBox7.Text = tipoUso.Ssd.ToString();
        }

        private TipoUso TipoUsoCargado => new TipoUso()
        {
            Id = int.Parse(TextBox3.Text),
            Nombre = TextBox1.Text,
            Cpu = int.Parse(TextBox2.Text),
            Gpu = int.Parse(TextBox4.Text),
            Ram = int.Parse(TextBox5.Text),
            Hdd = int.Parse(TextBox6.Text),
            Ssd = int.Parse(TextBox7.Text)
        };

        private TipoUso GetTiposUsoDataGrid(object sender) => _gestorTipoUso.Todos.ElementAt((GridView1.PageIndex * GridView1.PageSize) + FormHelper.ObtenerRowIndexGrid(sender));
    }
}