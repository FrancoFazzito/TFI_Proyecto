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
                IntercambiarBotonesUsuarioLogueado();
                LinkButton7.Text = $"¡Hola {SesionCliente.Logueado.Nombre}!";
            }
            if (SesionEmpleado.Logueado != null)
            {
                IntercambiarBotonesUsuarioLogueado();
                LinkButton7.Text = $"¡Hola {SesionEmpleado.Logueado.Nombre}!";
            }
        }

        private void IntercambiarBotonesUsuarioLogueado()
        {
            LinkButton7.Visible = true;
            LinkButton3.Visible = true;
            LinkButton4.Visible = true;
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
        }

        private void IntercambiarBotonesUsuarioDeslogueado()
        {
            LinkButton7.Visible = false;
            LinkButton3.Visible = false;
            LinkButton4.Visible = false;
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
        }

        protected void LinkButton4_Click(object sender, EventArgs e) => Response.Redirect("consulta/mis_pedidos.aspx");
    }
}