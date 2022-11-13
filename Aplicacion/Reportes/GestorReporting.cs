using Aplicacion.Pedidos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Aplicacion
{
    public class GestorReporting
    {
        private readonly IEnumerable<Pedido> _pedidos = new GestorPedido().Todos;

        public Dictionary<string, string> ComponentesMasVendidos
        {
            get
            {
                var componenteCantidad = new Dictionary<string, int>();
                foreach (var componente in _pedidos.SelectMany(pedido => pedido.Computadora.Componentes))
                {
                    if (componenteCantidad.ContainsKey(componente.Nombre))
                    {
                        componenteCantidad[componente.Nombre] += 1;
                        continue;
                    }
                    componenteCantidad.Add(componente.Nombre, 1);
                }
                return componenteCantidad.OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value.ToString());
            }
        }

        public Dictionary<string, string> TiposUsoMasSolicitados
        {
            get
            {
                var tipoUsoCantidad = new Dictionary<string, int>();
                foreach (var tipoUso in _pedidos.Select(pedido => pedido.Computadora.TipoUso))
                {
                    if (tipoUsoCantidad.ContainsKey(tipoUso))
                    {
                        tipoUsoCantidad[tipoUso] += 1;
                        continue;
                    }
                    tipoUsoCantidad.Add(tipoUso, 1);
                }
                return tipoUsoCantidad.OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value.ToString());
            }
        }

        public Dictionary<string, decimal> ObtenerValorPedidosDoceMeses
            => _pedidos.OrderBy(x => x.Fecha)
                       .GroupBy(x => x.Fecha.Month)
                       .ToDictionary(x => x.Key.ToString(), x => Math.Truncate(x.Sum(p => p.Computadora.Precio)));

        public Dictionary<string, decimal> ClientesSegmentados
            => _pedidos.GroupBy(x => x.Computadora.TipoUso)
                       .ToDictionary(x => x.Key.ToString(), x => Math.Truncate(x.Average(p => p.Computadora.Precio)));

        public Dictionary<string, decimal> GananciasUltimosMeses
            => ObtenerValorPedidosDoceMeses.OrderByDescending(x => x.Key)
                                           .Take(3)
                                           .ToDictionary(x => x.Key, x => CalcularGanancia(x));

        private decimal CalcularGanancia(KeyValuePair<string, decimal> x)
        {
            decimal porcentajeGanancia = decimal.Parse(ConfigurationManager.AppSettings["porcentajeGanancia"]) / 100;
            decimal ganancia = x.Value * porcentajeGanancia;
            return Math.Truncate(ganancia);
        }
    }
}