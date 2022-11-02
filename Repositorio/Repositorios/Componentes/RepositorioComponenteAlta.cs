using Dapper;
using Dominio;

namespace Repositorio
{
    public class RepositorioComponenteAlta
    {
        private const string command = "INSERT INTO [dbo].[Componente] VALUES " +
                                                                    "(@Nombre," +
                                                                    "@Precio," +
                                                                    "@Perfomance," +
                                                                    "@Tipo," +
                                                                    "@TipoFormato," +
                                                                    "@TipoMemoria," +
                                                                    "@Socket," +
                                                                    "@TieneVideoIntegrado," +
                                                                    "@Canales," +
                                                                    "@NivelVideoIntegrado," +
                                                                    "@NivelFanIntegrado," +
                                                                    "@NecesitaAltaFrecuencia," +
                                                                    "@Capacidad," +
                                                                    "@TamanoFan," +
                                                                    "@MaximaFrecuencia," +
                                                                    "@Stock," +
                                                                    "@ConsumoEnWatts," +
                                                                    "@StockLimite)";

        public int Agregar(Componente componente)
        {
            return Db.Conexion.Execute(command, new ParametrosComponente().Obtener(componente));
        }
    }
}