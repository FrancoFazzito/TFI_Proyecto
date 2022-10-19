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
                var domicilio = new GestorDomicilio();
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
            _gestorCliente.Agregar(new Cliente()
            {
                Nombre = TextBox1.Text,
                Apellido = TextBox2.Text,
                FechaNacimiento = DateTime.Parse(TextBox5.Text),
                Telefono = TextBox3.Text,
                Barrio = DropDownList3.SelectedValue,
                Provincia = DropDownList1.SelectedValue,
                Correo = TextBox4.Text,
                Contrasena = TextBox8.Text
            });
        }

        private bool TextboxsValidos => !string.IsNullOrEmpty(TextBox1.Text) 
                                           && !string.IsNullOrEmpty(TextBox2.Text) 
                                           && !string.IsNullOrEmpty(TextBox3.Text) 
                                           && !string.IsNullOrEmpty(TextBox4.Text) 
                                           && !string.IsNullOrEmpty(TextBox5.Text) 
                                           && !string.IsNullOrEmpty(TextBox8.Text) 
                                           && !string.IsNullOrEmpty(TextBox9.Text);
    }
}