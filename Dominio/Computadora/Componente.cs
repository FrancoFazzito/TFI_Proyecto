namespace Dominio
{
    public class Componente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Perfomance { get; set; }
        public string Tipo { get; set; }
        public int ConsumoEnWatts { get; set; }
        public string Socket { get; set; }
        public bool TieneVideoIntegrado { get; set; }
        public int Canales { get; set; }
        public int NivelVideoIntegrado { get; set; }
        public int NivelFanIntegrado { get; set; }
        public bool NecesitaAltaFrecuencia { get; set; }
        public int Capacidad { get; set; }
        public int TamanoFan { get; set; }
        public string TipoFormato { get; set; }
        public string TipoMemoria { get; set; }
        public int MaximaFrecuencia { get; set; }
        public int Stock { get; set; }
        public int StockLimite { get; set; }

        public bool EsCompatible(ICompatibilidad compatibilidad, Componente componente) => compatibilidad.EsCompatible(this, componente);
    }
}


