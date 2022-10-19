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
            var nombre = TextBox1.Text;
            var contrasena = TextBox2.Text;
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contrasena))
            {
                labelError.Visible = true;
                return;
            }

            var esExitoso = new Login().IngresarEmpleado(nombre, contrasena);
            if (!esExitoso)
            {
                labelError.Visible = true;
                return;
            }

            Session["empleadoLogueado"] = SesionEmpleado.Logueado;
            Response.Redirect("../home_admin.aspx");
        }
    }
}