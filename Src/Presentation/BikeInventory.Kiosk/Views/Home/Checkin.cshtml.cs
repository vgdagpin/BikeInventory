using BikeInventory.Models;

namespace BikeInventory.Kiosk.Views.Home
{
    public class Checkin
    {
        public IEnumerable<PaymentHandler> PaymentHandlers { get; set; } = new List<PaymentHandler>();
        public RentalTransaction Ticket { get; set; }
    }
}
