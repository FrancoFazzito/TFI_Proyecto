namespace Dominio
{
    public class Especificacion
    {
        public string Id { get; set; }
        public string TipoUso { get; set; }
        public int Mother => Cpu - 10;
        public int Cpu { get; set; }
        public int Fan => Cpu - 10;
        public int Ram { get; set; }
        public int Gpu { get; set; }
        public int Hdd { get; set; }
        public int Ssd { get; set; }
        public int Tower => (Fan + Cpu + Gpu) / 3;
        public int Psu => ((Cpu + Gpu) / 2) - 20;
    }
}