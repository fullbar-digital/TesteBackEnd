using System.Threading.Tasks;
using ApplicationCore.Domain;
using ApplicationCore.Domain.Repositories;
using Hisoka;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ApplicationCore.Domain.Dto;

namespace ApplicationCore.Infrastructure.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly TesteBackEndContext _context;

        public StudentRepository(TesteBackEndContext dbContext)
        {
            _context = dbContext;
        }

        public async Task Save(Student student)
        {
            await _context.Set<Student>().AddAsync(student);
        }

        public async Task Update(Student student)
        {
            var studentDb = await _context.Set<Student>()
                .FirstOrDefaultAsync(x => x.Id == student.Id);

            studentDb.CourseId = student.CourseId;
            studentDb.Name = student.Name;
            studentDb.Ra = student.Ra;
            studentDb.Period = student.Period;
            studentDb.Grade = student.Grade;
            studentDb.Status = student.Status;
        }

        public async Task<IPagedList<StudentDto>> All(ResourceQueryFilter filter)
        {
            var query = await _context.Set<Student>()
                .Include(x => x.Course)
                .Query(filter)
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Ra = s.Ra,
                    Status = s.Status ? "Aprovado" : "Reprovado",
                    Course = s.Course.Name,
                    InitialDate = s.Period.Start.Value.ToString("dd/MM/yyyy"),
                    EndDate = s.Period.End.Value.ToString("dd/MM/yyyy"),
                    Grade = s.Grade
                })
                .ToPagedListAsync(q => q.CountAsync(), filter.Paginate);

            return query;
        }

        public async Task<StudentDto> FindDto(int id)
        {
            return await _context.Set<Student>()
                .Include(x => x.Course)
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Ra = s.Ra,
                    Status = s.Status ? "Aprovado" : "Reprovado",
                    CourseId = s.Course.Id,
                    InitialDate = s.Period.Start.Value.ToString("dd/MM/yyyy"),
                    EndDate = s.Period.End.Value.ToString("dd/MM/yyyy"),
                    Grade = s.Grade
                })
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student> Find(int id)
        {
            return await _context.Set<Student>()
                .Include(x => x.Course)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Delete(Student students)
        {
            _context.Remove(students);
        }

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();
    }
}