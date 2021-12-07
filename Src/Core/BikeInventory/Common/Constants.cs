using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Common
{
    public abstract class Constants
    {
        public abstract class Environment
        {
            public const string Dev = "Dev";
            public const string QA = "QA";
            public const string UAT = "UAT";
            public const string Production = "Prod";
        }

        public abstract class UserRoles
        {
            public const string Admin = "admin";
            public const string Staff = "staff";
        }

        public abstract class PaymentService
        {
            public abstract class GCash
            {
                public const string HttpClientName = "PSC_GCash";
                public const string SendPayment = "SendPayment";
            }

            public abstract class Paymaya
            {
                public const string HttpClientName = "PSC_Paymaya";
            }
        }
    }
}

