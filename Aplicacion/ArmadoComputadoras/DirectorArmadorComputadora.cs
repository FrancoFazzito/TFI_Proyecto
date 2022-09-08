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
        private readonly RepositorioComponenteSoloLectura _repositorioComponente;
        private readonly RepositorioEspecificacionSoloLectura _repositorioEspecificacion;
        //add precio to pantalla de presentacion de computadora
        // si da error llevar a una pantalla de error que le permita volver a cargar otro presupuesto
        // verificar el login antes de armar el pedido y luego del presupuesto presupuesto -> control login -> pedido

        public DirectorArmadorComputadora(RequerimientoArmado requerimientoArmado)
        {
            _requerimientoArmado = requerimientoArmado;
            _repositorioComponente = new RepositorioComponenteSoloLectura();
            _repositorioEspecificacion = new RepositorioEspecificacionSoloLectura();
        }

        public Computadora ObtenerComputadoraArmada()
        {
            Especificacion especificacion = _repositorioEspecificacion.ObtenerTodos.FirstOrDefault(c => c.TipoUso == _requerimientoArmado.TipoUso);
            IEnumerable<Componente> componentes = GetComponentesOrdenadosPorImportancia(_requerimientoArmado.Importancia);
            IEnumerable<Computadora> computadoras = ObtenerComputadoras(componentes, _requerimientoArmado, especificacion);
            Computadora computadora = computadoras.OrderByDescending(c => c.PrecioPerfomance).FirstOrDefault();
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
