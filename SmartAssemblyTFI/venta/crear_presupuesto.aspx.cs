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
                if (string.IsNullOrEmpty(TextBox1.Text))
                {
                    throw new ExcepcionRequerimientoInvalido();
                }
                string tipoUso = DropDownList2.SelectedValue;
                string importancia = DropDownList3.SelectedIndex == 0 ? "precio" : "calidad";
                decimal precio = decimal.Parse(TextBox1.Text);
                RequerimientoArmado requerimiento = new RequerimientoArmado(tipoUso, importancia, precio);
                DirectorArmadorComputadora director = new DirectorArmadorComputadora(requerimiento);
                Computadora computadoraArmada = director.Computadora;
                Session["computadoraArmada"] = computadoraArmada;
                Response.Redirect("crear_pedido.aspx");
            }
            catch (ExcepcionRequerimientoInvalido)
            {
                labelError.Visible = true;
            }
        }
    }
}