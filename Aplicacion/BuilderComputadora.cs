using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class BuilderComputadora
    {
        private readonly IEnumerable<Componente> _componentes;
        private readonly RequerimientoArmado _requerimientoArmado;
        private readonly decimal _costoDeArmado;
        private readonly FactoryCompatibilidad _factoryCompatibilidad;
        private readonly Computadora _computadoraArmada;
        private readonly Componente _cpuIterado;
        private Componente _MotherIterado;
        private Componente _fanIterado;

        private BuilderComputadora(IEnumerable<Componente> componentes, RequerimientoArmado requerimientoArmado, decimal costoDeArmado, FactoryCompatibilidad factoryCompatibilidad, Componente cpuIterado, Computadora computadoraArmada)
        {
            _componentes = componentes;
            _requerimientoArmado = requerimientoArmado;
            _costoDeArmado = costoDeArmado;
            _factoryCompatibilidad = factoryCompatibilidad;
            _computadoraArmada = computadoraArmada;
            _cpuIterado = cpuIterado;
        }

        public static BuilderComputadora Inicializar(IEnumerable<Componente> componentes, RequerimientoArmado requerimientoArmado, decimal costoDeArmado, FactoryCompatibilidad factoryCompatibilidad, Componente cpuRoot)
        {
            return new BuilderComputadora(componentes, requerimientoArmado, costoDeArmado, factoryCompatibilidad, cpuRoot, new Computadora()
            {
                CostoArmado = costoDeArmado,
                TipoUso = requerimientoArmado.TipoUso
            });
        }

        public BuilderComputadora AgregarCpu()
        {
            
            if (_cpuIterado.Perfomance >= _requerimientoArmado.Especificacion.Cpu)
            {
                AgregarComponente(_cpuIterado);
                return this;
            }
            throw new ExcepcionAgregadoInvalido();
        }

        public BuilderComputadora AgregarMother()
        {
            var compatibilidadMother = _factoryCompatibilidad.GetCompatibilidadPorNombre("Mother");
            
            _MotherIterado = _componentes.Where(c => c.Tipo == "Mother")
                                      .Where(c => c.EsCompatible(compatibilidadMother, _cpuIterado))
                                      .Where(c => c.Perfomance >= _requerimientoArmado.Especificacion.Mother)
                                      .FirstOrDefault();
            AgregarComponente(_MotherIterado);
            return this;
        }

        public BuilderComputadora AgregarRam()
        {
            var compatibilidadRam = _factoryCompatibilidad.GetCompatibilidadPorNombre("Ram");
            
            var cantidadRams = Math.Min(_cpuIterado.Canales, _MotherIterado.Canales);
            var gbNecesarios = _requerimientoArmado.Especificacion.Ram;
            var ram = _componentes.Where(c => c.Tipo == "Ram")
                                  .Where(c => c.EsCompatible(compatibilidadRam, _cpuIterado))
                                  .Where(c => c.Perfomance >= (gbNecesarios / cantidadRams))
                                  .FirstOrDefault();
            AgregarComponente(ram, cantidadRams);
            return this;
        }

        public BuilderComputadora AgregarFan()
        {
            if (_cpuIterado.NivelFanIntegrado >= _requerimientoArmado.Especificacion.Fan)
            {
                var compatibilidadFan = _factoryCompatibilidad.GetCompatibilidadPorNombre("Fan");

                _fanIterado = _componentes.Where(c => c.Tipo == "Fan")
                                      .Where(c => c.EsCompatible(compatibilidadFan, _cpuIterado))
                                      .Where(c => c.Perfomance >= _requerimientoArmado.Especificacion.Fan)
                                      .FirstOrDefault();
                AgregarComponente(_fanIterado);
            }
            return this;
        }

        public BuilderComputadora AgregarGpu()
        {
            
            var compatibleVideoIntegrado = _factoryCompatibilidad.GetCompatibilidadPorNombre("videoIntegrado");
            if (_cpuIterado.NivelVideoIntegrado >= _requerimientoArmado.Especificacion.Gpu && _cpuIterado.EsCompatible(compatibleVideoIntegrado, _MotherIterado))
            {
                return this;
            }
            
           
            var gpu = _componentes.Where(c => c.Tipo == "Gpu")
                                  .Where(c => c.Perfomance >= _requerimientoArmado.Especificacion.Gpu)
                                  .FirstOrDefault();
            AgregarComponente(gpu);
            return this;
        }

        public BuilderComputadora AgregarHdd()
        {
            if (_requerimientoArmado.Especificacion.Hdd == 0)
            {
                return this;
            }
            
            var hdd = _componentes.Where(c => c.Tipo == "Hdd")
                                  .Where(c => c.Capacidad >= _requerimientoArmado.Especificacion.Hdd)
                                  .FirstOrDefault();
            AgregarComponente(hdd);
            return this;
        }

        public BuilderComputadora AgregarSsd()
        {
            if (_requerimientoArmado.Especificacion.Ssd == 0)
            {
                return this;
            }
            
            var ssd = _componentes.Where(c => c.Tipo == "Ssd")
                                  .Where(c => c.Capacidad >= _requerimientoArmado.Especificacion.Ssd)
                                  .FirstOrDefault();
            AgregarComponente(ssd);
            return this;
        }

        public BuilderComputadora AgregarTower()
        {
            var compatibleTowerMother = _factoryCompatibilidad.GetCompatibilidadPorNombre("TowerMother");
            var compatibleTowerFan = _factoryCompatibilidad.GetCompatibilidadPorNombre("TowerFan");
            var tower = _componentes.Where(c => c.Tipo == "Tower")
                                    .Where(c => c.EsCompatible(compatibleTowerFan, _fanIterado) || _fanIterado == null)
                                    .Where(c => c.EsCompatible(compatibleTowerMother, _MotherIterado))
                                    .FirstOrDefault();
            AgregarComponente(tower);
            return this;
        }

        public BuilderComputadora AgregarPsu()
        {
            var psu = _componentes.Where(c => c.Tipo == "Psu")
                                  .Where(c => c.Capacidad >= _computadoraArmada.ConsumoTotal)
                                  .FirstOrDefault();
            AgregarComponente(psu);
            return this;
        }

        public Computadora Build()
        {
            return _computadoraArmada;
        }

        private void AgregarComponente(Componente componente, int cantidad = 1)
        {
            if (!EsAgregadoValido(componente, cantidad))
            {
                throw new ExcepcionAgregadoInvalido();
            }

            _computadoraArmada.Add(componente, cantidad);
        }

        private bool EsAgregadoValido(Componente componente, int cantidad)
        {
            return !EsPresupuestoValido(componente) || !EsComponenteValido(componente) || !EsStockValido(componente, cantidad); 
        }

        private bool EsPresupuestoValido(Componente componente)
        {
            var costoTotal = _computadoraArmada.Price + componente.Precio + _costoDeArmado;
            return costoTotal >= _requerimientoArmado.Precio;
        }

        private bool EsComponenteValido(Componente componente)
        {
            return componente == null;
        }

        private bool EsStockValido(Componente componente, int cantidad)
        {
            return componente.Stock >= cantidad;
        } 
    }
}
