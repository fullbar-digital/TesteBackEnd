using Microsoft.EntityFrameworkCore;
using Teste.Domain.Disciplinas.Entities;
using Teste.Domain.Disciplinas.Repositories;
using Teste.Infra.Data.Contexts;
using Teste.Infra.Data.Repositories.Common;

namespace Teste.Infra.Data.Repositories
{
    public class DisciplinaRepository : BaseRepository<Disciplina>, IDisciplinaRepository
    {
        public readonly TesteContexto _dbContexto;

        public DisciplinaRepository(TesteContexto dbContexto) : base(dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public void Alterar(Disciplina entity)
        {
            Update(entity);
        }

        public Guid Inserir(Disciplina entity)
        {
            return Add(entity);         
        }

        public Task<List<Disciplina>> ObterTodos()
        {
            return _dbContexto.Disciplinas.Include(x => x.Curso).ToListAsync();
        }

        public void Remover(Guid id)
        {
            Remove(id);
        }
    }
}
