using Fullbar.Teste.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Fullbar.Teste.Application.Interfaces
{
    public interface IAlunoService : IDisposable
    {
        Task Adicionar(Aluno aluno);
        Task Atualizar(Aluno aluno);
        Task Remover(Guid id);
        Task<Aluno> Obter(Aluno aluno);
    }
}
