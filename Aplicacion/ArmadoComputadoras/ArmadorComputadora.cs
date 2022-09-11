using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion
{
    public class ArmadorComputadora
    {
        private readonly IEnumerable<Componente> _componentes;
        private readonly decimal _costoArmado;
        private readonly decimal _precio;
        private readonly FactoryCompatibilidad _factoryCompatibilidad;
        private readonly TipoUso _tipoUso;
        private readonly Computadora _computadora;
        private readonly Componente _cpu;
        private Componente _fan;
        private Componente _mother;
        private Componente _gpu;
        private Componente _hdd;
        private Componente _psu;
        private Componente _tower;
        private Componente _ssd;
        private Componente _ram;

        private ArmadorComputadora(IEnumerable<Componente> componentes, decimal precio, TipoUso especificacion, decimal costoArmado, FactoryCompatibilidad factoryCompatibilidad, Componente cpu, Computadora computadoraArmada)
        {
            _componentes = componentes;
            _precio = precio;
            _tipoUso = especificacion;
            _costoArmado = costoArmado;
            _factoryCompatibilidad = factoryCompatibilidad;
            _cpu = cpu;
            _computadora = computadoraArmada;
        }

        public static ArmadorComputadora Inicializar(IEnumerable<Componente> componentes, decimal precio, TipoUso especificacion, decimal costoArmado, FactoryCompatibilidad factoryCompatibilidad, Componente cpu)
        {
            return new ArmadorComputadora(componentes, precio, especificacion, costoArmado, factoryCompatibilidad, cpu, new Computadora()
            {
                CostoArmado = costoArmado,
                TipoUso = especificacion.Nombre
            });
        }

        public ArmadorComputadora AgregarCpu()
        {
            if (_cpu.Perfomance < _tipoUso.Cpu)
            {
                throw new ExcepcionAgregadoInvalido();
            }

            AgregarComponente(_cpu);
            return this;
        }

        public ArmadorComputadora AgregarFan()
        {
            if (_cpu.NivelFanIntegrado < _tipoUso.Fan)
            {
                var compatibilidadFan = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.FanCpu);
                _fan = _componentes.Where(c => c.Tipo == "FAN")
                                   .Where(c => c.EsCompatible(compatibilidadFan, _cpu))
                                   .FirstOrDefault(c => c.Perfomance >= _tipoUso.Fan);
                AgregarComponente(_fan);
            }
            return this;
        }

        public ArmadorComputadora AgregarGpu()
        {
            var compatibleVideoIntegrado = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.VideoIntegrado);
            if (_cpu.NivelVideoIntegrado >= _tipoUso.Gpu && _cpu.EsCompatible(compatibleVideoIntegrado, _mother))
            {
                return this;
            }

            _gpu = _componentes.Where(c => c.Tipo == "GPU")
                               .FirstOrDefault(c => c.Perfomance >= _tipoUso.Gpu);
            AgregarComponente(_gpu);
            return this;
        }

        public ArmadorComputadora AgregarHdd()
        {
            if (_tipoUso.Hdd == 0)
            {
                return this;
            }

            _hdd = _componentes.Where(c => c.Tipo == "HDD")
                               .FirstOrDefault(c => c.Capacidad >= _tipoUso.Ssd);
            AgregarComponente(_hdd);
            return this;
        }

        public ArmadorComputadora AgregarMother()
        {
            var compatibilidadMother = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.MotherCpu);
            _mother = _componentes.Where(c => c.Tipo == "MOTHER")
                                  .Where(c => c.EsCompatible(compatibilidadMother, _cpu))
                                  .FirstOrDefault(c => c.Perfomance >= _tipoUso.Mother);
            AgregarComponente(_mother);
            return this;
        }

        public ArmadorComputadora AgregarPsu()
        {
            _psu = _componentes.Where(c => c.Tipo == "PSU")
                               .FirstOrDefault(c => c.Capacidad >= _computadora.ConsumoTotal);
            AgregarComponente(_psu);
            return this;
        }

        public ArmadorComputadora AgregarRam()
        {
            var compatibilidadRamCpu = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.RamCpu);
            var compatibilidadRamMother = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.RamMother);
            var cantidadRams = Math.Min(_cpu.Canales, _mother.Canales);
            _ram = _componentes.Where(c => c.Tipo == "RAM")
                               .Where(c => c.EsCompatible(compatibilidadRamCpu, _cpu))
                               .Where(c => c.EsCompatible(compatibilidadRamMother, _mother))
                               .FirstOrDefault(c => c.Capacidad >= (_tipoUso.Ram / cantidadRams));
            AgregarComponente(_ram, cantidadRams);
            return this;
        }

        public ArmadorComputadora AgregarSsd()
        {
            if (_tipoUso.Ssd == 0)
            {
                return this;
            }

            _ssd = _componentes.Where(c => c.Tipo == "SSD")
                               .FirstOrDefault(c => c.Capacidad >= _tipoUso.Ssd);
            AgregarComponente(_ssd);
            return this;
        }

        public ArmadorComputadora AgregarTower()
        {
            var compatibleTowerMother = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.TowerMother);
            var compatibleTowerFan = _factoryCompatibilidad.GetCompatibilidadPorNombre(Compatibilidades.TowerFan);
            _tower = _componentes.Where(c => c.Tipo == "TOWER")
                                 .Where(c => c.EsCompatible(compatibleTowerFan, _fan))
                                 .FirstOrDefault(c => c.EsCompatible(compatibleTowerMother, _mother));
            AgregarComponente(_tower);
            return this;
        }

        private void AgregarComponente(Componente componente, int cantidad = 1)
        {
            if (EsAgregadoInvalido(componente, cantidad))
            {
                throw new ExcepcionAgregadoInvalido();
            }
            _computadora.Add(componente, cantidad);
        }

        private bool EsAgregadoInvalido(Componente componente, int cantidad) => componente == null || EsPresupuestoInvalido(componente) || EsStockInvalido(componente, cantidad);

        private bool EsPresupuestoInvalido(Componente componente) => (_computadora.Precio + componente.Precio + _costoArmado) >= _precio;

        private bool EsStockInvalido(Componente componente, int cantidad) => componente.Stock < cantidad;

        public Computadora ArmarComputadora() => _computadora;
    }
}