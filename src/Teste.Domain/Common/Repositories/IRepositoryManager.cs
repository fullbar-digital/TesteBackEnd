using Teste.Domain.Alunos.Repositories;
using Teste.Domain.Cursos.Repositories;
using Teste.Domain.Disciplinas.Repositories;

namespace Teste.Domain.Common.Repositories
{
    public interface IRepositoryManager
    {
        public IDisciplinaRepository DisciplinaRepository { get; set; }
        public ICursoRepository CursoRepository { get; set; }
        public IAlunoRepository AlunoRepository { get; set; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
