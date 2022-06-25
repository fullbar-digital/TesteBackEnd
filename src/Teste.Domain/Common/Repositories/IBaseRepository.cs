namespace Teste.Domain.Common.Repositories
{
    public interface IBaseRepository<T>
    {
        Guid Add(T entity);
        void Remove(Guid id);
        void Update(T entity);
        Task<List<T>> GetAll(bool trackChanges = false);
    }
}
