using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory
{
    public class BikeRentalException : Exception
    {
        public BikeRentalException(string message) : base(message) { }
    }
}
