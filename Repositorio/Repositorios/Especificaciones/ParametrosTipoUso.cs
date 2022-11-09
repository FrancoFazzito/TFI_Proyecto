using Dapper;
using Dominio;

namespace Repositorio
{
    public class ParametrosTipoUso
    {
        public DynamicParameters Obtener(TipoUso especificacion)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", especificacion.Id);
            parameters.Add("@Nombre", especificacion.Nombre);
            parameters.Add("@cpu", especificacion.Cpu);
            parameters.Add("@ram", especificacion.Ram);
            parameters.Add("@gpu", especificacion.Gpu);
            parameters.Add("@hdd", especificacion.Hdd);
            parameters.Add("@ssd", especificacion.Ssd);
            return parameters;
        }
    }
}