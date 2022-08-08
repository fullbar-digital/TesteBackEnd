using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Infrastructure.Data.Context;

namespace TesteBackEnd.Infrastructure.Data.Repository
{
    public class ScoreRepository : BaseRepository<ScoreEntity>, IScoreRepository
    {
        public ScoreRepository(TesteBackEndDbContext context) : base(context)
        {
        }
    }
}
