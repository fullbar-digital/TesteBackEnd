using Microsoft.EntityFrameworkCore;
using System.Linq;
using Teste_BackEnd.Interfaces;
using Teste_BackEnd.Models;

namespace Teste_BackEnd.Repositories
{
    internal class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(ApplicationContext context) : base(context)
        {

        }

        public void Add(Curso obj)
        {
            dbSet.Add(obj);
            context.SaveChanges();
        }

        public Curso GetByNome(string nome)
        {
            var curso = context
                        .Cursos
                        .Include(d => d.Disciplinas)
                        .Where(a => a.Nome == nome)
                        .FirstOrDefault();

            return curso;
        }
    }
}