using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackEnd.Insfrastructure.Caching;

namespace TesteBackEnd.Infrastructure.Caching.Interfaces
{
    public interface ICacheRepository
    {
        Task<Cache> InsertAsync(Cache item);
        Task<Cache> UpdateAsync(Cache item);
        Task<bool> DeleteAsync(string id);
        Task<Cache> SelectAsync(string id);
        Task<IEnumerable<Cache>> SelectAsync();
        Task<bool> ExistAsync(string id);
    }
}
