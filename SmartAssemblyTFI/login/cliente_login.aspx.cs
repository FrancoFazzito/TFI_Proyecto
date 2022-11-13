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
            if (!CorreoContrasenaValido || !ContrasenaValida)
            {
                labelError.Visible = true;
                return;
            }
            Session["clienteLogueado"] = SesionCliente.Logueado;
            SesionEmpleado.Salir();
            if (VieneDeCrearPedido)
            {
                Response.Redirect("../venta/crear_pedido.aspx");
            }
            Response.Redirect("../home_page.aspx");
        }

        private bool ContrasenaValida => new Login().IngresarCliente(FormHelper.ObtenerValorText(TextBox1), FormHelper.ObtenerValorText(TextBox2));

        private bool VieneDeCrearPedido => Session["vieneDeCrearPedido"] != null && (bool)Session["vieneDeCrearPedido"];

        private bool CorreoContrasenaValido => FormHelper.ValidarTextoTextbox(TextBox1) && FormHelper.ValidarTextoTextbox(TextBox2);
    }
}