using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    public partial class tbl_Receipt_Configuration
    {
        protected override void ConfigureProperty(BasePropertyBuilder<tbl_Receipt> builder)
        {
            builder.Property(a => a.PaymentReference)
                .IsRequired()
                .HasMaxLength(50);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<tbl_Receipt> builder)
        {
            builder.HasOne(a => a.N_RentalTransaction)
                .WithOne(a => a.N_Receipt)
                .HasForeignKey<tbl_Receipt>(a => a.RentalTransactionID);
        }
    }
}
