using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BikeInventory.Application.Common.Interfaces;
using BikeInventory.Application.Repositories.Base;
using BikeInventory.Interfaces;
using BikeInventory.Models;

namespace BikeInventory.Application.Repositories
{
    internal class RentalTransactionRepository : GenericRepository<RentalTransaction>, IRentalTransactionRepository
    {
        public RentalTransactionRepository(IBikeInventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public bool TryCheckOutBike(Bike bike, Customer customer, out CheckoutResult checkoutResult)
        {
            throw new NotImplementedException();
        }

        public bool TryCheckInBike(Bike bike, Customer customer, out CheckinResult checkinResult)
        {
            throw new NotImplementedException();
        }

        
    }
}
