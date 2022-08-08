using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface IDisciplineRepository
    {
        Task<DisciplineEntity> SelectAsync(Guid id);
        Task<IEnumerable<DisciplineEntity>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        Task<DisciplineEntity> InsertAsync(DisciplineEntity item);
        Task<DisciplineEntity> UpdateAsync(DisciplineEntity item);
        Task<bool> DeleteAsync(Guid id);
    }
}
