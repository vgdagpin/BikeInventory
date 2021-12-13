using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BikeInventory.Application.Common.Interfaces;
using BikeInventory.Application.Repositories.Base;
using BikeInventory.Interfaces;
using BikeInventory.Models;

using Microsoft.EntityFrameworkCore;

using static BikeInventory.Common.Enums;

namespace BikeInventory.Application.Repositories
{
    public class BikeRepository : GenericRepository<Bike>, IBikeRepository
    {
        public BikeRepository(IBikeInventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public virtual IEnumerable<Bike> GetAvailableBikes()
        {
            return m_DbContext.Bikes.AsNoTracking()
                .Where(a => a.Status == BikeStatus.Available)
                .ProjectTo<Bike>(m_Mapper.ConfigurationProvider)
                .ToList();
        }

        public virtual IEnumerable<Bike> GetAvailableBikesByModel(BikeModel model)
        {
            Guard.ThrowIfNull(model, nameof(model));

            return m_DbContext.Bikes.AsNoTracking()
                .Where(a => a.Status == BikeStatus.Available && a.ModelID == model.ID)
                .ProjectTo<Bike>(m_Mapper.ConfigurationProvider)
                .ToList();
        }

        public override Bike Find(object identity)
        {
            if (identity == null)
            {
                return null;
            }

            if (identity is int id)
            {
                var bike = m_DbContext.Bikes
                .Include(a => a.N_BikeRates)
                .ProjectTo<Bike>(m_Mapper.ConfigurationProvider)
                .SingleOrDefault(a => a.ID == id);

                return bike;
            }

            return null;
        }
    }
}
