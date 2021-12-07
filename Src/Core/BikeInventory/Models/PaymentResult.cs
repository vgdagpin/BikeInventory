using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Models
{
    public abstract class PaymentResult
    {
    }

    public class SuccessPaymentResult : PaymentResult
    {
        public string ServiceName { get; set; }
        public string ReferenceNumber { get; set; }
        public Receipt Receipt { get; set; }
        public Ticket Ticket { get; set; }
    }

    public class FailedPaymentResult : PaymentResult
    {
        public Exception Error { get; set; }
    }
}
