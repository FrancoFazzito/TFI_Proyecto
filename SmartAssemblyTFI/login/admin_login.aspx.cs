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
            var esExitoso = new Login().IngresarEmpleado(nombre, contrasena);
            if (!esExitoso) //mostrar label que le fue mal :(
            {

            }
            Session["empleadoLogueado"] = SesionEmpleado.Logueado;
            Response.Redirect("../home_admin.aspx");
        }
    }
}