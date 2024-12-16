using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
namespace Lab09.Utilities
{
    public static class Utils
    {
        public static string GetSHA26Hash(string s)
        {
            string hash = "";
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
                hash= BitConverter.ToString(hashedBytes).Replace("-","").ToLower(); 

            }
            return hash;

        }
    }
}
