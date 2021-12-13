using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BikeInventory.Application.Common.Entities;
using BikeInventory.Application.Common.Interfaces;
using BikeInventory.Application.Repositories.Base;
using BikeInventory.Common;
using BikeInventory.Interfaces;
using BikeInventory.Models;

using Microsoft.EntityFrameworkCore;

namespace BikeInventory.Application.Repositories
{
    internal class RentalTransactionRepository : GenericRepository<RentalTransaction>, IRentalTransactionRepository
    {
        private readonly IDateTime p_DateTime;
        private readonly IPaymentRepository p_PaymentRepository;

        public RentalTransactionRepository(IBikeInventoryDbContext dbContext, IMapper mapper, IDateTime dateTime, IPaymentRepository paymentRepository) : base(dbContext, mapper)
        {
            p_DateTime = dateTime;
            p_PaymentRepository = paymentRepository;
        }


        public override RentalTransaction Find(object identity)
        {
            return m_DbContext.RentalTransactions
                .Include(a => a.N_Bike)
                .Include(a => a.N_BikeRate)
                .Include(a => a.N_Customer)
                .ProjectTo<RentalTransaction>(m_Mapper.ConfigurationProvider)
                .SingleOrDefault(a => a.TransactionID == (Guid)identity);
        }

        public bool TryCheckOutBike(int bikeID, int staffID, int customerID, out CheckoutResult checkoutResult)
        {
            try
            {
                Guard.ThrowIfNull(bikeID, nameof(bikeID));

                var bike = m_DbContext.Bikes.SingleOrDefault(a => a.ID == bikeID);
                var activeRate = m_DbContext.BikeRates.SingleOrDefault(a => a.BikeID == bikeID && a.IsActive);

                Guard.ThrowIfNull(bike, nameof(bike));
                Guard.ThrowIfNull(activeRate, nameof(activeRate));

                if (bike.Status != Enums.BikeStatus.Available)
                {
                    throw new BikeRentalException("Bike is not available");
                }

                var ticket = new tbl_RentalTransaction
                {
                    ID = Guid.NewGuid(),
                    AttendantID = staffID,
                    BikeID = bikeID,
                    BikeRateID = activeRate.ID,
                    CheckedOut = p_DateTime.UtcNow,
                    CustomerID = customerID
                };

                bike.Status = Enums.BikeStatus.Out;

                m_DbContext.RentalTransactions.Add(ticket);

                m_DbContext.SaveChanges();

                checkoutResult = CheckoutResult.Success(new Ticket
                {
                    TransactionID = ticket.ID
                });

                return true;
            }
            catch (Exception ex)
            {
                checkoutResult = CheckoutResult.Failed(ex);

                return false;
            }
        }

        public bool TryCheckInBike(Guid transactionId, int staffID, out CheckinResult checkinResult)
        {
            try
            {
                var rentalTransaction = Find(transactionId);

                checkinResult = new SuccessCheckinResult
                {
                    Ticket = rentalTransaction,
                    TotalMinutes = p_PaymentRepository.CalculateElapsedMinutes(rentalTransaction),
                    TotalAmount = p_PaymentRepository.CalculateTotalAmount(rentalTransaction)
                };

                return true;
            }
            catch (Exception ex)
            {
                checkinResult = new FailedCheckinResult
                {
                    Error = ex
                };

                return false;
            }
        }

        public void ProcessCheckInBike(Guid transactionId)
        {
            var rentalTransaction = Find(transactionId);

            var bike = m_DbContext.Bikes.SingleOrDefault(a => a.ID == rentalTransaction.Bike.ID);

            if (bike != null)
            {
                bike.Status = Enums.BikeStatus.Available;

                m_DbContext.SaveChanges();
            }
        }
    }
}
