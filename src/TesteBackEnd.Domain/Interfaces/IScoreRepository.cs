using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface IScoreRepository
    {
        Task<ScoreEntity> SelectAsync(Guid id);
        Task<IEnumerable<ScoreEntity>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        Task<ScoreEntity> InsertAsync(ScoreEntity item);
        Task<ScoreEntity> UpdateAsync(ScoreEntity item);
        Task<bool> DeleteAsync(Guid id);
    }
}
