using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Models;

namespace BikeInventory.Interfaces
{
    public interface IPaymentRepository : IRepository
    {
        IEnumerable<PaymentHandler> GetPaymentHandlers();

        Task<bool> TryPaymentAsync(RentalTransaction transaction, PaymentHandler payment, out PaymentResult paymentResult);
    }
}