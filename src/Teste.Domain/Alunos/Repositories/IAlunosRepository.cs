using System.Linq.Expressions;
using Teste.Domain.Alunos.Entities;

namespace Teste.Domain.Alunos.Repositories
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>> GetByConditionAsync(Expression<Func<Aluno,bool>> expression, bool trackChanges = false);
    }
}
