using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using BikeInventory.Application.Common.Interfaces;
using BikeInventory.Interfaces;

namespace BikeInventory.Application.Repositories.Base
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal readonly IBikeInventoryDbContext m_DbContext;
        internal readonly IMapper m_Mapper;

        protected GenericRepository(IBikeInventoryDbContext dbContext, IMapper mapper)
        {
            m_DbContext = dbContext;
            m_Mapper = mapper;
        }

        public virtual T Create(T user, bool autoSave = true)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> CreateAsync(T user, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T user, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync(T user, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual T Find(object identity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> FindAsync(object identity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> Get()
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> Get(Func<T, bool> filter)
        {
            var query = Get();

            if (filter != null)
            {
                return query.Where(filter).AsQueryable();
            }

            return query;
        }

        public virtual T Update(T user, bool autoSave = true)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> UpdateAsync(T user, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
