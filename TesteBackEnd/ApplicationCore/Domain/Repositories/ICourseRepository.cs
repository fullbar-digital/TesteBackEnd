using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> All();
    }
}