using Dapper;
using Dominio;

namespace Repositorio
{
    public class ParametrosComponente
    {
        public DynamicParameters Obtener(Componente componente)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", componente.Id);
            parameters.Add("@Nombre", componente.Nombre);
            parameters.Add("@Precio", componente.Precio);
            parameters.Add("@Perfomance", componente.Perfomance);
            parameters.Add("@Tipo", componente.Tipo);
            parameters.Add("@TipoFormato", componente.TipoFormato);
            parameters.Add("@TipoMemoria", componente.TipoMemoria);
            parameters.Add("@Socket", componente.Socket);
            parameters.Add("@TieneVideoIntegrado", componente.TieneVideoIntegrado);
            parameters.Add("@Canales", componente.Canales);
            parameters.Add("@NivelVideoIntegrado", componente.NivelVideoIntegrado);
            parameters.Add("@NivelFanIntegrado", componente.NivelFanIntegrado);
            parameters.Add("@NecesitaAltaFrecuencia", componente.NecesitaAltaFrecuencia);
            parameters.Add("@Capacidad", componente.Capacidad);
            parameters.Add("@TamanoFan", componente.TamanoFan);
            parameters.Add("@Stock", componente.Stock);
            parameters.Add("@MaximaFrecuencia", componente.MaximaFrecuencia);
            parameters.Add("@ConsumoEnWatts", componente.ConsumoEnWatts);
            parameters.Add("@StockLimite", componente.StockLimite);
            return parameters;
        }
    }
}