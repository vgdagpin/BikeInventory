using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Common;
using BikeInventory.Interfaces;

namespace BikeInventory.Application.Common
{
    public class ApplicationUser : IApplicationUser
    {
        public AppUser User { get; set; }
    }
}
