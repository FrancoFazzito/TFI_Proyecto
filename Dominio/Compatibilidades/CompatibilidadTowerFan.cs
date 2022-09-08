namespace Dominio
{
    public class CompatibilidadTowerFan : ICompatibilidad
    {
        public bool EsCompatible(Componente tower, Componente fan) => fan == null || tower.TamanoFan >= fan.TamanoFan;
    }
}