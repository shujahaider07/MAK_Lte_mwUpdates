using System.Security.Cryptography;
using System.Text;

namespace SHASecureAlgorithm
{
    public class Sha512
    {

        public static string SecureAlgorithm(string password)
        {

            try
            {

                SHA256CryptoServiceProvider sHA512 = new SHA256CryptoServiceProvider();

                byte[] encode = Encoding.ASCII.GetBytes(password);
                byte[] compute_hash = sHA512.ComputeHash(encode);
               
                return Convert.ToBase64String(compute_hash);

            }
            catch (Exception)
            {

            }
            return null;
        }
    }
}