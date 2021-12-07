using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Common
{
    public class AppUser : IPrincipal
    {
        public IIdentity Identity { get; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
