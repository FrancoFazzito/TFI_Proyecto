namespace Dominio
{
    public class CompatibilidadVideoIntegrado : ICompatibilidad
    {
        public bool EsCompatible(Componente componente, Componente componenteParaComparar)
        {
            return componente.TieneVideoIntegrado && componenteParaComparar.TieneVideoIntegrado;
        }
    }
}