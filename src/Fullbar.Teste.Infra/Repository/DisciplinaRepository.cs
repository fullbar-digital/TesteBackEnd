using Fullbar.Teste.Domain.Entities;
using Fullbar.Teste.Infra.Context;
using Fullbar.Teste.Infra.Interfaces;

namespace Fullbar.Teste.Infra.Repository
{
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(MeuDbContext context) : base(context)
        {
        }
    }
}
