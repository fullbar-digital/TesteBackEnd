using System.Collections.Generic;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Domain.Interfaces.Repository
{
    public interface IAlunoDisciplinaRepository : IEntityBaseRepository<AlunoDisciplina>, IDapperReadRepository<AlunoDisciplina>
    {
        IEnumerable<AlunoDisciplina> GetByAlunoIdAsync(int alunoId);
    }
}
