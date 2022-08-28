using System.Linq.Expressions;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Infrastructure.Caching.Interfaces;
using TesteBackEnd.Infrastructure.Data.Context;

namespace TesteBackEnd.Infrastructure.Data.Repository
{
    public class BaseRepository<T> : IQuery<T>, ICommand<T> where T : BaseEntity
    {
        protected readonly TesteBackEndDbContext _context;
        protected DbSet<T> _dataSet;
        protected BaseRepository(TesteBackEndDbContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataSet.AnyAsync(p => p.Id.Equals(id));
        }

        public virtual async Task<T> SelectAsync(Guid id)
        {
            return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public virtual async Task<IEnumerable<T>> SelectAsync() => await _dataSet.ToListAsync();

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _dataSet.Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }
                entity.CreatedAt = DateTime.UtcNow;
                _dataSet.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _dataSet.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
