using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Template.Api.ApplicationCore.Intefaces.Repositories;
using Template.Api.ApplicationCore.Intefaces.Services;

namespace Template.Api.ApplicationCore.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public virtual async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.FindAsync(expression);
        }

        public virtual async Task<IQueryable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            return await _repository.DeleteAsync(entity);
        }
    }
}