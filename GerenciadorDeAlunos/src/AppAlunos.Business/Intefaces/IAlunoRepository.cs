using AppAlunos.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAlunos.Business.Intefaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task RemoverAsync(Guid id);
        List<Aluno> RetornarAlunosCursoDisciplina();
        List<Aluno> RetornarAlunosFiltro(string filtro, string valor);
    }
}