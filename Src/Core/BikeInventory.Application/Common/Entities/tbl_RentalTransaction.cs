using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Application.Common.Entities
{
    public class tbl_RentalTransaction
    {
        public Guid ID { get; set; }
        public int BikeID { get; set; }
        public int BikeRateID { get; set; }
        public int AttendantID { get; set; }
        public int CustomerID { get; set; }
        public DateTime CheckedOut { get; set; }
        public DateTime? CheckedIn { get; set; }

        public tbl_Bike N_Bike { get; set; }
        public tbl_BikeRate N_BikeRate { get; set; }
        public tbl_User N_Attendant { get; set; }
        public tbl_Customer N_Customer { get; set; }
        public tbl_Receipt N_Receipt { get; set; }
    }
}