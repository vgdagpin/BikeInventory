using BikeInventory.Models;

namespace BikeInventory.Kiosk.Views.Home
{
    public class StaffHome
    {
        public IEnumerable<BikeModel> BikeModels { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
