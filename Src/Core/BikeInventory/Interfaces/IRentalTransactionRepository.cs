using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Models;

namespace BikeInventory.Interfaces
{
    public interface IRentalTransactionRepository : IRepository
    {
        bool TryCheckOutBike(Bike bike, Customer customer, out CheckoutResult checkoutResult);

        bool TryCheckInBike(Bike bike, Customer customer, out CheckinResult checkinResult);
    }
}
