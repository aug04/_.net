using System.Text;

namespace SomeeMVC_4.Utilities
{
    public class Sha256
    {
        public static string Hash(string str)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(str));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString().ToUpper();
        }
    }
}