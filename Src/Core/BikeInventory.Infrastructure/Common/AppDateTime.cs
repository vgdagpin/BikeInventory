using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Interfaces;

namespace BikeInventory.Infrastructure.Common
{
    public class AppDateTime : IDateTime
    {
        public DateTime UtcNow { get; private set; } = DateTime.UtcNow;
    }
}
