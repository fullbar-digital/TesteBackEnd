using System.Linq.Expressions;
using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<StudentEntity> SelectAsync(Guid id);
        Task<IEnumerable<StudentEntity>> SelectAsync();
        Task<IEnumerable<StudentEntity>> Find(Expression<Func<StudentEntity, bool>> predicado);
        Task<bool> ExistAsync(Guid id);
        Task<StudentEntity> InsertAsync(StudentEntity item);
        Task<StudentEntity> UpdateAsync(StudentEntity item);
        Task<bool> DeleteAsync(Guid id);
    }
}
