using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Models
{
    public class PaymentHandler
    {
        public short ID { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public bool IsActive { get; set; }
    }
}
