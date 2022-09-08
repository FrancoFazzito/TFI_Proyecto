using System.Configuration;

namespace Dominio
{
    public class CompatibilidadRamCpu : ICompatibilidad
    {
        public bool EsCompatible(Componente ram, Componente cpu)
        {
            var compatible = ram.TipoMemoria == cpu.TipoMemoria && ram.MaximaFrecuencia <= cpu.MaximaFrecuencia;
            var highFrecuency = cpu.MaximaFrecuencia >= int.Parse(ConfigurationManager.AppSettings["altaFrecuencia"]);
            return cpu.NecesitaAltaFrecuencia ? highFrecuency && compatible : compatible;
        }
    }
}


