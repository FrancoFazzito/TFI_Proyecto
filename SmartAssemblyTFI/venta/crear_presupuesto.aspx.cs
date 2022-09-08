using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList2.DataSource = new List<string>() //cargar tipos de uso con BD
            {
                "Seleccionar",
                "Gaming",
                "Edicion de video",
                "Arquitectura"
            };
            DropDownList2.DataBind();

            DropDownList3.DataSource = new List<string>() //cargar importancias con BD
            {
                "Seleccionar",
                "Precio de los componentes",
                "Calidad de los componentes"
            };
            DropDownList3.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string tipoUso = DropDownList2.SelectedValue;
            string importancia = DropDownList3.SelectedValue;
            decimal precio = decimal.Parse(TextBox1.Text);
            RequerimientoArmado requerimiento = new RequerimientoArmado(tipoUso, importancia, precio);
            DirectorArmadorComputadora director = new DirectorArmadorComputadora(requerimiento);
            Computadora computadoraArmada = director.ObtenerComputadoraArmada();
            Session["computadoraArmada"] = computadoraArmada;
            Response.Redirect("crear_pedido.aspx");
        }
    }
}