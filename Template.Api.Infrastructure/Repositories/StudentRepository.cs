using Template.Api.ApplicationCore.Entities;
using Template.Api.ApplicationCore.Intefaces;
using Template.Api.ApplicationCore.Intefaces.Repositories;

namespace Template.Api.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}