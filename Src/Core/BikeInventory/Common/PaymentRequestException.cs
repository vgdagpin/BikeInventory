using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Common
{
    public class PaymentRequestException : Exception
    {
        public PaymentRequestException() : base() { }
        public PaymentRequestException(string message) : base(message) { }


        public static PaymentRequestException Parse(string response)
        {
            return new PaymentRequestException(response);
        }
    }
}
