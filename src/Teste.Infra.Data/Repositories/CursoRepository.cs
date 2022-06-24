using Teste.Domain.Cursos.Entitites;
using Teste.Domain.Cursos.Repositories;
using Teste.Infra.Data.Contexts;
using Teste.Infra.Data.Repositories.Common;

namespace Teste.Infra.Data.Repositories
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(TesteContexto dbContexto) : base(dbContexto)
        {
        }
    }
}
