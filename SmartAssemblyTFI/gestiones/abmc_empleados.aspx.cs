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
            labelError.Visible = false;
            labelErrorContrasena.Visible = false;
            labelErrorContrasenaCoincidente.Visible = false;
            labelErrorEliminacion.Visible = false;
            labelErrorNombreUsuarioExistente.Visible = false;
            FormHelper.ChequearAdminLogueado(this);
            if (!Page.IsPostBack)
            {
                ActualizarGrid();
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
            var id = GetEmpleadoDataGrid(sender).Id;
            if (id == SesionEmpleado.Logueado.Id || new GestorEmpleado().Todos.Count() == 1)
            {
                labelErrorEliminacion.Visible = true;
                return;
            }
            _gestorEmpleado.Eliminar(id);
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
            if (!new GestorContrasena().ValidarRequerimientos(TextBox7.Text))
            {
                labelErrorContrasena.Visible = true;
                return;
            }
            if (ContrasenasCoincidentes)
            {
                labelErrorContrasenaCoincidente.Visible = true;
                return;
            }
            var empleado = EmpleadoCargadoAgregar;
            if (NombreUsuarioYaRegistrado(empleado))
            {
                labelErrorNombreUsuarioExistente.Visible = true;
                return;
            }
            _gestorEmpleado.Agregar(empleado);
            ActualizarGrid();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!ValidacionTextboxs)
            {
                labelError.Visible = true;
                return;
            }
            if (TextBox7.Text == "")
            {
                _gestorEmpleado.Modificar(EmpleadoCargado);
                ActualizarGrid();
                return;
            }
            if (!new GestorContrasena().ValidarRequerimientos(TextBox7.Text))
            {
                labelErrorContrasena.Visible = true;
                return;
            }
            if (ContrasenasCoincidentes)
            {
                labelErrorContrasenaCoincidente.Visible = true;
                return;
            }
            _gestorEmpleado.Modificar(EmpleadoCargado, TextBox7.Text);
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

        private Empleado EmpleadoCargadoAgregar => new Empleado()
        {
            Id = 0,
            Apellido = TextBox5.Text,
            Contrasena = TextBox7.Text,
            Correo = TextBox2.Text,
            Nombre = TextBox4.Text,
            NombreUsuario = TextBox1.Text
        };

        private Empleado EmpleadoCargado => new Empleado()
        {
            Id = int.Parse(TextBox3.Text),
            Apellido = TextBox5.Text,
            Contrasena = TextBox7.Text,
            Correo = TextBox2.Text,
            Nombre = TextBox4.Text,
            NombreUsuario = TextBox1.Text
        };

        private bool NombreUsuarioYaRegistrado(Empleado empleado) => _gestorEmpleado.Todos.Any(x => x.NombreUsuario.ToLower() == empleado.NombreUsuario.ToLower());

        private bool ContrasenasCoincidentes => TextBox6.Text != TextBox7.Text;

        private Empleado GetEmpleadoDataGrid(object sender) => _gestorEmpleado.Todos.ElementAt((EmpleadosGrid.PageIndex * EmpleadosGrid.PageSize) + FormHelper.ObtenerRowIndexGrid(sender));

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

        public bool ValidacionTextboxs => FormHelper.ValidarTextoTextbox(TextBox1)
                && FormHelper.ValidarTextoTextbox(TextBox2)
                && FormHelper.ValidarNumeroTextbox(TextBox3)
                && FormHelper.ValidarTextoTextbox(TextBox4)
                && FormHelper.ValidarTextoTextbox(TextBox5);

        public bool ValidacionTextboxsAgregar => FormHelper.ValidarTextoTextbox(TextBox1)
                && FormHelper.ValidarTextoTextbox(TextBox2)
                && FormHelper.ValidarTextoTextbox(TextBox4)
                && FormHelper.ValidarTextoTextbox(TextBox5)
                && FormHelper.ValidarTextoTextbox(TextBox7);
    }
}