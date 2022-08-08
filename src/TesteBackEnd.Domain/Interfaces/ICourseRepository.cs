using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<CourseEntity> SelectAsync(Guid id);
        Task<IEnumerable<CourseEntity>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        Task<CourseEntity> InsertAsync(CourseEntity item);
        Task<CourseEntity> UpdateAsync(CourseEntity item);
        Task<bool> DeleteAsync(Guid id);
    }
}
