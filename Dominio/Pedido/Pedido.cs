using System;

namespace Dominio
{
    public class Pedido
    {
        public Computadora Computadora { get; set; }
        public int IdCliente { get; set; }
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
    }
}
