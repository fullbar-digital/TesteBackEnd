using Fullbar.Teste.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Fullbar.Teste.Application.Interfaces
{
    public interface ICursoService : IDisposable
    {
        Task Adicionar(Curso curso);
        Task Atualizar(Curso curso);
        Task Remover(Guid id);
    }
}
