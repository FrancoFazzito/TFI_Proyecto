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
        private readonly RepositorioTipoUsoSoloLectura _repositorioEspecificacion;
        // si da error llevar a una pantalla de error que le permita volver a cargar otro presupuesto
        // verificar el login antes de armar el pedido y luego del presupuesto presupuesto -> control login -> pedido

        public DirectorArmadorComputadora(RequerimientoArmado requerimientoArmado)
        {
            _requerimientoArmado = requerimientoArmado;
            _repositorioComponente = new RepositorioComponenteSoloLectura();
            _repositorioEspecificacion = new RepositorioTipoUsoSoloLectura();
        }

        public Computadora Computadora
        {
            get
            {
                var especificacion = _repositorioEspecificacion.ObtenerTodos.FirstOrDefault(c => c.Nombre == _requerimientoArmado.TipoUso);
                var componentes = _repositorioComponente.ObtenerTodos.OrderBy(c => c.Precio);

                var computadoras = from cpu in componentes.Where(c => c.Tipo == "CPU")
                                   let computer = ArmarComputadora(componentes, _requerimientoArmado.Precio, especificacion, cpu)
                                   where computer != null
                                   select computer;

                return (_requerimientoArmado.Importancia == "precio"
                       ? computadoras.OrderBy(c => c.Precio)
                       : computadoras.OrderByDescending(c => c.Perfomance))
                       .FirstOrDefault() ?? throw new ExcepcionRequerimientoInvalido();
            }
        }

        private Computadora ArmarComputadora(IEnumerable<Componente> componentes, decimal precio, TipoUso especificacion, Componente cpuParaIterar)
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
                                         .ArmarComputadora();
            }
            catch (ExcepcionAgregadoInvalido)
            {
                return null;
            }
        }
    }
}