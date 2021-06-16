namespace School_Manager.Persistence
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using School_Manager.Domain;
    public class SchoolPersistence : ISchool
    {
        private readonly DataContext context;

        public SchoolPersistence(DataContext _context)
        {

            context = _context;
        }

        public async Task<Aluno> GetAllAlunoByNomeAsync(string nome)
        {
            IQueryable<Aluno> query = context.Alunos
             .Include(a => a.Curso)
             .ThenInclude(c => c.Disciplinas);
            query = query.OrderBy(a => a.Nome)
                         .Where(a => a.Nome.ToLower().Contains(nome.ToLower()));

            return await query.FirstOrDefaultAsync();
        }
         public async Task<Aluno> GetAllAlunoByIDAsync(int id)
        {
            IQueryable<Aluno> query = context.Alunos
             .Include(a => a.Curso)
             .ThenInclude(c => c.Disciplinas);
            query = query.Where(a => a.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno> GetAllAlunoByRAAsync(int ra)
        {
            IQueryable<Aluno> query = context.Alunos
          .Include(a => a.Curso)
          .ThenInclude(c => c.Disciplinas);
            query = query.OrderBy(a => a.Nome)
                         .Where(a => a.RA == ra);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> GetAllAlunosAsync()
        {
            IQueryable<Aluno> query = context.Alunos
                        .Include(a => a.Curso)
                        .ThenInclude(c => c.Disciplinas);
            query = query.OrderBy(a => a.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno[]> GetAllAlunosByStatusAsync(bool status)
        {
            IQueryable<Aluno> query = context.Alunos
            .Include(a => a.Curso)
            .ThenInclude(c => c.Disciplinas);
            query = query.OrderBy(a => a.Nome)
                .Where(a => a.GetStatus() == status);

            return await query.ToArrayAsync();
        }

        public async Task<Curso[]> GetAllCursosAsync()
        {
            IQueryable<Curso> query = context.Cursos
                       .Include(c => c.Disciplinas)
;

            query = query.OrderBy(c => c.Nome);
            return await query.ToArrayAsync();
        }

        public async Task<Curso> GetAllCursoByIDAsync(int id)
        {
            
            IQueryable<Curso> query = context.Cursos;

            query = query.OrderBy(d => d.Nome).Where(d => d.Id == id);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Diciplina[]> GetAllDiciplinasAsync()
        {
            IQueryable<Diciplina> query = context.Diciplinas;

            query = query.OrderBy(d => d.Nome);
            return await query.ToArrayAsync();
        }

        public async Task<Diciplina> GetAllDiciplinaByIDAsync(int id)
        {
            IQueryable<Diciplina> query = context.Diciplinas;

            query = query.OrderBy(d => d.Nome).Where(d => d.Id == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}