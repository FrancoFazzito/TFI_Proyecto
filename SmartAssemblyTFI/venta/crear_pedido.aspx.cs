using Aplicacion;
using Aplicacion.Pedidos;
using Dominio;
using System;
using System.Linq;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        private Computadora computadora;

        protected void Page_Load(object sender, EventArgs e) => computadora = (Computadora)Session["computadoraArmada"];

        protected void Button1_Click(object sender, EventArgs e)
        {
            var clienteLogueado = SesionCliente.Logueado;
            if (clienteLogueado == null)
            {
                Session["vieneDeCrearPedido"] = true;
                Response.Redirect("../login/cliente_login.aspx");
            }
            new GestorPedido().Subir(computadora, clienteLogueado);
            //creaste tu pedido con exito con numero label!
        }

        public string NombreCpu => computadora.Componentes.First(c => c.Tipo == "CPU").Nombre;

        public string NombreMother => computadora.Componentes.First(c => c.Tipo == "MOTHER").Nombre;

        public string NombreGpu => computadora.Componentes.FirstOrDefault(c => c.Tipo == "GPU") == null ? "Grafica integrada" : computadora.Componentes.FirstOrDefault(c => c.Tipo == "GPU").Nombre;

        public string NombreSsd => computadora.Componentes.FirstOrDefault(c => c.Tipo == "SSD") == null ? "No posee" : computadora.Componentes.FirstOrDefault(c => c.Tipo == "SSD").Nombre;

        public string NombreHdd => computadora.Componentes.FirstOrDefault(c => c.Tipo == "HDD") == null ? "No posee" : computadora.Componentes.FirstOrDefault(c => c.Tipo == "HDD").Nombre;

        public string NombreRam => $"{computadora.Componentes.FirstOrDefault(c => c.Tipo == "RAM").Nombre} x{computadora.Componentes.Count(c => c.Tipo == "RAM")}";

        public string Precio => $"${computadora.Precio}";
    }
}