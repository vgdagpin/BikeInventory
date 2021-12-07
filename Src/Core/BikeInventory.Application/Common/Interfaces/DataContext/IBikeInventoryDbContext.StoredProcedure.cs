using System;
using System.Collections.Generic;
using System.Text;

namespace BikeInventory.Application.Common.Interfaces
{
    public partial interface IBikeInventoryDbContext
    {
        // Custom context procedures

        DateTime GetCurrentSQLServerTime();
    }
}

