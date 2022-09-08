using Aplicacion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //RequerimientoArmado requerimiento = new RequerimientoArmado();
            //List<Componente> componentes = new List<Componente>(); //ordenar por importancia
            //Computadora computadora = ObtenerComputadora(requerimiento, componentes);
            // si da error llevar a una pantalla de error que le permita volver a cargar otro presupuesto
            // verificar el login antes de armar el pedido y luego del presupuesto presupuesto -> control login -> pedido
        }

        private static Computadora ObtenerComputadora(RequerimientoArmado requerimiento, List<Componente> componentes)
        {
            IEnumerable<Computadora> computadoras = from cpu in new List<Componente>().Where(c => c.Tipo == "CPU")
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
                return ArmadorComputadora.Inicializar(null, 0, null, 0, null, cpuIterado)
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
