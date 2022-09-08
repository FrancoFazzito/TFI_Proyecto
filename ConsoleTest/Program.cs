using Aplicacion;
using Dominio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RepositorioComponenteSoloLectura repo = new RepositorioComponenteSoloLectura();
            IEnumerable<Componente> componentes = repo.ObtenerTodos;
            foreach (var item in componentes)
            {
                Console.WriteLine(item.Nombre);
            }
        }
    }
}
