using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
