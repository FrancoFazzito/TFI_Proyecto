namespace Dominio
{
    public class CompatibilidadMotherCpu : ICompatibilidad
    {
        public bool EsCompatible(Componente mother, Componente cpu) => mother.Socket == cpu.Socket && mother.TipoMemoria == cpu.TipoMemoria;
    }
}