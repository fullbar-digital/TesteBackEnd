using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Models;
using AppAlunos.Data.Context;
using System.Collections.Generic;

namespace AppAlunos.Data.Repository
{
    public class CursoDisciplinaRepository : Repository<CursoDisciplina>, ICursoDisciplinaRepository
    {
        public CursoDisciplinaRepository(MeuDbContext context) : base(context)
        {
        }
        public async void AdicionarLista(List<CursoDisciplina> cursoDisciplina)
        {
            Db.CursoDisciplinas.AddRange(cursoDisciplina);
            await Db.SaveChangesAsync();
        }
    }
}
