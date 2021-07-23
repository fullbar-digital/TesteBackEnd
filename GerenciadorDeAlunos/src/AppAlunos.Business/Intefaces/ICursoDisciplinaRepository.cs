using AppAlunos.Business.Models;
using System.Collections.Generic;

namespace AppAlunos.Business.Intefaces
{
    public interface ICursoDisciplinaRepository : IRepository<CursoDisciplina>
    {
        void AdicionarLista(List<CursoDisciplina> cursoDisciplina);
    }
}