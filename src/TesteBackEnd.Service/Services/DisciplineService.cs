using AutoMapper;
using TesteBackEnd.Domain.Dtos.Discipline;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Domain.Models;

namespace TesteBackEnd.Service.Services
{
    public class DisciplineService : BaseService, IDisciplineService
    {
        private IDisciplineRepository _repository;
        protected readonly IMapper _mapper;
        public DisciplineService(IDisciplineRepository repository, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DisciplineDto> SelectAsync(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<DisciplineDto>(entity);
        }

        public async Task<IEnumerable<DisciplineDto>> SelectAsync()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<DisciplineDto>>(entities);
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _repository.ExistAsync(id);
        }

        public async Task<DisciplineDtoCreateResult> InsertAsync(DisciplineDtoCreate item)
        {
            var model = _mapper.Map<DisciplineModel>(item);
            var entity = _mapper.Map<DisciplineEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<DisciplineDtoCreateResult>(result);
        }

        public async Task<DisciplineDtoUpdateResult> UpdateAsync(DisciplineDtoUpdate item)
        {
            var model = _mapper.Map<DisciplineModel>(item);
            var entity = _mapper.Map<DisciplineEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<DisciplineDtoUpdateResult>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
