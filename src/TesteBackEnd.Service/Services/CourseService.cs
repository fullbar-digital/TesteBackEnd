using System.Text.Json;
using AutoMapper;
using Newtonsoft.Json.Linq;
using TesteBackEnd.Domain.Dtos.Course;
using TesteBackEnd.Domain.Dtos.Course.Validations;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Domain.Models;
using TesteBackEnd.Infrastructure.Caching.Interfaces;
using TesteBackEnd.Insfrastructure.Caching;

namespace TesteBackEnd.Service.Services
{
    public class CourseService : BaseService, ICourseService
    {
        private ICourseRepository _repository;
        private IDisciplineRepository _disciplineRepository;
        private IStudentRepository _studentRepository;
        protected readonly IMapper _mapper;
        private ICacheRepository _cache;
        public CourseService(ICourseRepository repository, IMapper mapper, INotifier notifier, IDisciplineRepository disciplineRepository, IStudentRepository studentRepository, ICacheRepository cache) : base(notifier)
        {
            _repository = repository;
            _mapper = mapper;
            _disciplineRepository = disciplineRepository;
            _studentRepository = studentRepository;
            _cache = cache;
        }

        public async Task<CourseDto> SelectAsync(Guid id)
        {
            var obj = await _cache.SelectAsync(id.ToString());
            if (obj != null)
                return JsonSerializer.Deserialize<CourseDto>(obj.Value);
            else
            {
                var entity = await _repository.SelectAsync(id);
                return _mapper.Map<CourseDto>(entity);
            }
        }

        public async Task<IEnumerable<CourseDto>> SelectAsync()
        {
            try
            {
                var returnList = new List<CourseEntity>();
                var list = await _cache.SelectAsync();
                if (((List<Cache>)list).Count > 0)
                {
                    foreach (Cache cache in list)
                    {
                        returnList.Add(JsonSerializer.Deserialize<CourseEntity>(cache.Value));
                    }
                    return _mapper.Map<IEnumerable<CourseDto>>(returnList);
                }
                else
                {
                    var entities = await _repository.SelectAsync();
                    return _mapper.Map<IEnumerable<CourseDto>>(entities);
                }
            }
            catch (System.Exception)
            {
                var entities = await _repository.SelectAsync();
                return _mapper.Map<IEnumerable<CourseDto>>(entities);
            }

        }

        public async Task<bool> ExistAsync(Guid id)
        {
            var obj = await _cache.ExistAsync(id.ToString());
            if (obj)
                return obj;
            else
                return await _repository.ExistAsync(id);
        }
        public async Task<CourseDtoCreateResult> InsertAsync(CourseDtoCreate item)
        {
            if (!ValidationExecute(new CourseDtoCreateValidation(), item)) return null;
            if (SelectAsync()
            .Result.Where(p => p.Name.ToLower() == item.Name.ToLower()).Any())
            {
                Notify("Já existe um Curso com o nome informado.");
                return null;
            }

            var model = _mapper.Map<CourseModel>(item);
            var entity = _mapper.Map<CourseEntity>(model);

            var result = await _repository.InsertAsync(entity);
            await _cache.InsertAsync(new Cache
            {
                Key = result.Id.ToString(),
                Value = JsonSerializer.Serialize<Object>(result)
            });
            return _mapper.Map<CourseDtoCreateResult>(result);
        }

        public async Task<CourseDtoUpdateResult> UpdateAsync(Guid id, CourseDtoUpdate item)
        {
            var model = _mapper.Map<CourseModel>(item);
            model.Id = id;
            var entity = _mapper.Map<CourseEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            await _cache.UpdateAsync(new Cache
            {
                Key = result.Id.ToString(),
                Value = JsonSerializer.Serialize<Object>(result)
            });
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
                    {
                        await _disciplineRepository.DeleteAsync(discipline);
                        await _cache.DeleteAsync(discipline.Id.ToString());
                    }
                }
                await _cache.DeleteAsync(entity.Id.ToString());
                return await _repository.DeleteAsync(entity);
            }
            else
            {
                return false;
            }
        }
    }
}
