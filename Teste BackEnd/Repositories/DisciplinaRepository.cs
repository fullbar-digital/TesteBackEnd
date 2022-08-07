using System.Linq;
using Teste_BackEnd.Interfaces;
using Teste_BackEnd.Models;

namespace Teste_BackEnd.Repositories
{
    internal class DisciplinaRepository : BaseRepository<Disciplina>, IDisciplinaRepository
    {

        public DisciplinaRepository(ApplicationContext context) : base(context)
        {

        }

        public void Add(Disciplina obj)
        {

            dbSet.Add(obj);

            context.SaveChanges();
        }

        public Disciplina GetByNome(string nome, int cursoId)
        {
            var disciplina = context
                            .Disciplinas
                            .Where(a => a.Nome == nome && a.CursoId == cursoId)
                            .FirstOrDefault();

            return disciplina;
        }
    }
}