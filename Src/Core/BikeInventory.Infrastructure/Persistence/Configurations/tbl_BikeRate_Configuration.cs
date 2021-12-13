using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;

using static BikeInventory.Infrastructure.Constants;

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    public partial class tbl_BikeRate_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<tbl_BikeRate> builder)
        {
            builder.HasKey(a => a.ID);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<tbl_BikeRate> builder)
        {
            builder.HasOne(a => a.N_Bike)
                .WithMany(a => a.N_BikeRates)
                .HasForeignKey(a => a.BikeID);
        }

        protected override void SeedData(BaseSeeder<tbl_BikeRate> builder)
        {
            for (int i = 1; i <= 20; i++)
            {
                builder.HasData(new tbl_BikeRate
                {
                    ID = i,
                    BikeID = i,
                    IsActive = true,
                    RatePerMinute = 0.25m,
                });
            }
        }
    }
}