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
    public partial class Formulario_web20 : Page
    {
        private readonly GestorEmpleado _gestorEmpleado = new GestorEmpleado();

        protected void Page_Load(object sender, EventArgs e)
        {
            FormHelper.ChequearAdminLogueado(this);
            labelError.Visible = false;
            if (!Page.IsPostBack)
            {
                ActualizarGrid();
            }
        }

        private IEnumerable<Empleado> Empleados => _gestorEmpleado.Todos;

        private DataTable ObtenerDatatableEmpleados(IEnumerable<Empleado> entrada)
        {
            using (var datatable = new DataTable())
            {
                datatable.Columns.Add("Id", typeof(int));
                datatable.Columns.Add("Nombre", typeof(string));
                foreach (var empleado in entrada)
                {
                    datatable.Rows.Add(empleado.Id, empleado.Nombre);
                }
                return datatable;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EmpleadosGrid.PageIndex = e.NewPageIndex;
            EmpleadosGrid.DataSource = ObtenerDatatableEmpleados(_gestorEmpleado.Todos);
            EmpleadosGrid.DataBind();
        }

        protected void BajaButton_Click(object sender, EventArgs e)
        {
            _gestorEmpleado.Eliminar(GetEmpleadoDataGrid(sender).Id);
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            EmpleadosGrid.DataSource = ObtenerDatatableEmpleados(Empleados);
            EmpleadosGrid.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DetallarEmpleadoEnFormulario(GetEmpleadoDataGrid(sender));
            ActualizarGrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!ValidacionTextboxsAgregar)
            {
                labelError.Visible = true;
                return;
            }
            _gestorEmpleado.Agregar(EmpleadoCargado);
            ActualizarGrid();
        }

        public bool ValidacionTextboxs => FormHelper.ValidarTextbox(TextBox1)
                && FormHelper.ValidarTextbox(TextBox2)
                && FormHelper.ValidarTextbox(TextBox3)
                && FormHelper.ValidarTextbox(TextBox4)
                && FormHelper.ValidarTextbox(TextBox5);

        public bool ValidacionTextboxsAgregar => FormHelper.ValidarTextbox(TextBox1)
                && FormHelper.ValidarTextbox(TextBox2)
                && FormHelper.ValidarTextbox(TextBox3)
                && FormHelper.ValidarTextbox(TextBox4)
                && FormHelper.ValidarTextbox(TextBox5)
                && FormHelper.ValidarTextbox(TextBox7);

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!ValidacionTextboxs)
            {
                labelError.Visible = true;
                return;
            }
            _gestorEmpleado.Modificar(EmpleadoCargado);
            ActualizarGrid();
        }

        private void DetallarEmpleadoEnFormulario(Empleado empleado)
        {
            TextBox3.Text = empleado.Id.ToString();
            TextBox1.Text = empleado.NombreUsuario;
            TextBox2.Text = empleado.Correo;
            TextBox4.Text = empleado.Nombre;
            TextBox5.Text = empleado.Apellido;
        }

        private Empleado EmpleadoCargado => new Empleado()
        {
            Id = int.Parse(TextBox3.Text),
            Apellido = TextBox5.Text,
            Contrasena = TextBox7.Text,
            Correo = TextBox2.Text,
            Nombre = TextBox4.Text,
            NombreUsuario = TextBox1.Text
        };

        private Empleado GetEmpleadoDataGrid(object sender) => _gestorEmpleado.Todos.ElementAt((EmpleadosGrid.PageIndex * EmpleadosGrid.PageSize) + FormHelper.ObtenerRowIndexGrid(sender));
    }
}