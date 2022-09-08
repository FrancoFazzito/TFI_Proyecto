namespace Dominio
{
    public class CompatibilidadRamMother : ICompatibilidad
    {
        public bool EsCompatible(Componente ram, Componente mother)
        {
            return ram.TipoMemoria == mother.TipoMemoria && ram.MaximaFrecuencia <= mother.MaximaFrecuencia;
        }
    }
}


