using TesteBackEnd.Domain.Dtos.Score;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface IScoreService
    {
        Task<ScoreDto> SelectAsync(Guid id);
        Task<IEnumerable<ScoreDto>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        Task<ScoreDtoCreateResult> InsertAsync(ScoreDtoCreate item);
        Task<ScoreDtoUpdateResult> UpdateAsync(ScoreDtoUpdate item);
        Task<bool> DeleteAsync(Guid id);
    }
}
