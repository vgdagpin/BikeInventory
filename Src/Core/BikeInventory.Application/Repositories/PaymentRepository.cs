using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BikeInventory.Application.Common.Interfaces;
using BikeInventory.Commands.PaymentCmds;
using BikeInventory.Interfaces;
using BikeInventory.Models;

using Microsoft.EntityFrameworkCore;

using TasqR;

namespace BikeInventory.Application.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IBikeInventoryDbContext p_DbContext;
        private readonly IMapper p_Mapper;
        private readonly IDateTime p_DateTime;
        private readonly ITasqR p_TasqR;
        private readonly IServiceProvider p_ServiceProvider;

        public PaymentRepository(IBikeInventoryDbContext dbContext, IMapper mapper, IDateTime dateTime, ITasqR tasqR, IServiceProvider serviceProvider)
        {
            p_DbContext = dbContext;
            p_Mapper = mapper;
            p_DateTime = dateTime;
            p_TasqR = tasqR;
            p_ServiceProvider = serviceProvider;
        }

        public virtual decimal CalculateElapsedMinutes(RentalTransaction ticket) => (decimal)(p_DateTime.UtcNow - ticket.CheckedOut).TotalMinutes;

        public virtual decimal CalculateTotalAmount(RentalTransaction ticket) => CalculateElapsedMinutes(ticket) * ticket.BikeRate.RatePerMinute;

        public virtual IEnumerable<PaymentHandler> GetPaymentHandlers()
        {
            return p_DbContext.PaymentHandlers
                .ProjectTo<PaymentHandler>(p_Mapper.ConfigurationProvider)
                .ToList();
        }

        public async Task<PaymentResult> ProcessPayment(short paymentHandlerID, Guid transactionID)
        {
            try
            {
                var paymentHandler = p_DbContext.PaymentHandlers.SingleOrDefault(a => a.ID == paymentHandlerID);

                Guard.ThrowIfNull(paymentHandler, nameof(paymentHandler));

                var tasq = new PaymentCmd(transactionID);
                var assembly = Assembly.Load(paymentHandler.HandlerAssembly);
                var handler = assembly.GetType(paymentHandler.HandlerClass);

                var result = await p_TasqR.UsingAsHandler(handler).RunAsync(tasq);

                return result;
            }
            catch (Exception ex)
            {
                return new FailedPaymentResult
                {
                    Error = ex
                };
            }
        }

        public virtual Task<bool> TryPaymentAsync(RentalTransaction transaction, PaymentHandler payment, out PaymentResult paymentResult)
        {
            throw new NotImplementedException();
        }
    }
}
