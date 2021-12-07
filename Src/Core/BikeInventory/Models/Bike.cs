using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static BikeInventory.Common.Enums;

namespace BikeInventory.Models
{
    public class Bike
    {
        public int ID { get; set; }
        public short ModelID { get; set; }
        public BikeStatus Status { get; set; } = BikeStatus.Available;
        public BikeModel Model { get; set; }
    }
}
