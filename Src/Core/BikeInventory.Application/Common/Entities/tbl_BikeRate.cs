using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Application.Common.Entities
{
    public class tbl_BikeRate
    {
        public int ID { get; set; }
        public int BikeID { get; set; }
        public decimal RatePerMinute { get; set; }

        public DateTime EffectiveStartDate { get; set; }
        public DateTime? EffectiveEndDate { get; set; }

        public tbl_Bike N_Bike { get; set; }
    }
}
