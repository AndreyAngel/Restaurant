using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Restaurant.Auth.Core.Helpers
{
    public class PasswordHelper
    {
        public static string Encrypt(IConfiguration configuration, string password)
        {
            return GenerateHashedPassword(configuration, password);
        }

        public static bool Verify(IConfiguration configuration, string enteredPassword, string hashedPassword)
        {
            string enteredPasswordHash = GenerateHashedPassword(configuration, enteredPassword);
            return string.Equals(enteredPasswordHash, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }

        private static string GenerateHashedPassword(IConfiguration configuration, string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var salt = Encoding.UTF8.GetBytes(configuration["Authentication:Salt"]);

                byte[] hashedPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));

                return Encoding.UTF8.GetString(hashedPassword);
            }
        }
    }
}
