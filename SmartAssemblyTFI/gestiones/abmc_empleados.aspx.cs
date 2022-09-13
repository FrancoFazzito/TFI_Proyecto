using System;
using System.Collections.Generic;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web17 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = new List<EmpleadoVista>()
            {
                new EmpleadoVista()
                {
                    ID = 1,
                    Usuario = "Franco Fazzito"
                },
                new EmpleadoVista()
                {
                    ID = 2,
                    Usuario = "Franco Balich"
                },
                new EmpleadoVista()
                {
                    ID = 3,
                    Usuario = "Ian Buceta"
                },
                new EmpleadoVista()
                {
                    ID = 4,
                    Usuario = "Lucas Gino"
                }
            };
            GridView1.DataBind();
        }
    }

    public class EmpleadoVista
    {
        public int ID { get; internal set; }
        public string Usuario { get; internal set; }
    }
}