using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Common;
using BikeInventory.Models;

namespace BikeInventory.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindBy(Enums.FindBy findBy, object identity);
    }
}
