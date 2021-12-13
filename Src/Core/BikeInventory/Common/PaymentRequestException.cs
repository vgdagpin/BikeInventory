using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Common
{
    public class PaymentRequestException : Exception
    {
        public PaymentRequestException() : base() { }
        public PaymentRequestException(string message) : base(message) { }


        public static async Task<PaymentRequestException> Parse(HttpResponseMessage message)
        {
            var err = await message.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(err))
            {
                err = message.StatusCode.ToString();
            }

            return new PaymentRequestException(err);
        }
    }
}
