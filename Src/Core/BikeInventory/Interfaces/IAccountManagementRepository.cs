using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Models;

namespace BikeInventory.Interfaces
{
    public interface IAccountManagementRepository : IRepository
    {
        bool TryLogin(string emailAddress, string password, out User user, out string[] roles);
        User Register(string firstName, string middleName, string lastName, string emailAddress);

        void AddRole(int userId, string role);
        void RemoveRole(int userId, string role);
    }
}