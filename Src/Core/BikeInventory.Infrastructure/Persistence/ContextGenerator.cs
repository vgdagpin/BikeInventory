using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using BikeInventory.Application.Common.Interfaces;

using BikeInventory.Application.Common.Entities;

/*
Do not modify this file! This is auto generated!
Any changes to this file will be gone when template gets generated again.
Version: 2.0
*/

namespace BikeInventory.Infrastructure.Persistence
{
    public partial class BikeInventoryDbContext : DbContext, IBikeInventoryDbContext
    {
        public Guid UID { get; } = Guid.NewGuid();
        public bool HasSeedData { get; set; }

        #region Entities
        private DbSet<tbl_Bike> db_Bikes { get; set; }
        public IQueryable<tbl_Bike> Bikes 
        { 
            get => db_Bikes;
            private set => db_Bikes = (DbSet<tbl_Bike>)value;
        }

        private DbSet<tbl_BikeModel> db_BikeModels { get; set; }
        public IQueryable<tbl_BikeModel> BikeModels 
        { 
            get => db_BikeModels;
            private set => db_BikeModels = (DbSet<tbl_BikeModel>)value;
        }

        private DbSet<tbl_BikeRate> db_BikeRates { get; set; }
        public IQueryable<tbl_BikeRate> BikeRates 
        { 
            get => db_BikeRates;
            private set => db_BikeRates = (DbSet<tbl_BikeRate>)value;
        }

        private DbSet<tbl_Customer> db_Customers { get; set; }
        public IQueryable<tbl_Customer> Customers 
        { 
            get => db_Customers;
            private set => db_Customers = (DbSet<tbl_Customer>)value;
        }

        private DbSet<tbl_PaymentHandler> db_PaymentHandlers { get; set; }
        public IQueryable<tbl_PaymentHandler> PaymentHandlers 
        { 
            get => db_PaymentHandlers;
            private set => db_PaymentHandlers = (DbSet<tbl_PaymentHandler>)value;
        }

        private DbSet<tbl_PaymentHandlerSetting> db_PaymentHandlerSettings { get; set; }
        public IQueryable<tbl_PaymentHandlerSetting> PaymentHandlerSettings 
        { 
            get => db_PaymentHandlerSettings;
            private set => db_PaymentHandlerSettings = (DbSet<tbl_PaymentHandlerSetting>)value;
        }

        private DbSet<tbl_Receipt> db_Receipts { get; set; }
        public IQueryable<tbl_Receipt> Receipts 
        { 
            get => db_Receipts;
            private set => db_Receipts = (DbSet<tbl_Receipt>)value;
        }

        private DbSet<tbl_RentalTransaction> db_RentalTransactions { get; set; }
        public IQueryable<tbl_RentalTransaction> RentalTransactions 
        { 
            get => db_RentalTransactions;
            private set => db_RentalTransactions = (DbSet<tbl_RentalTransaction>)value;
        }

        private DbSet<tbl_User> db_Users { get; set; }
        public IQueryable<tbl_User> Users 
        { 
            get => db_Users;
            private set => db_Users = (DbSet<tbl_User>)value;
        }

        private DbSet<tbl_UserCredential> db_UserCredentials { get; set; }
        public IQueryable<tbl_UserCredential> UserCredentials 
        { 
            get => db_UserCredentials;
            private set => db_UserCredentials = (DbSet<tbl_UserCredential>)value;
        }

        private DbSet<tbl_UserCredit> db_UserCredits { get; set; }
        public IQueryable<tbl_UserCredit> UserCredits 
        { 
            get => db_UserCredits;
            private set => db_UserCredits = (DbSet<tbl_UserCredit>)value;
        }

        private DbSet<tbl_UserRole> db_UserRoles { get; set; }
        public IQueryable<tbl_UserRole> UserRoles 
        { 
            get => db_UserRoles;
            private set => db_UserRoles = (DbSet<tbl_UserRole>)value;
        }

        #endregion

        public BikeInventoryDbContext(DbContextOptions<BikeInventoryDbContext> dbContextOpt) 
            : base(dbContextOpt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    #region Configurations
    public partial class tbl_Bike_Configuration : BaseConfiguration<tbl_Bike> { }
    public partial class tbl_BikeModel_Configuration : BaseConfiguration<tbl_BikeModel> { }
    public partial class tbl_BikeRate_Configuration : BaseConfiguration<tbl_BikeRate> { }
    public partial class tbl_Customer_Configuration : BaseConfiguration<tbl_Customer> { }
    public partial class tbl_PaymentHandler_Configuration : BaseConfiguration<tbl_PaymentHandler> { }
    public partial class tbl_PaymentHandlerSetting_Configuration : BaseConfiguration<tbl_PaymentHandlerSetting> { }
    public partial class tbl_Receipt_Configuration : BaseConfiguration<tbl_Receipt> { }
    public partial class tbl_RentalTransaction_Configuration : BaseConfiguration<tbl_RentalTransaction> { }
    public partial class tbl_User_Configuration : BaseConfiguration<tbl_User> { }
    public partial class tbl_UserCredential_Configuration : BaseConfiguration<tbl_UserCredential> { }
    public partial class tbl_UserCredit_Configuration : BaseConfiguration<tbl_UserCredit> { }
    public partial class tbl_UserRole_Configuration : BaseConfiguration<tbl_UserRole> { }
    #endregion
}

