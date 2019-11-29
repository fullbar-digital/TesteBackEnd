using System.Threading.Tasks;
using ApplicationCore.Domain.Dto;
using ApplicationCore.Domain.Shared;
using Hisoka;

namespace ApplicationCore.Domain.Repositories
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task Save(Student student)
        {
            student.Validate();

            await _studentRepository.Save(student);
            await _studentRepository.CommitAsync();
        }

        public async Task Update(Student student)
        {
            student.Validate();

            var studentDb = await _studentRepository.Find(student.Id);

            if (studentDb == null)
                throw new DomainException("Não encontramos nenhum usuário com o Id informado!");

            await _studentRepository.Update(student);
            await _studentRepository.CommitAsync();
        }

        public async Task<StudentDto> FindDto(int id)
        {
            var studentDb = await _studentRepository.FindDto(id);

            if (studentDb == null)
                throw new DomainException("Usuário não encontrado!");

            return studentDb;
        }

        public async Task<Student> Find(int id)
        {
            var studentDb = await _studentRepository.Find(id);

            if (studentDb == null)
                throw new DomainException("Usuário não encontrado!");

            return studentDb;
        }

        public async Task Delete(int id)
        {
            var studentDb = await _studentRepository.Find(id);

            if (studentDb == null)
                throw new DomainException("Usuário não encontrado para ser deletado!");

            await _studentRepository.Delete(studentDb);
            await _studentRepository.CommitAsync();
        }

        public async Task<IPagedList<StudentDto>> All(ResourceQueryFilter filter)
        {
            return await _studentRepository.All(filter);
        }
    }
}