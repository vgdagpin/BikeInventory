using BikeInventory.Models;

namespace BikeInventory.PaymentGateway.GCash
{
    public class DummyDb
    {
        public Dictionary<string, Receipt> Receipts { get; set; } = new();
    }
}
