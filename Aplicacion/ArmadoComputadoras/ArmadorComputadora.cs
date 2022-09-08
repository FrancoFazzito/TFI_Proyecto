using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion
{
    public class ArmadorComputadora
    {
        private readonly IEnumerable<Componente> _componentes;
        private readonly decimal _precio;
        private readonly Especificacion _especificacion;
        private readonly decimal _costoDeArmado;
        private readonly FactoryCompatibilidad _factoryCompatibilidad;
        private readonly Computadora _computadoraArmada;
        private readonly Componente _cpuIterado;
        private Componente _motherIterado;
        private Componente _fanIterado;

        private ArmadorComputadora(IEnumerable<Componente> componentes, decimal precio, Especificacion especificacion, decimal costoDeArmado, FactoryCompatibilidad factoryCompatibilidad, Componente cpuIterado, Computadora computadoraArmada)
        {
            _componentes = componentes;
            _precio = precio;
            _especificacion = especificacion;
            _costoDeArmado = costoDeArmado;
            _factoryCompatibilidad = factoryCompatibilidad;
            _computadoraArmada = computadoraArmada;
            _cpuIterado = cpuIterado;
        }

        public static ArmadorComputadora Inicializar(IEnumerable<Componente> componentes, decimal precio, Especificacion especificacion, decimal costoDeArmado, FactoryCompatibilidad factoryCompatibilidad, Componente cpuRoot)
        {
            return new ArmadorComputadora(componentes, precio, especificacion, costoDeArmado, factoryCompatibilidad, cpuRoot, new Computadora()
            {
                CostoArmado = costoDeArmado,
                TipoUso = especificacion.TipoUso
            });
        }

        public ArmadorComputadora AgregarCpu()
        {
            if (_cpuIterado.Perfomance >= _especificacion.Cpu)
            {
                AgregarComponente(_cpuIterado);
                return this;
            }
            throw new ExcepcionAgregadoInvalido();
        }

        public ArmadorComputadora AgregarMother()
        {
            var compatibilidadMother = _factoryCompatibilidad.GetCompatibilidadPorNombre("Mother");
            _motherIterado = _componentes.Where(c => c.Tipo == "MOTHER")
                                      .Where(c => c.EsCompatible(compatibilidadMother, _cpuIterado))
                                      .Where(c => c.Perfomance >= _especificacion.Mother)
                                      .FirstOrDefault();
            AgregarComponente(_motherIterado);
            return this;
        }

        public ArmadorComputadora AgregarRam()
        {
            var compatibilidadRam = _factoryCompatibilidad.GetCompatibilidadPorNombre("Ram");
            var cantidadRams = Math.Min(_cpuIterado.Canales, _motherIterado.Canales);
            var gbNecesarios = _especificacion.Ram;
            var ram = _componentes.Where(c => c.Tipo == "RAM")
                                  .Where(c => c.EsCompatible(compatibilidadRam, _cpuIterado))
                                  .Where(c => c.Perfomance >= (gbNecesarios / cantidadRams))
                                  .FirstOrDefault();
            AgregarComponente(ram, cantidadRams);
            return this;
        }

        public ArmadorComputadora AgregarFan()
        {
            if (_cpuIterado.NivelFanIntegrado >= _especificacion.Fan)
            {
                var compatibilidadFan = _factoryCompatibilidad.GetCompatibilidadPorNombre("Fan");
                _fanIterado = _componentes.Where(c => c.Tipo == "FAN")
                                      .Where(c => c.EsCompatible(compatibilidadFan, _cpuIterado))
                                      .Where(c => c.Perfomance >= _especificacion.Fan)
                                      .FirstOrDefault();
                AgregarComponente(_fanIterado);
            }
            return this;
        }

        public ArmadorComputadora AgregarGpu()
        {
            var compatibleVideoIntegrado = _factoryCompatibilidad.GetCompatibilidadPorNombre("videoIntegrado");
            if (_cpuIterado.NivelVideoIntegrado >= _especificacion.Gpu && _cpuIterado.EsCompatible(compatibleVideoIntegrado, _motherIterado))
            {
                return this;
            }
            var gpu = _componentes.Where(c => c.Tipo == "GPU")
                                  .Where(c => c.Perfomance >= _especificacion.Gpu)
                                  .FirstOrDefault();
            AgregarComponente(gpu);
            return this;
        }

        public ArmadorComputadora AgregarHdd()
        {
            if (_especificacion.Hdd == 0)
            {
                return this;
            }
            var hdd = _componentes.Where(c => c.Tipo == "HDD")
                                  .Where(c => c.Capacidad >= _especificacion.Hdd)
                                  .FirstOrDefault();
            AgregarComponente(hdd);
            return this;
        }

        public ArmadorComputadora AgregarSsd()
        {
            if (_especificacion.Ssd == 0)
            {
                return this;
            }
            var ssd = _componentes.Where(c => c.Tipo == "SSD")
                                  .Where(c => c.Capacidad >= _especificacion.Ssd)
                                  .FirstOrDefault();
            AgregarComponente(ssd);
            return this;
        }

        public ArmadorComputadora AgregarTower()
        {
            var compatibleTowerMother = _factoryCompatibilidad.GetCompatibilidadPorNombre("TowerMother");
            var compatibleTowerFan = _factoryCompatibilidad.GetCompatibilidadPorNombre("TowerFan");
            var tower = _componentes.Where(c => c.Tipo == "TOWER")
                                    .Where(c => c.EsCompatible(compatibleTowerFan, _fanIterado) || _fanIterado == null)
                                    .Where(c => c.EsCompatible(compatibleTowerMother, _motherIterado))
                                    .Where(c => c.Perfomance >= _especificacion.Tower)
                                    .FirstOrDefault();
            AgregarComponente(tower);
            return this;
        }

        public ArmadorComputadora AgregarPsu()
        {
            var psu = _componentes.Where(c => c.Tipo == "PSU")
                                  .Where(c => c.Perfomance >= _especificacion.Psu)
                                  .Where(c => c.Capacidad >= _computadoraArmada.ConsumoTotal)
                                  .FirstOrDefault();
            AgregarComponente(psu);
            return this;
        }

        public Computadora ObtenerComputadoraArmada() => _computadoraArmada;

        private void AgregarComponente(Componente componente, int cantidad = 1)
        {
            if (!EsAgregadoValido(componente, cantidad))
            {
                throw new ExcepcionAgregadoInvalido();
            }
            _computadoraArmada.Add(componente, cantidad);
        }

        private bool EsAgregadoValido(Componente componente, int cantidad) => !EsPresupuestoValido(componente) || !EsComponenteValido(componente) || !EsStockValido(componente, cantidad);

        private bool EsPresupuestoValido(Componente componente)
        {
            var costoTotal = _computadoraArmada.Precio + componente.Precio + _costoDeArmado;
            return costoTotal >= _precio;
        }

        private bool EsComponenteValido(Componente componente) => componente == null;

        private bool EsStockValido(Componente componente, int cantidad) => componente.Stock >= cantidad;
    }
}