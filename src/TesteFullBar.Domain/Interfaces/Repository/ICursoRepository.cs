using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Domain.Interfaces.Repository
{
    public interface ICursoRepository : IEntityBaseRepository<Curso>, IDapperReadRepository<Curso>
    {
        Task<Curso> GetByDescricaoAsync(string descricao);

        Task<IEnumerable<Curso>> GetAll();
    }
}
