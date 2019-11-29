using System.Threading.Tasks;
using ApplicationCore.Domain.Dto;
using Hisoka;

namespace ApplicationCore.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task Save(Student student);
        Task Update(Student student);
        Task<IPagedList<StudentDto>> All(ResourceQueryFilter filter);
        Task<StudentDto> FindDto(int id);
        Task<Student> Find(int id);
        Task Delete(Student student);
        Task<int> CommitAsync();
    }
}