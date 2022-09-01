using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface IDisciplineRepository : IQuery<DisciplineEntity>, ICommand<DisciplineEntity>
    {

    }
}
