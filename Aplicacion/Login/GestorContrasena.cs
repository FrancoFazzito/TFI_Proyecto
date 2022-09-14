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

        public bool Verificar(string contrasenaGuardada, string contrasenaIngresada) => Hashear(contrasenaIngresada) == contrasenaGuardada;
    }
}