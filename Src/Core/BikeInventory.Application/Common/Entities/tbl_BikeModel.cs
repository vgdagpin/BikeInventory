using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeInventory.Application.Common.Entities
{
    public class tbl_BikeModel
    {
        public short ID { get; set; }
        public string Name { get; set; }

        public ICollection<tbl_Bike> N_Bikes { get; set; } = new HashSet<tbl_Bike>();
    }
}
