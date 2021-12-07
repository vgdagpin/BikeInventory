using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Models
{
    public class CheckinResult
    {
    }

    public class SuccessCheckinResult
    {
        public Guid TransactionID { get; set; }

        public DateTime CheckoutTime { get; set; }
        public DateTime CheckinTime { get; set; }
        public long DurationInMinutes { get; set; }

        public decimal RatePerMinute { get; set; }
        public decimal TotalPayable { get; set; }
    }

    public class FailedCheckinResult
    {
        public Exception Error { get; set; }
    }
}
