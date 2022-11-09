using Aplicacion;
using System;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!FormHelper.ValidarTextoTextbox(TextBox1) || !FormHelper.ValidarTextoTextbox(TextBox2))
            {
                labelError.Visible = true;
                return;
            }

            var nombre = FormHelper.ObtenerValorText(TextBox1);
            var contrasena = FormHelper.ObtenerValorText(TextBox2);
            var esExitoso = new Login().IngresarEmpleado(nombre, contrasena);
            if (!esExitoso)
            {
                labelError.Visible = true;
                return;
            }
            SesionCliente.Salir();
            Session["empleadoLogueado"] = SesionEmpleado.Logueado;
            Response.Redirect("../home_admin.aspx");
        }
    }
}