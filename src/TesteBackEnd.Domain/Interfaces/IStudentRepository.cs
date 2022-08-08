using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<StudentEntity> SelectAsync(Guid id);
        Task<IEnumerable<StudentEntity>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        Task<StudentEntity> InsertAsync(StudentEntity item);
        Task<StudentEntity> UpdateAsync(StudentEntity item);
        Task<bool> DeleteAsync(Guid id);
    }
}