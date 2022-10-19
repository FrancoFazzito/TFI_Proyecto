using Aplicacion;
using System;

namespace SmartAssemblyTFI
{
    public partial class Sitio : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SesionCliente.Logueado != null)
            {
                IntercambiarBotonesClienteLogueado();
                LinkButton7.Text = $"¡Hola {SesionCliente.Logueado.Nombre}!";
            }
            if (SesionEmpleado.Logueado != null)
            {
                IntercambiarBotonesEmpleadoLogueado();
                LinkButton7.Text = $"¡Hola {SesionEmpleado.Logueado.Nombre}!";
            }
        }

        private void IntercambiarBotonesClienteLogueado()
        {
            LinkButton7.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
            LinkButton1.Visible = false;
            LinkButton2.Visible = false;
        }

        private void IntercambiarBotonesEmpleadoLogueado()
        {
            LinkButton7.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = false;
            LinkButton1.Visible = false;
            LinkButton2.Visible = false;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (SesionCliente.Logueado != null)
            {
                new Login().SalirCliente();
            }
            if (SesionEmpleado.Logueado != null)
            {
                new Login().SalirEmpleado();
            }
            IntercambiarBotonesUsuarioDeslogueado();
            Session.Clear();
            Response.Redirect(Page.AppRelativeVirtualPath.Contains("home") ? "home_page.aspx" : "../home_page.aspx");
        }

        private void IntercambiarBotonesUsuarioDeslogueado()
        {
            LinkButton7.Visible = false;
            LinkButton3.Visible = false;
            LinkButton4.Visible = false;
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
        }

        protected void LinkButton4_Click(object sender, EventArgs e) => Response.Redirect(Page.AppRelativeVirtualPath.Contains("home") ? "consulta/mis_pedidos.aspx" : "../consulta/mis_pedidos.aspx");
    }
}