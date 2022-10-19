namespace Dominio
{
    public class CompatibilidadTowerMother : ICompatibilidad
    {
        public bool EsCompatible(Componente tower, Componente mother)
        {
            return GetSize(tower.TipoFormato) >= GetSize(mother.TipoFormato);
        }

        public int GetSize(string format)
        {
            switch (format)
            {
                case "ATX":
                    return 3;

                case "MATX":
                    return 2;

                case "ITX":
                    return 1;

                default:
                    return 4;
            }
        }
    }
}