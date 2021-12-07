using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static BikeInventory.Common.Enums;

namespace BikeInventory.Models
{
    public class BikeModel
    {
        public short ID { get; set; }
        public string Name { get; set; }

        public IEnumerable<Bike> Bikes { get; set; } = Enumerable.Empty<Bike>();

        public bool GetHasAvailableBikes() => Bikes != null && Bikes.Any(a => a.Status == BikeStatus.Available);
    }
}
