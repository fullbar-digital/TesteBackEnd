using Microsoft.EntityFrameworkCore;
using Teste.Domain.Common.Entities;
using Teste.Domain.Common.Repositories;
using Teste.Infra.Data.Contexts;

namespace Teste.Infra.Data.Repositories.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly TesteContexto DbContext;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(TesteContexto dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            await DbContext.AddAsync(entity);
        }

        public async Task<List<T>> GetAll(bool trackChanges = false)
        {
            return await (trackChanges ? DbSet.ToListAsync() : DbSet.AsNoTracking().ToListAsync());
        }

        public async Task Remove(Guid id)
        {
            var objectRemove = await DbSet.FirstAsync(x => x.Id == id);

            if(objectRemove != null)
            {
                DbSet.Remove(objectRemove);
            }            
        }

        public async Task Update(T entity)
        {
            var objectUpdate = await DbSet.FirstAsync(x => x.Id == entity.Id);

            if(objectUpdate != null)
            {
                DbSet.Update(entity);
            }           
        }
    }
}
