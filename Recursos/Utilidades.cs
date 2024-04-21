using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
namespace AdminRooms.Recursos
{
    public class Utilidades
    {
        public static string Encrypt(string pass)
        {
            StringBuilder stringBuilder = new();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;

                byte[] result = hash.ComputeHash(encoding.GetBytes(pass));

                foreach (byte b in result)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
            }

            return stringBuilder.ToString();
        }
    }
}
