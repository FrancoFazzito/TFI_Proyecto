using Aplicacion;
using Dominio;
using System;
using System.Web.UI;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        private readonly GestorCliente _gestorCliente = new GestorCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GestorDomicilio domicilio = new GestorDomicilio();
                DropDownList1.DataSource = domicilio.Provincias;
                DropDownList1.DataBind();
                DropDownList3.DataSource = domicilio.Barrios;
                DropDownList3.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!TextboxsValidos)
            {
                labelError.Visible = true;
                return;
            }
            Cliente cliente = new Cliente()
            {
                Nombre = TextBox1.Text,
                Apellido = TextBox2.Text,
                FechaNacimiento = DateTime.Parse(TextBox5.Text),
                Telefono = TextBox3.Text,
                Barrio = DropDownList3.SelectedValue,
                Provincia = DropDownList1.SelectedValue,
                Correo = TextBox4.Text,
                Contrasena = TextBox8.Text
            };
            if (TextBox9.Text != cliente.Contrasena)
            {
                labelErrorContrasenaCoincidente.Visible = true;
                return;
            }
            if (new GestorContrasena().ValidarRequerimientos(cliente.Contrasena))
            {
                labelErrorContrasena.Visible = true;
                return;
            }
            _gestorCliente.Agregar(cliente);
        }

        private bool TextboxsValidos => FormHelper.ValidarTextoTextbox(TextBox1)
                                        && FormHelper.ValidarTextoTextbox(TextBox2)
                                        && FormHelper.ValidarTextoTextbox(TextBox3)
                                        && FormHelper.ValidarTextoTextbox(TextBox4)
                                        && FormHelper.ValidarTextoTextbox(TextBox5)
                                        && FormHelper.ValidarTextoTextbox(TextBox8)
                                        && FormHelper.ValidarTextoTextbox(TextBox9);
    }
}