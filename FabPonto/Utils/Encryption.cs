using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FabPonto.Utils
{
    public static class Encryption
    {
        public static String sha256_hash(String value) {
            using (SHA256 hash = SHA256Managed.Create()) {
                return String.Concat(hash
                    .ComputeHash(Encoding.UTF8.GetBytes(value))
                    .Select(item => item.ToString("x2")));
            }
        }
    }
}