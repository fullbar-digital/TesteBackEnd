using AutoMapper;
using TesteBackEnd.Domain.Dtos.Student;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Domain.Models;

namespace TesteBackEnd.Service.Services
{
    public class StudentService : BaseService, IStudentService
    {
        private IRepository<StudentEntity> _repository;
        protected readonly IMapper _mapper;
        public StudentService(IRepository<StudentEntity> repository, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _repository = repository;
            _mapper = mapper;
        }
    
        public async Task<StudentDto> SelectAsync(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<StudentDto>(entity);
        }

        public async Task<IEnumerable<StudentDto>> SelectAsync()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(entities);
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _repository.ExistAsync(id);
        }

        public async Task<StudentDtoCreateResult> InsertAsync(StudentDtoCreate item)
        {
            var model = _mapper.Map<StudentModel>(item);
            var entity = _mapper.Map<StudentEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<StudentDtoCreateResult>(result);
        }

        public async Task<StudentDtoUpdateResult> UpdateAsync(StudentDtoUpdate item)
        {
            var model = _mapper.Map<StudentModel>(item);
            var entity = _mapper.Map<StudentEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<StudentDtoUpdateResult>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}