using System;
using System.Collections.Generic;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList2.DataSource = new List<string>()
            {
                "Seleccionar",
                "Gaming",
                "Edicion de video",
                "Arquitectura"
            };
            DropDownList2.DataBind();

            DropDownList3.DataSource = new List<string>()
            {
                "Seleccionar",
                "Precio de los componentes",
                "Calidad de los componentes"
            };
            DropDownList3.DataBind();
        }
    }
}