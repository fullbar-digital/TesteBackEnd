using System.Threading.Tasks;
using Template.Api.ApplicationCore.Entities;

namespace Template.Api.ApplicationCore.Intefaces.Services
{
    public interface IStudentService : IBaseService<Student>
    {
        Task<Student> GetByIdAsync(int id);
        Task<int> DeleteAsync(int id);
    }
}