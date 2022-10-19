namespace Dominio
{
    public class CompatibilidadTowerFan : ICompatibilidad
    {
        public bool EsCompatible(Componente tower, Componente fan)
        {
            return fan == null || tower.TamanoFan >= fan.TamanoFan;
        }
    }
}