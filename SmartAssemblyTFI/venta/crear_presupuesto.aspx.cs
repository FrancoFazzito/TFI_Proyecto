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
            if (!Page.IsPostBack)
            {
                DropDownList2.DataSource = new List<string>() //cargar tipos de uso con BD y agregar add items para select para que quede como predeterminado
                {
                    "Seleccionar",
                    "Gaming juegos AAA",
                    "Gaming juegos competitivos",
                    "Edicion de video",
                    "Arquitectura",
                    "Oficina"
                };
                DropDownList2.DataBind();

                DropDownList3.DataSource = new List<string>() //cargar importancias con BD y agregar add items para select para que quede como predeterminado
                {
                    "Seleccionar",
                    "Precio de los componentes",
                    "Calidad de los componentes"
                };
                DropDownList3.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var tipoUso = DropDownList2.SelectedValue;
            var importancia = DropDownList3.SelectedValue == "Precio de los componentes" ? "precio" : "calidad";
            var precio = decimal.Parse(TextBox1.Text);
            var requerimiento = new RequerimientoArmado(tipoUso, importancia, precio);
            var director = new DirectorArmadorComputadora(requerimiento);
            var computadoraArmada = director.ObtenerComputadoraArmada();
            Session["computadoraArmada"] = computadoraArmada;
            Response.Redirect("crear_pedido.aspx");
        }
    }
}