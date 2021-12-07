using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Application.Common.Entities
{
    public class tbl_Customer
    {
        public int ID { get; set; }

        public tbl_User N_User { get; set; }
        public ICollection<tbl_RentalTransaction> N_RentalTransactions { get; set; } = new HashSet<tbl_RentalTransaction>();
    }
}
