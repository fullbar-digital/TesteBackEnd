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

        public Guid Add(T entity)
        {
            DbContext.AddAsync(entity);
            return entity.Id;
        }

        public Task<List<T>> GetAll(bool trackChanges = false)
        {
            return trackChanges ? DbSet.ToListAsync() : DbSet.AsNoTracking().ToListAsync();
        }

        public void Remove(Guid id)
        {
            var objectRemove = DbSet.First(x => x.Id == id);

            if(objectRemove != null)
            {
                DbSet.Remove(objectRemove);
                return;
            }

            throw new ArgumentException($"Erro ao remover {typeof(T).Name}: Não encontrado! ");
        }

        public void Update(T entity)
        {
            var objectUpdate = DbSet.AsNoTracking().First(x => x.Id == entity.Id);

            if(objectUpdate != null)
            {
                DbSet.Update(entity);
                return;
            }

            throw new ArgumentException($"Erro ao alterar {typeof(T).Name}: Não encontrado! ");
        }
    }
}
