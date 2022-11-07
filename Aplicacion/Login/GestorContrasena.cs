using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Aplicacion
{
    public class GestorContrasena
    {
        private const string Format = "x2";

        public string Hashear(string value)
        {
            StringBuilder hash = new StringBuilder();
            foreach (byte _byte in new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(value)))
            {
                hash.Append(_byte.ToString(Format));
            }
            return hash.ToString();
        }

        public bool Verificar(string contrasenaGuardada, string contrasenaIngresada)
        {
            return Hashear(contrasenaIngresada) == contrasenaGuardada;
        }

        public bool ValidarRequerimientos(string contrasena)
        {
            return contrasena.Any(x => char.IsDigit(x)) && contrasena.Any(x => char.IsUpper(x)) && contrasena.Any(x => char.IsLower(x));
        }
    }
}