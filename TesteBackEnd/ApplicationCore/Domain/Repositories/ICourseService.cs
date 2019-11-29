using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Repositories
{
    public interface ICourseService
    {
        Task<List<Course>> All();
    }
}