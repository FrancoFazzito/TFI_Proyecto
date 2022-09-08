namespace Dominio
{
    public class CompatibilidadVideoIntegrado : ICompatibilidad
    {
        public bool EsCompatible(Componente componente, Componente componenteParaComparar) => componente.TieneVideoIntegrado && componenteParaComparar.TieneVideoIntegrado;
    }
}