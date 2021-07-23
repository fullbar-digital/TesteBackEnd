using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Models;
using AppAlunos.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace AppAlunos.Data.Repository
{
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(MeuDbContext context) : base(context)
        {
        }

        public IQueryable<Disciplina> BuscarPorNomes(IEnumerable<string> nomes)
        {
            return Db.Disciplinas.Where(x => nomes.Contains(x.Nome));
        }
    }
}
