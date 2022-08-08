using System.Linq.Expressions;
using TesteBackEnd.Domain.Dtos.Student;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> SelectAsync(Guid id);
        Task<IEnumerable<StudentDto>> SelectAsync();
        Task<IEnumerable<StudentDto>> SelectAsync(Expression<Func<StudentDto, bool>> predicado);
        Task<bool> ExistAsync(Guid id);
        Task<StudentDtoCreateResult> InsertAsync(StudentDtoCreate item);
        Task<StudentDtoUpdateResult> UpdateAsync(StudentDtoUpdate item);
        Task<bool> DeleteAsync(Guid id);
    }
}
