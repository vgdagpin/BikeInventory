﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeInventory.Models;

namespace BikeInventory.Interfaces
{
    public interface IBikeRepository : IGenericRepository<Bike>
    {
        IEnumerable<Bike> GetAvailableBikes();
        IEnumerable<Bike> GetAvailableBikesByModel(BikeModel model);
    }
}