using System;

namespace SmartAssemblyTFI
{
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string CpuNombre => "Ryzen 7 5600X";
        public string GpuNombre => "RXT 3060";
        public string RamNombre => "16 GB";
        public string SsdNombre => "250 GB";
        public string HddNombre => "1 TB";
    }
}