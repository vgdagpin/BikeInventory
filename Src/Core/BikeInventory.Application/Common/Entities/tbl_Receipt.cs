using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Application.Common.Entities
{
    public class tbl_Receipt
    {
        public int ID { get; set; }
        public Guid RentalTransactionID { get; set; }
        public string PaymentReference { get; set; }


        public tbl_RentalTransaction N_RentalTransaction { get; set; }
    }
}
