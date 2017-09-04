using System.Security.Cryptography;
using System.Text;

namespace Services.Helpers
{
    public class HashingHelper
    {
        public static string HashPassword(string password)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            return Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}
