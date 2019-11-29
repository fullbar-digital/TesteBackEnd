using System.Threading.Tasks;
using ApplicationCore.Domain.Dto;
using Hisoka;

namespace ApplicationCore.Domain.Repositories
{
    public interface IStudentService
    {
        Task Save(Student student);
        Task Update(Student student);
        Task<StudentDto> FindDto(int id);
        Task<Student> Find(int id);
        Task<IPagedList<StudentDto>> All(ResourceQueryFilter query);
        Task Delete(int id);
    }
}