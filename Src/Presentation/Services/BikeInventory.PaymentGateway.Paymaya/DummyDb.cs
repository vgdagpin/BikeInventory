using BikeInventory.Models;

namespace BikeInventory.PaymentGateway.Paymaya
{
    public class DummyDb
    {
        public Dictionary<string, Receipt> Receipts { get; set; } = new();
    }
}
