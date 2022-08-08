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
        protected readonly IMapper _mapper;
        public CourseService(ICourseRepository repository, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _repository = repository;
            _mapper = mapper;
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
            return await _repository.DeleteAsync(id);
        }
    }
}
