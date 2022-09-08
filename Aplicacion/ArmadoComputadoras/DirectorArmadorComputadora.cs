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
            var especificacion = _repositorioEspecificacion.ObtenerTodos.FirstOrDefault(c => c.TipoUso == _requerimientoArmado.TipoUso);
            var componentes = GetComponentesOrdenadosPorImportancia(_requerimientoArmado.Importancia);
            var computadoras = ObtenerComputadoras(componentes, _requerimientoArmado.Precio, especificacion);
            return computadoras.OrderByDescending(c => c.PrecioPerfomance).FirstOrDefault() ?? throw new ExcepcionRequerimientoInvalido();
        }

        private IEnumerable<Componente> GetComponentesOrdenadosPorImportancia(string importancia)
        {
            return importancia == "precio"
                ? _repositorioComponente.ObtenerTodos.OrderBy(c => c.Precio)
                : _repositorioComponente.ObtenerTodos.OrderByDescending(c => c.Perfomance);
        }

        private IEnumerable<Computadora> ObtenerComputadoras(IEnumerable<Componente> componentes, decimal precio, Especificacion especificacion)
        {
            return from cpu in componentes.Where(c => c.Tipo == "CPU")
                   let computer = ArmarComputadora(componentes, precio, especificacion, cpu)
                   where computer != null
                   select computer;
        }

        private Computadora ArmarComputadora(IEnumerable<Componente> componentes, decimal precio, Especificacion especificacion, Componente cpuParaIterar)
        {
            try
            {
                return ArmadorComputadora.Inicializar(componentes, 
                                                      precio, 
                                                      especificacion, 
                                                      _costoArmado, 
                                                      _factoryCompatibilidad, 
                                                      cpuParaIterar)
                                         .AgregarCpu()
                                         .AgregarMother()
                                         .AgregarRam()
                                         .AgregarFan()
                                         .AgregarGpu()
                                         .AgregarHdd()
                                         .AgregarSsd()
                                         .AgregarTower()
                                         .AgregarPsu()
                                         .ComputadoraArmada;
            }
            catch (ExcepcionAgregadoInvalido)
            {
                return null;
            }
        }
    }
}
