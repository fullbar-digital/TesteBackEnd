using TesteBackEnd.Domain.Dtos.Course;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDto> SelectAsync(Guid id);
        Task<IEnumerable<CourseDto>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        Task<CourseDtoCreateResult> InsertAsync(CourseDtoCreate item);
        Task<CourseDtoUpdateResult> UpdateAsync(CourseDtoUpdate item);
        Task<bool> DeleteAsync(Guid id);
    }
}
