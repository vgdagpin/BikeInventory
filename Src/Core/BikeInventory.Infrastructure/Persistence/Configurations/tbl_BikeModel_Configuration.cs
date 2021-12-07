using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    public partial class tbl_BikeModel_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<tbl_BikeModel> builder)
        {
            builder.HasKey(a => a.ID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<tbl_BikeModel> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);
        }

        protected override void SeedData(BaseSeeder<tbl_BikeModel> builder)
        {
            builder.HasData(new tbl_BikeModel
            {
                ID = 1,
                Name = "A1"
            });

            builder.HasData(new tbl_BikeModel
            {
                ID = 2,
                Name = "A2"
            });

            builder.HasData(new tbl_BikeModel
            {
                ID = 3,
                Name = "A3"
            });
        }
    }
}
