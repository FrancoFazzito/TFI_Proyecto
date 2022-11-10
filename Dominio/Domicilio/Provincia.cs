using System.Collections.Generic;

namespace Dominio
{
    public class Provincia
    {
        public void AddBarrio(Barrio barrio)
        {
            Barrios.Add(barrio);
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public List<Barrio> Barrios { get; } = new List<Barrio>();
    }
}