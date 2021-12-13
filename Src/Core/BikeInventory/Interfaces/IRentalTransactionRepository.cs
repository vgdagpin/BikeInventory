using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Models;

namespace BikeInventory.Interfaces
{
    public interface IRentalTransactionRepository : IGenericRepository<RentalTransaction>
    {
        bool TryCheckOutBike(int bikeID, int staffID, int customerID, out CheckoutResult checkoutResult);

        bool TryCheckInBike(Guid transactionId, int staffID, out CheckinResult checkinResult);
    }
}
