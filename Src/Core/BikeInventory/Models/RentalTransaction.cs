using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Models
{
    public class RentalTransaction : Ticket
    {
        public Bike Bike { get; set; }
        public BikeRate BikeRate { get; set; }
        public Customer Customer { get; set; }
        public DateTime CheckedOut { get; set; }

    }
}
