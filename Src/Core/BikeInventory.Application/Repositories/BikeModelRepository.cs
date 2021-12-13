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

namespace BikeInventory.Application.Repositories
{
    public class BikeModelRepository : GenericRepository<BikeModel>, IBikeModelRepository
    {
        public BikeModelRepository(IBikeInventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IQueryable<BikeModel> Get()
        {
            return m_DbContext.BikeModels
               .AsNoTracking()
               .Include(a => a.N_Bikes.OrderBy(b => b.ID)).ThenInclude(a => a.N_BikeRates)
               .ProjectTo<BikeModel>(m_Mapper.ConfigurationProvider);
        }
    }
}
