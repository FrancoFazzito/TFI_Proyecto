using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Web.UI;

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
            try
            {
                string tipoUso = DropDownList2.SelectedValue;
                string importancia = DropDownList3.SelectedValue == "Precio de los componentes" ? "precio" : "calidad";
                decimal precio = decimal.Parse(TextBox1.Text);
                RequerimientoArmado requerimiento = new RequerimientoArmado(tipoUso, importancia, precio);
                DirectorArmadorComputadora director = new DirectorArmadorComputadora(requerimiento);
                Computadora computadoraArmada = director.Computadora;
                Session["computadoraArmada"] = computadoraArmada;
                Response.Redirect("crear_pedido.aspx");
            }
            catch (ExcepcionRequerimientoInvalido)
            {
            }
        }
    }
}