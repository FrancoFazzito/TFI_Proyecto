using Dominio;

namespace Aplicacion
{
    public class ClienteLogueado
    {
        private static ClienteLogueado instancia;

        private ClienteLogueado()
        {
        }

        public static ClienteLogueado Instancia => instancia ?? new ClienteLogueado();

        public static void Salir()
        {
            instancia = null;
        }

        public Cliente Logueado { get; set; }
    }
}
