using System;
using System.Collections.Generic;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web17 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = new List<Empleado>()
            {
                new Empleado()
                {
                    ID = 1,
                    Usuario = "Franco Fazzito"
                },
                new Empleado()
                {
                    ID = 2,
                    Usuario = "Franco Balich"
                },
                new Empleado()
                {
                    ID = 3,
                    Usuario = "Ian Buceta"
                },
                new Empleado()
                {
                    ID = 4,
                    Usuario = "Lucas Gino"
                }
            };
            GridView1.DataBind();
        }
    }

    public class Empleado
    {
        public int ID { get; internal set; }
        public string Usuario { get; internal set; }
    }
}