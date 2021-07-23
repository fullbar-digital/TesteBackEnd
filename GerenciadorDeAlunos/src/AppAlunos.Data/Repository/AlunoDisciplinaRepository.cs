using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Models;
using AppAlunos.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAlunos.Data.Repository
{
    public class AlunoDisciplinaRepository : Repository<AlunoDisciplina>, IAlunoDisciplinaRepository
    {
        public AlunoDisciplinaRepository(MeuDbContext context) : base(context)
        {
        }
        public async void AdicionarLista(List<AlunoDisciplina> alunoDisciplina)
        {
           Db.AlunoDisciplinas.AddRange(alunoDisciplina);
           await SaveChanges();
        }

        public async Task RemoverLista(IEnumerable<AlunoDisciplina> alunoDisciplinas)
        {
            Db.AlunoDisciplinas.RemoveRange(alunoDisciplinas);
            await SaveChanges();
        }
    }
}
