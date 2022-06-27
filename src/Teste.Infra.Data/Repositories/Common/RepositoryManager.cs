using Teste.Domain.Alunos.Repositories;
using Teste.Domain.Common.Repositories;
using Teste.Domain.Cursos.Repositories;
using Teste.Domain.Disciplinas.Repositories;
using Teste.Infra.Data.Contexts;

namespace Teste.Infra.Data.Repositories.Common
{
    public class RepositoryManager : IRepositoryManager
    {
        public IDisciplinaRepository DisciplinaRepository { get; set; }
        public ICursoRepository CursoRepository { get; set; }
        public IAlunoRepository AlunoRepository { get; set; }

        public readonly TesteContexto DbContexto;

        public RepositoryManager(TesteContexto dbContext, IDisciplinaRepository disciplinaRepository, ICursoRepository cursoRepository, IAlunoRepository alunoRepository)
        {
            DbContexto = dbContext;
            DisciplinaRepository = disciplinaRepository;
            CursoRepository = cursoRepository;
            AlunoRepository = alunoRepository;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await DbContexto.SaveChangesAsync(cancellationToken);
        }
    }
}
