using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartAssemblyTFI
{
    public static class FormHelper
    {
        public static int ObtenerValorTextInt(TextBox textBox) => textBox.Text == "" ? 0 : int.Parse(textBox.Text);

        public static decimal ObtenerValorTextDecimal(TextBox textBox) => textBox.Text == "" ? 0 : decimal.Parse(textBox.Text);

        public static string ObtenerValorText(TextBox textBox) => textBox.Text == "" ? null : textBox.Text;

        public static bool ObtenerValorCheck(CheckBox checkBox) => checkBox.Checked;

        public static int ObtenerRowIndexGrid(object sender) => ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

        public static void RellenarDropDownList(DropDownList dropDown, object value)
        {
            dropDown.DataSource = value;
            dropDown.DataBind();
        }
    }
}