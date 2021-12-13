using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BikeInventory.Interfaces
{
    public interface IGenericRepository<T> : IRepository where T : class
    {
        IQueryable<T> Get();
        IQueryable<T> Get(Func<T, bool> filter);

        T Find(object identity);
        Task<T> FindAsync(object identity, CancellationToken cancellationToken = default);

        T Create(T user, bool autoSave = true);
        Task<T> CreateAsync(T user, bool autoSave = true, CancellationToken cancellationToken = default);

        T Update(T user, bool autoSave = true);
        Task<T> UpdateAsync(T user, bool autoSave = true, CancellationToken cancellationToken = default);

        void Delete(T user, bool autoSave = true, CancellationToken cancellationToken = default);
        Task DeleteAsync(T user, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}
