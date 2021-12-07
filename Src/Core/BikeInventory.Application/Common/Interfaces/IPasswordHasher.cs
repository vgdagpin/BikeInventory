using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Application.Common.Interfaces
{
    public interface IPasswordHasher
    {
        byte[] GenerateSalt();

        byte[] HashPassword(byte[] salt, string password);

        /// <summary>
        /// Check if the inputted clear text password is the same with the hashedPassword from database
        /// </summary>
        /// <param name="salt">Salt from database</param>
        /// <param name="hashedPassword">Hashed password from database</param>
        /// <param name="password">Password to check</param>
        /// <returns></returns>
        bool IsPasswordVerified(byte[] salt, byte[] hashedPassword, string password);
    }
}
