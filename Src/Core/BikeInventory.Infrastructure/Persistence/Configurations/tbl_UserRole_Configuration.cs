using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;
using BikeInventory.Common;

using static BikeInventory.Common.Constants;

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    public partial class tbl_UserRole_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<tbl_UserRole> builder)
        {
            builder.HasKey(a => new
            {
                a.UserID,
                a.Role
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<tbl_UserRole> builder)
        {
            builder.Property(a => a.Role)
                .IsRequired()
                .HasMaxLength(10);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<tbl_UserRole> builder)
        {
            builder.HasOne<tbl_User>()
                .WithMany(a => a.N_UserRoles)
                .HasForeignKey(a => a.UserID);
        }

        protected override void SeedData(BaseSeeder<tbl_UserRole> builder)
        {
            builder.HasData(new tbl_UserRole
            {
                UserID = -1,
                Role = UserRoles.Admin
            });

            builder.HasData(new tbl_UserRole
            {
                UserID = 1,
                Role = UserRoles.Staff
            });

            builder.HasData(new tbl_UserRole
            {
                UserID = 2,
                Role = UserRoles.Staff
            });
        }
    }
}
