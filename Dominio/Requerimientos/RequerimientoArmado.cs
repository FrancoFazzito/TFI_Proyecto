namespace Dominio
{
    public class RequerimientoArmado
    {
        public RequerimientoArmado(string tipoUso, string importancia, decimal precio)
        {
            TipoUso = tipoUso;
            Importancia = importancia;
            Precio = precio;
        }

        public string TipoUso { get; set; }
        public string Importancia { get; set; }
        public decimal Precio { get; set; }
    }
}