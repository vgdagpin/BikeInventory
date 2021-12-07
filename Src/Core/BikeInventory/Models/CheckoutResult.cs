using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Models
{
    public abstract class CheckoutResult
    {
    }

    public class SuccessCheckoutResult : CheckoutResult
    {
        public Ticket Ticket { get; set; }
    }

    public class FailedCheckoutResult : CheckoutResult
    {
        public Exception Error { get; set; }
    }
}
