using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Infrastructure
{
    public abstract class Constants : BikeInventory.Common.Constants
    {

        public abstract class SchemaConstant
        {
            public const string Admin = "adm";
        }

        public abstract class SeedDataHelper
        {
            public static DateTime Now => new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        }
    }
}

