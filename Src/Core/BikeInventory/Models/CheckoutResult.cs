using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Models
{
    public abstract class CheckoutResult
    {
        public static FailedCheckoutResult Failed(Exception ex) => new FailedCheckoutResult(ex);
        public static SuccessCheckoutResult Success(Ticket ticket) => new SuccessCheckoutResult(ticket);
    }

    public class SuccessCheckoutResult : CheckoutResult
    {
        public Ticket Ticket { get; }

        internal SuccessCheckoutResult(Ticket ticket)
        {
            Ticket = ticket;
        }
    }

    public class FailedCheckoutResult : CheckoutResult
    {
        public Exception Error { get; }

        internal FailedCheckoutResult(Exception exception)
        {
            Error = exception;
        }
    }
}
