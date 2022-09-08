using Dominio;
using Repositorio;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Aplicacion
{
    public class DirectorArmadorComputadora
    {
        private readonly decimal _costoArmado = decimal.Parse(ConfigurationManager.AppSettings["costoArmado"]);
        private readonly FactoryCompatibilidad _factoryCompatibilidad = new FactoryCompatibilidad();
        private readonly RequerimientoArmado _requerimientoArmado;
        private readonly ComponenteRepositorioSoloLectura _repositorioComponente;
        private readonly EspecificacionRepositorioSoloLectura _repositorioEspecificacion;
        //add precio to pantalla de presentacion de computadora
        public DirectorArmadorComputadora(RequerimientoArmado requerimientoArmado)
        {
            _requerimientoArmado = requerimientoArmado;
        }

        public Computadora ObtenerComputadoraArmada()
        {
            Especificacion especificacion = _repositorioEspecificacion.ObtenerTodos.FirstOrDefault(c => c.TipoUso == _requerimientoArmado.TipoUso);
            IEnumerable<Componente> componentes = GetComponentesOrdenadosPorImportancia(_requerimientoArmado.Importancia);
            IEnumerable<Computadora> computadoras = ObtenerComputadoras(componentes, _requerimientoArmado, especificacion);
            Computadora computadora = computadoras.OrderByDescending(c => c.PricePerfomance).FirstOrDefault();
            return computadora == null ? computadora : throw new ExcepcionRequerimientoInvalido();
        }

        private IEnumerable<Componente> GetComponentesOrdenadosPorImportancia(string importancia)
        {
            return importancia == "precio"
                ? _repositorioComponente.ObtenerTodos.OrderBy(c => c.Precio)
                : _repositorioComponente.ObtenerTodos.OrderByDescending(c => c.Perfomance);
        }

        private IEnumerable<Computadora> ObtenerComputadoras(IEnumerable<Componente> componentes, RequerimientoArmado requerimiento, Especificacion especificacion)
        {
            return from cpu in componentes.Where(c => c.Tipo == "CPU")
                   let computer = ArmarComputadora(componentes, requerimiento, especificacion, cpu)
                   where computer != null
                   select computer;
        }

        private Computadora ArmarComputadora(IEnumerable<Componente> componentes, RequerimientoArmado requerimiento, Especificacion especificacion, Componente cpuIterado)
        {
            try
            {
                return ArmadorComputadora.Inicializar(componentes, requerimiento.Precio, especificacion, _costoArmado, _factoryCompatibilidad, cpuIterado)
                                         .AgregarCpu()
                                         .AgregarMother()
                                         .AgregarRam()
                                         .AgregarFan()
                                         .AgregarGpu()
                                         .AgregarHdd()
                                         .AgregarSsd()
                                         .AgregarTower()
                                         .AgregarPsu()
                                         .ObtenerComputadoraArmada();
            }
            catch (ExcepcionAgregadoInvalido)
            {
                return null;
            }
        }
    }
}
