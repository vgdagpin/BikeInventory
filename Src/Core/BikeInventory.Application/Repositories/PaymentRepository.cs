using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BikeInventory.Application.Common.Interfaces;
using BikeInventory.Interfaces;
using BikeInventory.Models;

namespace BikeInventory.Application.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IBikeInventoryDbContext p_DbContext;
        private readonly IMapper p_Mapper;

        public PaymentRepository(IBikeInventoryDbContext dbContext, IMapper mapper)
        {
            p_DbContext = dbContext;
            p_Mapper = mapper;
        }

        public IEnumerable<PaymentHandler> GetPaymentHandlers()
        {
            return p_DbContext.PaymentHandlers
                .ProjectTo<PaymentHandler>(p_Mapper.ConfigurationProvider)
                .ToList();
        }

        public Task<bool> TryPaymentAsync(RentalTransaction transaction, PaymentHandler payment, out PaymentResult paymentResult)
        {
            throw new NotImplementedException();
        }
    }
}
