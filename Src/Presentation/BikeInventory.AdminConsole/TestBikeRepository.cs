using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BikeInventory.Application.Common.Interfaces;
using BikeInventory.Application.Repositories;
using BikeInventory.Interfaces;
using BikeInventory.Models;

namespace BikeInventory.AdminConsole
{
    internal class TestBikeRepository : BikeRepository
    {
        public TestBikeRepository(IBikeInventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<Bike> GetAvailableBikes()
        {
            return base.GetAvailableBikes();
        }
    }
}
