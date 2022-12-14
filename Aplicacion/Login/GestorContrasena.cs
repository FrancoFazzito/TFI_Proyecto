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
            var contrasenaHasheada = new StringBuilder();
            foreach (var _byte in new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(value)))
            {
                contrasenaHasheada.Append(_byte.ToString(Format));
            }
            return contrasenaHasheada.ToString();
        }

        public bool Verificar(string contrasenaGuardada, string contrasenaIngresada) => Hashear(contrasenaIngresada) == contrasenaGuardada;

        public bool ValidarRequerimientos(string contrasena) => contrasena.Any(x => char.IsDigit(x)) && contrasena.Any(x => char.IsUpper(x)) && contrasena.Any(x => char.IsLower(x)) && contrasena.Length >= 8;
    }
}