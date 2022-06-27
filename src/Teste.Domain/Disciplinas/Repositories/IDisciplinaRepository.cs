using Teste.Domain.Disciplinas.Entities;

namespace Teste.Domain.Disciplinas.Repositories
{
    public interface IDisciplinaRepository
    {
        Guid Inserir(Disciplina entity);
        void Remover(Guid id);
        void Alterar(Disciplina entity);
        Task<List<Disciplina>> ObterTodos();
    }
}
