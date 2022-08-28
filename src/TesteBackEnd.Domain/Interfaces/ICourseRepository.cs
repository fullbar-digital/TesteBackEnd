using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface ICourseRepository : ICommand<CourseEntity>, IQuery<CourseEntity>
    {

    }
}
