using System.Linq;

namespace Dominio
{
    public class CompatibilidadFanCpu : ICompatibilidad
    {
        public bool EsCompatible(Componente fan, Componente cpu)
        {
            return fan.Socket.Split('-').Contains(cpu.Socket);
        }
    }
}