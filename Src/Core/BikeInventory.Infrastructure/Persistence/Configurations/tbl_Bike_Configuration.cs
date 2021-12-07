using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;

using static BikeInventory.Common.Enums;

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    public partial class tbl_Bike_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<tbl_Bike> builder)
        {
            builder.HasKey(a => a.ID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<tbl_Bike> builder)
        {
            builder.Property(a => a.Status)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(50);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<tbl_Bike> builder)
        {
            builder.HasOne(a => a.N_Model)
                .WithMany(a => a.N_Bikes)
                .HasForeignKey(a => a.ModelID);
        }

        protected override void SeedData(BaseSeeder<tbl_Bike> builder)
        {
            for (int i = 1; i <= 5; i++)
            {
                builder.HasData(new tbl_Bike
                {
                    ID = i,
                    ModelID = 1,
                    Status = BikeStatus.Available
                });
            }

            for (int i = 6; i <= 10; i++)
            {
                builder.HasData(new tbl_Bike
                {
                    ID = i,
                    ModelID = 2,
                    Status = BikeStatus.Available
                });
            }

            for (int i = 11; i <= 20; i++)
            {
                builder.HasData(new tbl_Bike
                {
                    ID = i,
                    ModelID = 3,
                    Status = BikeStatus.Available
                });
            }
        }
    }
}
