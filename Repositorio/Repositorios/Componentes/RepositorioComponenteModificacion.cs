using Dapper;
using Dominio;

namespace Repositorio
{
    public class RepositorioComponenteModificacion
    {
        private const string command = "UPDATE [dbo].[Componente] " +
                                       "SET [Nombre] = @Nombre," +
                                           "[Precio] = @Precio," +
                                           "[Perfomance] = @Perfomance," +
                                           "[Tipo] = @Tipo," +
                                           "[TipoFormato] = @TipoFormato," +
                                           "[TipoMemoria] = @TipoMemoria," +
                                           "[Socket] = @Socket," +
                                           "[TieneVideoIntegrado] = @TieneVideoIntegrado," +
                                           "[Canales] = @Canales," +
                                           "[NivelVideoIntegrado] = @NivelVideoIntegrado," +
                                           "[NivelFanIntegrado] = @NivelFanIntegrado," +
                                           "[NecesitaAltaFrecuencia] = @NecesitaAltaFrecuencia," +
                                           "[Capacidad] = @Capacidad," +
                                           "[TamanoFan] = @TamanoFan," +
                                           "[MaximaFrecuencia] = @MaximaFrecuencia," +
                                           "[Stock] = @Stock," +
                                           "[ConsumoEnWatts] = @ConsumoEnWatts," +
                                           "[StockLimite] = @StockLimite " +
                                       "WHERE ID = @id";

        public int Modificar(Componente componente)
        {
            return Db.Conexion.Execute(command, new ParametrosComponente().Obtener(componente));
        }
    }
}