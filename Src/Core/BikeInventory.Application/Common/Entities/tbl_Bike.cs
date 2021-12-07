using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static BikeInventory.Common.Enums;

namespace BikeInventory.Application.Common.Entities
{
    public class tbl_Bike
    {
        public int ID { get; set; }
        public short ModelID { get; set; }
        public BikeStatus Status { get; set; } = BikeStatus.Available;


        public tbl_BikeModel N_Model { get; set; }
        public ICollection<tbl_RentalTransaction> N_RentalTransactions { get; set; } = new HashSet<tbl_RentalTransaction>();
        public ICollection<tbl_BikeRate> N_BikeRates { get; set; } = new HashSet<tbl_BikeRate>();

    }
}
