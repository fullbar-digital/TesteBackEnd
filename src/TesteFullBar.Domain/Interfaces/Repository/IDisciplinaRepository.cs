using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Domain.Interfaces.Repository
{
    public interface IDisciplinaRepository : IEntityBaseRepository<Disciplina>, IDapperReadRepository<Disciplina>
    {
        Task<Disciplina> GetByDescricaoAsync(string descricao);

        Task<IEnumerable<Disciplina>> GetAll();

        IEnumerable<Disciplina> GetByIdsAsync(List<int> ids);

        
    }
}
