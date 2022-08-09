using AutoMapper;
using TesteBackEnd.Domain.Dtos.Course;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Domain.Models;

namespace TesteBackEnd.Service.Services
{
    public class CourseService : BaseService, ICourseService
    {
        private ICourseRepository _repository;
        private IDisciplineRepository _disciplineRepository;
        private IStudentRepository _studentRepository;
        protected readonly IMapper _mapper;
        public CourseService(ICourseRepository repository, IMapper mapper, INotifier notifier, IDisciplineRepository disciplineRepository, IStudentRepository studentRepository) : base(notifier)
        {
            _repository = repository;
            _mapper = mapper;
            _disciplineRepository = disciplineRepository;
            _studentRepository = studentRepository;
        }

        public async Task<CourseDto> SelectAsync(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CourseDto>(entity);
        }

        public async Task<IEnumerable<CourseDto>> SelectAsync()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(entities);
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _repository.ExistAsync(id);
        }

        public async Task<CourseDtoCreateResult> InsertAsync(CourseDtoCreate item)
        {
            var model = _mapper.Map<CourseModel>(item);
            var entity = _mapper.Map<CourseEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<CourseDtoCreateResult>(result);
        }

        public async Task<CourseDtoUpdateResult> UpdateAsync(CourseDtoUpdate item)
        {
            var model = _mapper.Map<CourseModel>(item);
            var entity = _mapper.Map<CourseEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<CourseDtoUpdateResult>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            if (!_studentRepository.SelectAsync().Result.Where(s => s.CourseId == id).Any())
            {
                if (entity.Disciplines.Any())
                {
                    foreach (var discipline in entity.Disciplines)
                        await _disciplineRepository.DeleteAsync(discipline.Id);
                }
                return await _repository.DeleteAsync(id);
            }
            else
            {
                return false;
            }
        }
    }
}
