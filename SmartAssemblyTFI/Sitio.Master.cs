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
                LinkButton7.Visible = true;
                LinkButton3.Visible = true;
                LinkButton7.Text = $"¡Hola {SesionCliente.Logueado.Nombre}!";
            }
            if (SesionEmpleado.Logueado != null)
            {
                LinkButton7.Visible = true;
                LinkButton3.Visible = true;
                LinkButton7.Text = $"¡Hola {SesionEmpleado.Logueado.Nombre}!";
            }
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
            LinkButton7.Visible = false;
            LinkButton3.Visible = false;
            Session.Clear();
        }
    }
}