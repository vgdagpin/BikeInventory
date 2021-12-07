using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Models
{
    public class Receipt
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
    }
}
