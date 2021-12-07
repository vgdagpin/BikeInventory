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

        protected override void ConfigureRelationship(BaseRelationshipBuilder<tbl_Customer> builder)
        {
            builder.HasOne(a => a.N_User)
                .WithOne()
                .HasForeignKey<tbl_Customer>(a => a.ID);
        }
    }
}
