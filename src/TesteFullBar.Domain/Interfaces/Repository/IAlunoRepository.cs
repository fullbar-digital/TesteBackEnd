using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.Domain.Models;
using TesteFullBar.Domain.Models.Dapper;

namespace TesteFullBar.Domain.Interfaces.Repository
{
    public interface IAlunoRepository : IEntityBaseRepository<Aluno>, IDapperReadRepository<Aluno>
    {
        Task<Aluno> GetByRaAsync(string ra);

        Task<IEnumerable<AlunoQuery>> GetByFilterAsync(string ra, string nome, int? curso, string status);
    }
}
