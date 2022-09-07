using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        void Main(string[] args)
        {
            var requerimiento = new RequerimientoArmado();
            var componentes = new List<Componente>(); //ordenar por importancia
            var computadora = ObtenerComputadora(requerimiento, componentes);
            // si da error llevar a una pantalla de error que le permita volver a cargar otro presupuesto
            // verificar el login antes de armar el pedido y luego del presupuesto presupuesto -> control login -> pedido
        }

        private Computadora ObtenerComputadora(RequerimientoArmado requerimiento, List<Componente> componentes)
        {
            var computadoras =  from cpu in new List<Componente>().Where(c => c.Tipo == "CPU")
                                let computer = ArmarComputadora(cpu, requerimiento)
                                where computer != null
                                select computer;
            //order computadoras por precio calidad
            return computadoras.Any() ? computadoras.First() : throw new Exception();
        }

        private static Computadora ArmarComputadora(Componente cpuIterado, RequerimientoArmado requerimiento)
        {
            try
            {
               return BuilderComputadora.Inicializar(null, requerimiento, 0, null, null, cpuIterado)
                                        .AgregarCpu()
                                        .AgregarMother()
                                        .AgregarRam()
                                        .AgregarFan()
                                        .AgregarGpu()
                                        .AgregarHdd()
                                        .AgregarSsd()
                                        .AgregarTower()
                                        .AgregarPsu()
                                        .Build();
            }
            catch (AgregadoInvalido)
            {
                return null;
            }
        }
    }
}
