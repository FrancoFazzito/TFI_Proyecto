using Aplicacion;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAssemblyTFI
{
    public static class FormHelper
    {
        public static int ObtenerValorTextInt(TextBox textBox) => textBox.Text == "" ? 0 : int.Parse(textBox.Text);

        public static decimal ObtenerValorTextDecimal(TextBox textBox) => textBox.Text == "" ? 0 : decimal.Parse(textBox.Text);

        public static string ObtenerValorText(TextBox textBox) => textBox.Text == "" ? null : textBox.Text;

        public static int ObtenerRowIndexGrid(object sender) => ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

        public static void RellenarDropDownList(DropDownList dropDown, object value)
        {
            dropDown.DataSource = value;
            dropDown.DataBind();
        }

        public static void ChequearClienteLogueado(Page page)
        {
            if (SesionCliente.Logueado == null)
            {
                page.Response.Redirect(page.AppRelativeVirtualPath.Contains("home") ? "login/cliente_login.aspx" : "../login/cliente_login.aspx");
            }
        }

        public static void ChequearAdminLogueado(Page page)
        {
            if (SesionEmpleado.Logueado == null)
            {
                page.Response.Redirect(page.AppRelativeVirtualPath.Contains("home") ? "login/admin_login.aspx" : "../login/admin_login.aspx");
            }
        }
    }
}