using BikeInventory.Models;

namespace BikeInventory.Kiosk.Views.Home
{
    public class Checkout
    {
        public CheckoutResult CheckoutResult { get; set; }
        public Bike Bike { get; set; }
    }

    public class CheckoutPayload
    {
        public int BikeID { get; set; }
        public int CustomerID { get; set; }
    }
}
