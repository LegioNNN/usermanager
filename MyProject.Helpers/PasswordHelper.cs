using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MyProject.Helpers
{
    public static class PasswordHelper
    {
        // Þifreyi hash + salt oluþtur
        public static (byte[] hash, byte[] salt) CreateHash(string password)
        {
            using (var hmac = new HMACSHA256())
            {
                var salt = hmac.Key; // rastgele key kullanýyoruz
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return (hash, salt);
            }
        }

        // Þifre doðrulama
        public static bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA256(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return storedHash.SequenceEqual(computedHash);
            }
        }
    }
}
