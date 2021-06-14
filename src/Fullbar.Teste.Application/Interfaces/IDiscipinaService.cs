using Fullbar.Teste.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Fullbar.Teste.Application.Interfaces
{
    public interface IDisciplinaService : IDisposable
    {
        Task Adicionar(Disciplina disciplina);
        Task Atualizar(Disciplina disciplina);
        Task Remover(Guid id);
    }
}