using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion
{
    public class ArmadorComputadora
    {
        private readonly IEnumerable<Componente> _componentes;
        private readonly decimal _costoDeArmado;
        private readonly Componente _cpuIterado;
        private readonly Especificacion _especificacion;
        private readonly FactoryCompatibilidad _factoryCompatibilidad;
        private readonly decimal _precio;
        private Componente _fanIterado;
        private Componente _motherIterado;
        private ArmadorComputadora(IEnumerable<Componente> componentes, decimal precio, Especificacion especificacion, decimal costoDeArmado, FactoryCompatibilidad factoryCompatibilidad, Componente cpuIterado, Computadora computadoraArmada)
        {
            _componentes = componentes;
            _precio = precio;
            _especificacion = especificacion;
            _costoDeArmado = costoDeArmado;
            _factoryCompatibilidad = factoryCompatibilidad;
            _cpuIterado = cpuIterado;
            ComputadoraArmada = computadoraArmada;
        }

        public Computadora ComputadoraArmada { get; }

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
            if (_cpuIterado.Perfomance < _especificacion.Cpu)
            {
                throw new ExcepcionAgregadoInvalido();
            }

            AgregarComponente(_cpuIterado);
            return this;
        }

        public ArmadorComputadora AgregarFan()
        {
            if (_cpuIterado.NivelFanIntegrado < _especificacion.Fan)
            {
                var compatibilidadFan = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.FanCpu);
                _fanIterado = _componentes.Where(c => c.Tipo == "FAN")
                                          .Where(c => c.EsCompatible(compatibilidadFan, _cpuIterado))
                                          .FirstOrDefault(c => c.Perfomance >= _especificacion.Fan);
                AgregarComponente(_fanIterado);
            }
            return this;
        }

        public ArmadorComputadora AgregarGpu()
        {
            var compatibleVideoIntegrado = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.VideoIntegrado);
            if (_cpuIterado.NivelVideoIntegrado >= _especificacion.Gpu && _cpuIterado.EsCompatible(compatibleVideoIntegrado, _motherIterado))
            {
                return this;
            }

            AgregarComponente(_componentes.Where(c => c.Tipo == "GPU")
                                          .FirstOrDefault(c => c.Perfomance >= _especificacion.Gpu));
            return this;
        }

        public ArmadorComputadora AgregarHdd()
        {
            if (_especificacion.Hdd == 0)
            {
                return this;
            }

            AgregarComponente(_componentes.Where(c => c.Tipo == "HDD")
                                          .FirstOrDefault(c => c.Capacidad >= _especificacion.Ssd));
            return this;
        }

        public ArmadorComputadora AgregarMother()
        {
            var compatibilidadMother = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.MotherCpu);
            _motherIterado = _componentes.Where(c => c.Tipo == "MOTHER")
                                         .Where(c => c.EsCompatible(compatibilidadMother, _cpuIterado))
                                         .FirstOrDefault(c => c.Perfomance >= _especificacion.Mother);
            AgregarComponente(_motherIterado);
            return this;
        }

        public ArmadorComputadora AgregarPsu()
        {
            AgregarComponente(_componentes.Where(c => c.Tipo == "PSU")
                                          .FirstOrDefault(c => c.Capacidad >= ComputadoraArmada.ConsumoTotal));
            return this;
        }

        public ArmadorComputadora AgregarRam()
        {
            var compatibilidadRamCpu = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.RamCpu);
            var compatibilidadRamMother = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.RamMother);
            var cantidadRams = Math.Min(_cpuIterado.Canales, _motherIterado.Canales);
            AgregarComponente(_componentes.Where(c => c.Tipo == "RAM")
                                          .Where(c => c.EsCompatible(compatibilidadRamCpu, _cpuIterado))
                                          .Where(c => c.EsCompatible(compatibilidadRamMother, _motherIterado))
                                          .FirstOrDefault(c => c.Perfomance >= (_especificacion.Ram / cantidadRams)), cantidadRams);
            return this;
        }

        public ArmadorComputadora AgregarSsd()
        {
            if (_especificacion.Ssd == 0)
            {
                return this;
            }

            AgregarComponente(_componentes.Where(c => c.Tipo == "SSD")
                                          .FirstOrDefault(c => c.Capacidad >= _especificacion.Ssd));
            return this;
        }

        public ArmadorComputadora AgregarTower()
        {
            var compatibleTowerMother = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.TowerMother);
            var compatibleTowerFan = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.TowerFan);
            AgregarComponente(_componentes.Where(c => c.Tipo == "TOWER")
                                          .Where(c => c.EsCompatible(compatibleTowerFan, _fanIterado))
                                          .FirstOrDefault(c => c.EsCompatible(compatibleTowerMother, _motherIterado)));
            return this;
        }

        private void AgregarComponente(Componente componente, int cantidad = 1)
        {
            if (EsAgregadoInvalido(componente, cantidad))
            {
                throw new ExcepcionAgregadoInvalido();
            }
            ComputadoraArmada.Add(componente, cantidad);
        }

        private bool EsAgregadoInvalido(Componente componente, int cantidad) => componente == null || EsPresupuestoInvalido(componente) || EsStockInvalido(componente, cantidad);

        private bool EsPresupuestoInvalido(Componente componente) => (ComputadoraArmada.Precio + componente.Precio + _costoDeArmado) >= _precio;

        private bool EsStockInvalido(Componente componente, int cantidad) => componente.Stock < cantidad;
    }
}