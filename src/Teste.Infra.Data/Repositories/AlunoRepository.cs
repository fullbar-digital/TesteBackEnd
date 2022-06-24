using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Teste.Domain.Alunos.Entities;
using Teste.Domain.Alunos.Repositories;
using Teste.Infra.Data.Contexts;
using Teste.Infra.Data.Repositories.Common;

namespace Teste.Infra.Data.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public readonly TesteContexto _dbContexto;

        public AlunoRepository(TesteContexto dbContexto) : base(dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public async Task<List<Aluno>> GetByConditionAsync(Expression<Func<Aluno, bool>> expression, bool trackChanges = false)
        {
            var result = trackChanges ? DbSet.Where(expression) : DbSet.AsNoTracking().Where(expression);
            return await result.ToListAsync();            
        }
    }
}
