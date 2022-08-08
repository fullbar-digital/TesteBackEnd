using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Infrastructure.Data.Context;

namespace TesteBackEnd.Infrastructure.Data.Repository
{
    public class DisciplineRepository : BaseRepository<DisciplineEntity>, IDisciplineRepository
    {
        public DisciplineRepository(TesteBackEndDbContext context) : base(context)
        {
        }
    }
}
