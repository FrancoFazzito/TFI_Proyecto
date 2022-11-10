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
            if (!FormHelper.ValidarTextoTextbox(TextBox1) || !FormHelper.ValidarTextoTextbox(TextBox2))
            {
                labelError.Visible = true;
                return;
            }

            var correo = FormHelper.ObtenerValorText(TextBox1);
            var contrasena = FormHelper.ObtenerValorText(TextBox2);
            var esExistoso = new Login().IngresarCliente(correo, contrasena);
            if (!esExistoso)
            {
                labelError.Visible = true;
                return;
            }
            Session["clienteLogueado"] = SesionCliente.Logueado;
            SesionEmpleado.Salir();
            if (Session["vieneDeCrearPedido"] != null && (bool)Session["vieneDeCrearPedido"])
            {
                Response.Redirect("../venta/crear_pedido.aspx");
            }
            Response.Redirect("../home_page.aspx");
        }
    }
}