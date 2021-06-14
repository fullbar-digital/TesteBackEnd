using Fullbar.Teste.Domain.Entities;
using Fullbar.Teste.Infra.Context;
using Fullbar.Teste.Infra.Interfaces;

namespace Fullbar.Teste.Infra.Repository
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(MeuDbContext context) : base(context)
        {
        }
    }
}