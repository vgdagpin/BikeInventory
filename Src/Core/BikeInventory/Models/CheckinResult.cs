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

    public class SuccessCheckinResult : CheckinResult
    {
        public RentalTransaction Ticket { get; set; }

        public decimal TotalMinutes { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class FailedCheckinResult : CheckinResult
    {
        public Exception Error { get; set; }
    }
}
