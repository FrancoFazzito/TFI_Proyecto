using Aplicacion;
using System;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var correo = TextBox1.Text;
            var contrasena = TextBox2.Text;
            var esExistoso = new Login().IngresarCliente(correo, contrasena);
            if (!esExistoso)
            {

            }
            Session["clienteLogueado"] = SesionCliente.Logueado;
            Response.Redirect("../home_page.aspx");
        }
    }
}