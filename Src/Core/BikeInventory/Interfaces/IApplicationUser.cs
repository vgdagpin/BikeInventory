using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Common;

namespace BikeInventory.Interfaces
{
    public interface IApplicationUser
    {
        AppUser User { get; set; }
    }
}
