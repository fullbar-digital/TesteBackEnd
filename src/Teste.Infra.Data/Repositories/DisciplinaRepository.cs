using Teste.Domain.Disciplinas.Entities;
using Teste.Domain.Disciplinas.Repositories;
using Teste.Infra.Data.Contexts;
using Teste.Infra.Data.Repositories.Common;

namespace Teste.Infra.Data.Repositories
{
    public class DisciplinaRepository : BaseRepository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(TesteContexto dbContexto) : base(dbContexto)
        {
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
            return GetAll();
        }

        public void Remover(Guid id)
        {
            Remove(id);
        }
    }
}
