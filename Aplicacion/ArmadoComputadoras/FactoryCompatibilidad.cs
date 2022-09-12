using Dominio;
using System.Collections.Generic;

namespace Aplicacion
{
    public class FactoryCompatibilidad
    {
        private readonly Dictionary<Compatibilidades, ICompatibilidad> CompatibilidadNombre = new Dictionary<Compatibilidades, ICompatibilidad>()
        {
            { Compatibilidades.FanCpu, new CompatibilidadFanCpu() },
            { Compatibilidades.MotherCpu, new CompatibilidadMotherCpu() },
            { Compatibilidades.RamCpu, new CompatibilidadRamCpu() },
            { Compatibilidades.RamMother, new CompatibilidadRamMother() },
            { Compatibilidades.TowerFan, new CompatibilidadTowerFan() },
            { Compatibilidades.TowerMother, new CompatibilidadTowerMother() },
            { Compatibilidades.VideoIntegrado, new CompatibilidadVideoIntegrado() },
        };

        public ICompatibilidad GetCompatibilidadPorNombre(Compatibilidades compatibilidades)
        {
            return CompatibilidadNombre[compatibilidades];
        }
    }
}