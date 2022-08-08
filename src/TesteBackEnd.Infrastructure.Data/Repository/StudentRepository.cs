using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Infrastructure.Data.Context;

namespace TesteBackEnd.Infrastructure.Data.Repository
{
    public class StudentRepository : BaseRepository<StudentEntity>, IStudentRepository
    {
        protected StudentRepository(TesteBackEndDbContext context) : base(context)
        {
        }
    }
}