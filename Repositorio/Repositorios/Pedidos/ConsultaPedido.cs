using System;

namespace Repositorio.Repositorios.Pedidos
{
    public class ConsultaPedido
    {
        public int IdComputadora { get; set; }
        public string TipoUso { get; set; }
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaPedido { get; set; }
    }
}