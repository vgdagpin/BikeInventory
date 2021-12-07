using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;


/*
Do not modify this file! This is auto generated!
Any changes to this file will be gone when template gets generated again.
Version: 2.0
*/

namespace BikeInventory.Application.Common.Interfaces
{
    public partial interface IBikeInventoryDbContext
    {
        Guid UID { get; }
        bool HasSeedData { get; set; }

        #region Entities
        IQueryable<tbl_Bike> Bikes { get; }
        IQueryable<tbl_BikeModel> BikeModels { get; }
        IQueryable<tbl_BikeRate> BikeRates { get; }
        IQueryable<tbl_Customer> Customers { get; }
        IQueryable<tbl_PaymentHandler> PaymentHandlers { get; }
        IQueryable<tbl_PaymentHandlerSetting> PaymentHandlerSettings { get; }
        IQueryable<tbl_Receipt> Receipts { get; }
        IQueryable<tbl_RentalTransaction> RentalTransactions { get; }
        IQueryable<tbl_User> Users { get; }
        IQueryable<tbl_UserCredential> UserCredentials { get; }
        IQueryable<tbl_UserRole> UserRoles { get; }
        #endregion

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}


