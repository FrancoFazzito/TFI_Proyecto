using Dominio;

namespace Aplicacion
{
    public class EmpleadoLogueado
    {
        private static EmpleadoLogueado instancia;

        private EmpleadoLogueado()
        {
        }

        public static EmpleadoLogueado Instancia => instancia ?? new EmpleadoLogueado();

        public static void Salir()
        {
            instancia = null;
        }

        public Empleado Logueado { get; set; }
    }
}
