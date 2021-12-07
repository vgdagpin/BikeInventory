using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Common
{
    public abstract class Enums
    {
        public enum FindBy
        {
            Id,
            Username,
            Email
        }

        public enum BikeStatus
        {
            Maintenance,
            Available,
            Out
        }
    }
}
