using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Models;
using AppAlunos.Data.Context;
using System.Linq;

namespace AppAlunos.Data.Repository
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(MeuDbContext context) : base(context)
        {
            
        }

        public Curso BuscarPorNome(string nome)
        {
            return Db.Cursos.FirstOrDefault(c => c.Nome == nome);
        }

    }
}
