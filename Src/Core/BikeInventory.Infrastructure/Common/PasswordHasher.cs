using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Interfaces;

namespace BikeInventory.Infrastructure.Common
{
    public class PasswordHasher : IPasswordHasher
    {
        const int SaltSize = 128 / 8; // 128 bits
        public byte[] GenerateSalt()
        {
            var rng = RandomNumberGenerator.Create();
            var salt = new byte[SaltSize];

            rng.GetBytes(salt);

            return salt;
        }

        public byte[] HashPassword(byte[] salt, string password)
        {
            var plainText = Encoding.UTF8.GetBytes(password);

            var algorithm = SHA256.Create();

            var plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }

            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        public bool IsPasswordVerified(byte[] salt, byte[] hashedPassword, string password)
            => HashPassword(salt, password).SequenceEqual(hashedPassword);
    }
}
