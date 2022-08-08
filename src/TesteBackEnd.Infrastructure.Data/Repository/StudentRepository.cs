using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Infrastructure.Data.Context;

namespace TesteBackEnd.Infrastructure.Data.Repository
{
    public class StudentRepository : BaseRepository<StudentEntity>, IStudentRepository
    {


        public StudentRepository(TesteBackEndDbContext context) : base(context)
        {

        }

        public virtual async Task<IEnumerable<StudentEntity>> SelectAsync()
        {
            return await _context.Students
               .AsNoTracking()
               .Include(x => x.Scores)
               .ToListAsync();
        }

        public async Task<IEnumerable<StudentEntity>> SelectAsync(Expression<Func<StudentEntity, bool>> predicado)
        {
            return await _context.Students.AsNoTracking().Where(predicado).ToListAsync();
        }
    }
}
