using BikeInventory.Models;

namespace BikeInventory.Kiosk.Views.Home
{
    public class PaymentViewModel
    {
        public PaymentResult PaymentResult { get; set; }
    }

    public class PaymentPayload
    {
        public Guid TransactionID { get; set; }
        public short PaymentHandlerID { get; set; }
    }
}
