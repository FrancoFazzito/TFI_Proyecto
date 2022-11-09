using Aplicacion;
using Dominio;
using System;
using System.Linq;
using System.Web.UI;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web13 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList2.DataSource = new GestorTipoUso().Todos.Select(t => t.Nombre);
                DropDownList2.DataBind();

                DropDownList3.DataSource = new GestorImportancias().Todos;
                DropDownList3.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormHelper.ValidarNumeroTextbox(TextBox1))
                {
                    labelErrorValidacion.Visible = true;
                }
                var tipoUso = DropDownList2.SelectedValue;
                var importancia = DropDownList3.SelectedIndex == 0 ? "precio" : "calidad";
                var precio = decimal.Parse(FormHelper.ObtenerValorText(TextBox1));
                var requerimiento = new RequerimientoArmado(tipoUso, importancia, precio);
                var director = new DirectorArmadorComputadora(requerimiento);
                var computadoraArmada = director.Computadora;
                Session["computadoraArmada"] = computadoraArmada;
                Response.Redirect("crear_pedido.aspx");
            }
            catch (ExcepcionRequerimientoInvalido)
            {
                labelErrorPresupuesto.Visible = true;
            }
        }
    }
}