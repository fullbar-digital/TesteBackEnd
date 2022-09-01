using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface IScoreRepository : IQuery<ScoreEntity>, ICommand<ScoreEntity>
    {

    }
}
