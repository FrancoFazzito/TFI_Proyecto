using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web12 : Page
    {
        private readonly GestorCliente _gestorCliente = new GestorCliente();
        private readonly GestorDomicilio _gestorDomicilio = new GestorDomicilio();

        protected void Page_Load(object sender, EventArgs e)
        {
            labelError.Visible = false;
            labelErrorContrasena.Visible = false;
            labelErrorContrasenaCoincidente.Visible = false;
            labelErrorMailExistente.Visible = false;
            if (!Page.IsPostBack)
            {
                FormHelper.RellenarDropDownList(DropDownList1, _gestorDomicilio.Provincias.Select(x => x.Nombre));
                DropDownList1_SelectedIndexChanged(null, null);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var fechaNacimiento = DateTime.Parse(TextBox5.Text);
            if (!TextboxsValidos || !NombreApellidoValidos || !TelefonoValido || !FechaNacimientoValida(fechaNacimiento))
            {
                labelError.Visible = true;
                return;
            }
            var cliente = new Cliente()
            {
                Nombre = TextBox1.Text,
                Apellido = TextBox2.Text,
                FechaNacimiento = fechaNacimiento,
                Telefono = TextBox3.Text,
                Barrio = DropDownList3.SelectedValue,
                Provincia = DropDownList1.SelectedValue,
                Correo = TextBox4.Text,
                Contrasena = TextBox8.Text
            };
            if (MailYaRegistrado(cliente))
            {
                labelErrorMailExistente.Visible = true;
                return;
            }
            if (!ValidarContrasenaCoincidente(cliente))
            {
                labelErrorContrasenaCoincidente.Visible = true;
                return;
            }
            if (!new GestorContrasena().ValidarRequerimientos(cliente.Contrasena))
            {
                labelErrorContrasena.Visible = true;
                return;
            }
            _gestorCliente.Agregar(cliente);
            new Login().IngresarCliente(cliente.Correo, TextBox8.Text);
            Response.Redirect("../home_page.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var barrios = _gestorDomicilio.Provincias.First(x => x.Nombre == DropDownList1.SelectedValue).Barrios.Select(x => x.Nombre);
            if (barrios == null)
            {
                FormHelper.RellenarDropDownList(DropDownList3, new List<string>() { "" });
                return;
            }
            FormHelper.RellenarDropDownList(DropDownList3, barrios);
        }

        private static bool FechaNacimientoValida(DateTime fechaNacimiento) => fechaNacimiento.Year > 1900 && fechaNacimiento < DateTime.Now;

        private bool ValidarContrasenaCoincidente(Cliente cliente) => TextBox9.Text == cliente.Contrasena;

        private bool TelefonoValido => TextBox3.Text.All(x => char.IsDigit(x));

        private bool NombreApellidoValidos => TextBox1.Text.All(x => char.IsLetter(x) && TextBox2.Text.All(c => char.IsLetter(c)));

        private bool MailYaRegistrado(Cliente cliente) => _gestorCliente.Todos.Any(x => x.Correo.ToLower() == cliente.Correo.ToLower());

        private bool TextboxsValidos => FormHelper.ValidarTextoTextbox(TextBox1)
                                        && FormHelper.ValidarTextoTextbox(TextBox2)
                                        && FormHelper.ValidarTextoTextbox(TextBox3)
                                        && FormHelper.ValidarTextoTextbox(TextBox4)
                                        && FormHelper.ValidarTextoTextbox(TextBox5)
                                        && FormHelper.ValidarTextoTextbox(TextBox8)
                                        && FormHelper.ValidarTextoTextbox(TextBox9);
    }
}