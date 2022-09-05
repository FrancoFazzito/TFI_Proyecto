using System;
using System.Collections.Generic;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = new List<TiposUso>()
            {
                new TiposUso()
                {
                    ID = 1,
                    Nombre = "Arquitectura"
                },
                new TiposUso()
                {
                    ID = 2,
                    Nombre = "Gaming"
                },
                new TiposUso()
                {
                    ID = 3,
                    Nombre = "Edicion de video"
                },
                new TiposUso()
                {
                    ID = 4,
                    Nombre = "Oficina"
                }
            };
            GridView1.DataBind();
        }
    }

    public class TiposUso
    {
        public int ID { get; internal set; }
        public string Nombre { get; internal set; }
    }
}