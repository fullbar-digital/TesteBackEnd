using System.Linq.Expressions;
using TesteBackEnd.Domain.Dtos.Student;
using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface IStudentRepository : IQuery<StudentEntity>, ICommand<StudentEntity>
    {
        Task<IEnumerable<StudentEntity>> FilterAsync(Expression<Func<StudentEntity, bool>> predicado);
    }
}
