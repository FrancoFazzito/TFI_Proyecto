using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Componente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Perfomance { get; set; }
        public string Tipo { get; set; }
        public int ConsumoEnWatts { get; set; }
        public string Socket { get; set; }
        public bool TieneVideoIntegrado { get; set; }
        public int Canales { get; set; }
        public int NivelVideoIntegrado { get; set; }
        public int NivelFanIntegrado { get; set; }
        public bool NecesitaAltaFrecuencia { get; set; }
        public int Capacidad { get; set; }
        public int TamanoFan { get; set; }
        public string TipoFormato { get; set; }
        public string TipoMemoria { get; set; }
        public int MaximaFrecuencia { get; set; }
        public int Stock { get; set; }
        public int StockLimite { get; set; }

        public bool EsCompatible(ICompatibilidad compatibilidad, Componente componente)
        {
            return compatibilidad.EsCompatible(this, componente);
        }
    }

    public class RequerimientoArmado
    {
        public string TipoUso { get; set; }
        public string Importancia { get; set; }
        public Especificacion Especificacion { get; set; }
        public decimal Precio { get; set; }
    }

    public class FactoryCompatibilidad
    {
        private readonly Dictionary<string, ICompatibilidad> CompatibilidadNombre = new Dictionary<string, ICompatibilidad>();

        public ICompatibilidad GetCompatibilidadPorNombre(string nombre)
        {
            return CompatibilidadNombre[nombre];
        }
    }

    public class Computadora
    {
        public void Add(Componente element, int quantity)
        {
            for (var i = 0; i < quantity; i++)
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

    public interface ICompatibilidad
    {
        bool EsCompatible(Componente componente, Componente componenteParaComparar);
    }

    public interface ISuficiente
    {
        bool EsSuficiente(Componente componente, int? cantidad);
    }

    public class ExcepcionAgregadoInvalido : Exception
    {

    }

    public class Especificacion
    {
        public int? Mother;

        public int Cpu { get; set; }
        public int? Fan { get; set; }
        public int Ram { get; set; }
        public int? Gpu { get; set; }
        public int Hdd { get; set; }
        public int Ssd { get; set; }
    }

}


    