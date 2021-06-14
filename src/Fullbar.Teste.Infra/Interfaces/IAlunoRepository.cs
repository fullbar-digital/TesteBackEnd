using Fullbar.Teste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fullbar.Teste.Infra.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> ObterAlunoCursoDisciplinas(Guid id);
        Task<IEnumerable<Aluno>> ObterAlunosCursoDisciplinas();
        Task<Aluno> Obter(Aluno aluno);
    }
}