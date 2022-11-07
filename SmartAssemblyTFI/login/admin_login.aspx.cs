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
            if (FormHelper.ValidarTextoTextbox(TextBox1) || FormHelper.ValidarTextoTextbox(TextBox2))
            {
                labelError.Visible = true;
                return;
            }

            string nombre = FormHelper.ObtenerValorText(TextBox1);
            string contrasena = FormHelper.ObtenerValorText(TextBox2);
            bool esExitoso = new Login().IngresarEmpleado(nombre, contrasena);
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