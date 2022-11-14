using System;

namespace Repositorio
{
    public class PedidoConsulta
    {
        public int IdComputadora { get; set; }
        public string TipoUso { get; set; }
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaPedido { get; set; }
    }
}