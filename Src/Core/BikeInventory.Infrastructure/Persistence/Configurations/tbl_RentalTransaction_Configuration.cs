using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;

using Microsoft.EntityFrameworkCore;

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    public partial class tbl_RentalTransaction_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<tbl_RentalTransaction> builder)
        {
            builder.HasKey(a => a.ID);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<tbl_RentalTransaction> builder)
        {
            builder.HasOne(a => a.N_Attendant)
                .WithMany()
                .HasForeignKey(a => a.AttendantID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.N_Bike)
                .WithMany(a => a.N_RentalTransactions)
                .HasForeignKey(a => a.BikeID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.N_BikeRate)
                .WithMany()
                .HasForeignKey(a => a.BikeRateID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.N_Customer)
                .WithMany(a => a.N_RentalTransactions)
                .HasForeignKey(a => a.CustomerID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
