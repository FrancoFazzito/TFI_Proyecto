﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio
{
    public class Computadora
    {
        public void Add(Componente element, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Componentes.Add(element);
            }
        }

        public int Id { get; set; }
        public string TipoUso { get; set; }
        public decimal CostoArmado { get; set; } //add costo armado to computer table
        public ICollection<Componente> Componentes { get; } = new List<Componente>();
        public decimal Price => Componentes.Sum(c => c.Precio) + CostoArmado;
        public int ConsumoTotal => Componentes.Sum(c => c.ConsumoEnWatts);
        public decimal Perfomance => Componentes.Sum(c => c.Perfomance);
        public decimal PricePerfomance => Math.Round(Perfomance / Price * 10000, 2);
        public Componente this[string tipo] => Componentes.FirstOrDefault(c => c.Tipo == tipo);
    }

}


