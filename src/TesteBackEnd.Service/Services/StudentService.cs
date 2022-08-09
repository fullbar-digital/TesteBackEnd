using System.Linq.Expressions;
using AutoMapper;
using TesteBackEnd.Domain.Dtos.Student;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Domain.Models;

namespace TesteBackEnd.Service.Services
{
    public class StudentService : BaseService, IStudentService
    {
        private IStudentRepository _repository;
        private IScoreRepository _scoreRepository;
        protected readonly IMapper _mapper;
        public StudentService(IStudentRepository repository, IMapper mapper, INotifier notifier, IScoreRepository scoreRepository) : base(notifier)
        {
            _repository = repository;
            _mapper = mapper;
            _scoreRepository = scoreRepository;
        }

        public async Task<StudentDto> SelectAsync(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            var model = _mapper.Map<StudentModel>(entity);
            return _mapper.Map<StudentDto>(model);
        }

        public async Task<IEnumerable<StudentDto>> SelectAsync()
        {
            var entities = await _repository.SelectAsync();
            var model = _mapper.Map<IEnumerable<StudentModel>>(entities);
            return _mapper.Map<IEnumerable<StudentDto>>(model);
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _repository.ExistAsync(id);
        }

        public async Task<StudentDtoCreateResult> InsertAsync(StudentDtoCreate item)
        {
            var model = _mapper.Map<StudentModel>(item);
            var entity = _mapper.Map<StudentEntity>(model);
            entity.Status = Domain.Enums.Status.SCORELESS;
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<StudentDtoCreateResult>(result);
        }

        public async Task<StudentDtoUpdateResult> UpdateAsync(Guid id, StudentDtoUpdate item)
        {
            var model = _mapper.Map<StudentModel>(item);
            model.Id = id;
            var entity = _mapper.Map<StudentEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<StudentDtoUpdateResult>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            if (entity.Scores.Any())
            {
                foreach (var score in entity.Scores)
                    await _scoreRepository.DeleteAsync(score.Id);
            }
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StudentDto>> FilterAsync(Expression<Func<StudentEntity, bool>> predicado)
        {
            var entities = await _repository.FilterAsync(predicado);
            var model = _mapper.Map<IEnumerable<StudentModel>>(entities);
            return _mapper.Map<IEnumerable<StudentDto>>(model);
        }
    }
}
