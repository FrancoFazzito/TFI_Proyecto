namespace Dominio
{
    public class TipoUso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Mother => Cpu - 10;
        public int Cpu { get; set; }
        public int Fan => Cpu - 10;
        public int Ram { get; set; }
        public int Gpu { get; set; }
        public int Hdd { get; set; }
        public int Ssd { get; set; }
    }
}