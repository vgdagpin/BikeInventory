using BikeInventory.Models;

namespace BikeInventory.Kiosk.Views.Home
{
    public class PaymentViewModel
    {
        public IEnumerable<PaymentHandler> PaymentHandlers { get; set; } = new List<PaymentHandler>();
        public Ticket Ticket { get; set; }
        public Bike Bike { get; set; }
    }
}
