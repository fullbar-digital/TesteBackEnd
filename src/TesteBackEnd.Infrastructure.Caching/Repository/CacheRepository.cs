using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.Redis;
using TesteBackEnd.Infrastructure.Caching.Interfaces;
using TesteBackEnd.Insfrastructure.Caching;

namespace TesteBackEnd.Infrastructure.Caching.Repository
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IRedisClientsManager _clientsManager;
        public string prefix = "key_";
        public CacheRepository(IRedisClientsManager clientsManager)
        {
            _clientsManager = clientsManager;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            await using (var client = await _clientsManager.GetClientAsync())
            {
                var obj = client.RemoveAsync(prefix + id);
                return true;
            }
        }

        public async Task<bool> ExistAsync(string key)
        {
            await using (var client = await _clientsManager.GetClientAsync())
            {
                var obj = await client.GetAsync<Cache>(prefix + key);
                return obj != null;
            }
        }

        public async Task<Cache> InsertAsync(Cache item)
        {
            await using (var client = await _clientsManager.GetClientAsync())
            {
                await client.SetAsync<Cache>(prefix + item.Key, item);
                return item;
            }
        }

        public async Task<Cache> SelectAsync(string key)
        {
            await using (var client = await _clientsManager.GetClientAsync())
            {
                var obj = await client.GetAsync<Cache>(prefix + key);
                return obj;
            }
        }

        public async Task<IEnumerable<Cache>> SelectAsync()
        {
            await using (var client = await _clientsManager.GetClientAsync())
            {
                var keys = await client.GetAllKeysAsync();
                var list = new List<Cache>();
                foreach (var key in keys)
                    list.Add(await client.GetAsync<Cache>(key));
                return list;
            }
        }

        public async Task<Cache> UpdateAsync(Cache item)
        {
            await using (var client = await _clientsManager.GetClientAsync())
            {
                await client.SetAsync<Cache>(prefix + item.Key, item);
                return item;
            }

        }
    }
}
