using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Application.Common.Entities
{
    public class tbl_UserCredit
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string RecordStatus { get; set; }
        public decimal Credit { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
