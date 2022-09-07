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
        private readonly FactorySuficiente _factorySuficiente;
        private readonly Computadora _computadoraArmada;

        private BuilderComputadora(IEnumerable<Componente> componentes, RequerimientoArmado requerimientoArmado, decimal costoDeArmado, FactoryCompatibilidad factoryCompatibilidad, FactorySuficiente factorySuficiente, Componente cpuIterado, Computadora computadoraArmada)
        {
            _componentes = componentes;
            _requerimientoArmado = requerimientoArmado;
            _costoDeArmado = costoDeArmado;
            _factoryCompatibilidad = factoryCompatibilidad;
            _factorySuficiente = factorySuficiente;
            _computadoraArmada = computadoraArmada;
        }

        //orderby en builder
        //repositorio componentes en builder 

        public static BuilderComputadora Inicializar(IEnumerable<Componente> componentes, RequerimientoArmado requerimientoArmado, decimal costoDeArmado, FactoryCompatibilidad factoryCompatibilidad, FactorySuficiente factorySuficiente, Componente cpuIterado)
        {
            return new BuilderComputadora(componentes, requerimientoArmado, costoDeArmado, factoryCompatibilidad, factorySuficiente, cpuIterado, new Computadora()
            {
                CostoArmado = costoDeArmado,
                TipoUso = requerimientoArmado.TipoUso
            });
        }

        public BuilderComputadora AgregarCpu()
        {
            return this;
        }

        public BuilderComputadora AgregarMother()
        {
            return this;
        }

        public BuilderComputadora AgregarRam()
        {
            return this;
        }

        public BuilderComputadora AgregarFan()
        {
            return this;
        }

        public BuilderComputadora AgregarGpu()
        {
            return this;
        }// agregar integrated video

        public BuilderComputadora AgregarHdd()
        {
            return this;
        }

        public BuilderComputadora AgregarSsd()
        {
            return this;
        }

        public BuilderComputadora AgregarTower()
        {
            return this;
        }

        public BuilderComputadora AgregarPsu()
        {
            return this;
        }

        public Computadora Build()
        {
            return _computadoraArmada;
        }

        private void AgregarComponente(Componente componente, int cantidad)
        {

        }

        private bool EsComponenteValido(Componente componente, int cantidadParaAgregar)
        {
            return true;
        }

        private bool EsPresupuestoValido(Componente componente)
        {
            return true;
        }

        private bool EsComponenteValido(Componente componente)
        {
            return true;
        }

        private bool EsStockValido(Componente componente)
        {
            return true;
        } 
    }
}
