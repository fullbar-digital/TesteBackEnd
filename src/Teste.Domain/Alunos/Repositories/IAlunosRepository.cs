using Teste.Domain.Alunos.Dto;
using Teste.Domain.Alunos.Entities;

namespace Teste.Domain.Alunos.Repositories
{
    public interface IAlunoRepository
    {
        Guid Inserir(Aluno entity);
        void Remover(Guid id);
        void Alterar(Aluno entity);
        Task<List<Aluno>> ObterTodos();
        Task<List<Aluno>> GetByConditionAsync(FilterAlunoDto filterAluno);
    }
}
