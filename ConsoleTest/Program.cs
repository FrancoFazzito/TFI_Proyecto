using Repositorio;
using System;
using System.Linq;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var repoComponentes = new RepositorioComponenteSoloLectura();
            var componentes = repoComponentes.ObtenerTodos;
            var componentesboolean = componentes.Any();

            var repoEspecificaciones = new RepositorioEspecificacionSoloLectura();
            var especificaciones = repoEspecificaciones.ObtenerTodos;
            var especificacionesboolean = componentes.Any();

            Console.ReadLine();
        }
    }
}
