using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;
using BikeInventory.Infrastructure.Common;

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    public partial class tbl_UserCredential_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<tbl_UserCredential> builder)
        {
            builder.HasKey(a => a.ID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<tbl_UserCredential> builder)
        {
            builder.Property(a => a.TemporaryPassword)
                .HasMaxLength(100);

            builder.Property(a => a.Username)
                .IsRequired()
                .HasMaxLength(200);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<tbl_UserCredential> builder)
        {
            builder.HasOne<tbl_User>()
                .WithOne(a => a.N_UserCredential)
                .HasForeignKey<tbl_UserCredential>(a => a.ID);
        }

        protected override void SeedData(BaseSeeder<tbl_UserCredential> builder)
        {
            var hasher = new PasswordHasher();

            var salt1 = Encoding.ASCII.GetBytes(Guid.Empty.Increment(1).ToString());
            builder.HasData(new tbl_UserCredential
            {
                ID = -1,
                Username = "admin@bike.com",
                IsTemporaryPassword=true,
                TemporaryPassword = "admin",
                Salt = salt1,
                Password = hasher.HashPassword(salt1, "admin")
            });

            var salt2 = Encoding.ASCII.GetBytes(Guid.Empty.Increment(2).ToString());
            builder.HasData(new tbl_UserCredential
            {
                ID = 1,
                Username = "staff1@bike.com",
                IsTemporaryPassword = true,
                TemporaryPassword = "staff1",
                Salt = salt2,
                Password = hasher.HashPassword(salt2, "staff1")
            });

            var salt3 = Encoding.ASCII.GetBytes(Guid.Empty.Increment(2).ToString());
            builder.HasData(new tbl_UserCredential
            {
                ID = 2,
                Username = "staff2@bike.com",
                IsTemporaryPassword = true,
                TemporaryPassword = "staff2",
                Salt = salt3,
                Password = hasher.HashPassword(salt3, "staff2")
            });
        }
    }
}
