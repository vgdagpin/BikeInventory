using BikeInventory.Models;

namespace BikeInventory.Kiosk.Views.Home
{
    public class Checkin
    {
        public CheckinResult CheckinResult { get; set; }

        public IEnumerable<PaymentHandler> PaymentHandlers { get; set; } = new List<PaymentHandler>();
    }
}
