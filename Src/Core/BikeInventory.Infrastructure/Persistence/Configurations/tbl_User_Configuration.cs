using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    public partial class tbl_User_Configuration
    {
        protected override void ConfigureProperty(BasePropertyBuilder<tbl_User> builder)
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

        protected override void SeedData(BaseSeeder<tbl_User> builder)
        {
            builder.HasData(new tbl_User
            {
                ID = -1,
                FirstName = "Super",
                LastName = "Admin"
            });

            builder.HasData(new tbl_User
            {
                ID = 1,
                FirstName = "User",
                LastName = "Staff 1"
            });

            builder.HasData(new tbl_User
            {
                ID = 2,
                FirstName = "User",
                LastName = "Staff 2"
            });
        }
    }
}

