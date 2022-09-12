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
            string correo = TextBox1.Text;
            string contrasena = TextBox2.Text;
            bool esExistoso = new Login().IngresarCliente(correo, contrasena);
            if (!esExistoso)
            {

            }
            Session["clienteLogueado"] = SesionCliente.Logueado;

            if (Session["vieneDeCrearPedido"] != null && (bool)Session["vieneDeCrearPedido"])
            {
                Response.Redirect("../venta/crear_pedido.aspx");
            }


            Response.Redirect("../home_page.aspx");
        }
    }
}