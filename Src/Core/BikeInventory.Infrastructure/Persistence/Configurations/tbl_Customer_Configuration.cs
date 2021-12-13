using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    public partial class tbl_Customer_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<tbl_Customer> builder)
        {
            builder.HasKey(a => a.ID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<tbl_Customer> builder)
        {
            builder.Property(a => a.FirstName)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(a => a.MiddleName)
                .HasMaxLength(100);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(100);
        }

        protected override void SeedData(BaseSeeder<tbl_Customer> builder)
        {
            builder.HasData(new tbl_Customer
            {
                ID = 1,
                FirstName = "Customer",
                LastName = "A"
            });
        }
    }
}
