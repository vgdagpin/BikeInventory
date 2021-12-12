using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Application.Common.Entities;

namespace BikeInventory.Infrastructure.Persistence.Configurations
{
    public partial class tbl_UserCredit_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<tbl_UserCredit> builder)
        {
            builder.HasKey(a => a.ID);
        }
    }
}
