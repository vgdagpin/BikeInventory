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
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IBikeInventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override Customer Find(object identity) => Get().SingleOrDefault(a => a.ID == (int)identity);

        public override IQueryable<Customer> Get()
        {
            return m_DbContext.Customers
                .AsNoTracking()
                .ProjectTo<Customer>(m_Mapper.ConfigurationProvider);
        }
    }
}
