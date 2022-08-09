using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TesteBackEnd.Domain.Dtos.Student;
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



        public async Task<IEnumerable<StudentEntity>> FilterAsync(Expression<Func<StudentEntity, bool>> predicate)
        {
            return await _context.Students
            .AsNoTracking()
            .Include(x => x.Scores).ThenInclude(d => d.Discipline)
            .Include(c => c.Course)
            .Where(predicate).ToListAsync();
        }

        public override async Task<StudentEntity?> SelectAsync(Guid id)
        {
            return await _context.Students
               .AsNoTracking()
               .Include(x => x.Scores).ThenInclude(d => d.Discipline)
               .Where(s => s.Id == id)
               .FirstOrDefaultAsync();
        }


        public override async Task<IEnumerable<StudentEntity>> SelectAsync()
        {
            return await _context.Students
               .AsNoTracking()
               .Include(x => x.Scores).ThenInclude(d => d.Discipline)
               .ToListAsync();
        }
    }
}
