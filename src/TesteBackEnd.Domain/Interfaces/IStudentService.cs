using System.Linq.Expressions;
using TesteBackEnd.Domain.Dtos.Student;
using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> SelectAsync(Guid id);
        Task<IEnumerable<StudentDto>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        Task<StudentDtoCreateResult> InsertAsync(StudentDtoCreate item);
        Task<StudentDtoUpdateResult> UpdateAsync(Guid id, StudentDtoUpdate item);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<StudentDto>> FilterAsync(Expression<Func<StudentEntity, bool>> predicado);
    }
}
