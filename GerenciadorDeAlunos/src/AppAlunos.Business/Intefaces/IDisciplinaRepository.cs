using AppAlunos.Business.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppAlunos.Business.Intefaces
{
    public interface IDisciplinaRepository : IRepository<Disciplina>
    {
        IQueryable<Disciplina> BuscarPorNomes(IEnumerable<string> nomes);
    }
}