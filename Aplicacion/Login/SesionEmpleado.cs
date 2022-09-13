using Dominio;

namespace Aplicacion
{
    public class SesionEmpleado
    {
        private SesionEmpleado()
        {
        }

        public static Empleado Logueado { get; private set; }

        public static void Ingresar(Empleado empleado)
        {
            Logueado = empleado;
        }

        public static void Salir()
        {
            Logueado = null;
        }
    }
}