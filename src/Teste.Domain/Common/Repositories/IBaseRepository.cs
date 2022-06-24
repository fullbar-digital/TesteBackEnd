namespace Teste.Domain.Common.Repositories
{
    public interface IBaseRepository<T>
    {
        Task Add(T entity);
        Task Remove(Guid id);
        Task Update(T entity);
        Task<List<T>> GetAll(bool trackChanges = false);
    }
}
