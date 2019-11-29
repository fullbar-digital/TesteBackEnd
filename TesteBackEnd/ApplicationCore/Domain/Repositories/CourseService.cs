using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Repositories
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> All()
        {
            return await _courseRepository.All();
        }
    }
}