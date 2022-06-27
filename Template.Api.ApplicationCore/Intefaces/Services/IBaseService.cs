using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Template.Api.ApplicationCore.Intefaces.Services
{
    public interface IBaseService<T>
    {
        Task<int> AddAsync(T entity);
        Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}