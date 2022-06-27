using Teste.Domain.Cursos.Entitites;

namespace Teste.Domain.Cursos.Repositories
{
    public interface ICursoRepository
    {
        Guid Inserir(Curso entity);
        void Remover(Guid id);
        void Alterar(Curso entity);
        Task<List<Curso>> ObterTodos();
    }
}
