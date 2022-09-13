using Dominio;

namespace Aplicacion
{
    public class SesionCliente
    {
        private SesionCliente()
        {
        }

        public static Cliente Logueado { get; private set; }

        public static void Ingresar(Cliente cliente)
        {
            Logueado = cliente;
        }

        public static void Salir()
        {
            Logueado = null;
        }
    }
}