using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;

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
    }
}