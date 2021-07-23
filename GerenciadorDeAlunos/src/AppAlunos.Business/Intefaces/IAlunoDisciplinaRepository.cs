using AppAlunos.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAlunos.Business.Intefaces
{
    public interface IAlunoDisciplinaRepository : IRepository<AlunoDisciplina>
    {
        void AdicionarLista(List<AlunoDisciplina> alunoDisciplina);
        Task RemoverLista(IEnumerable<AlunoDisciplina> alunoDisciplinas);
    }
}