using AutoMapper;
using TesteBackEnd.Domain.Dtos.Score;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Domain.Models;

namespace TesteBackEnd.Service.Services
{
    public class ScoreService : BaseService, IScoreService
    {
        private IScoreRepository _repository;
        protected readonly IMapper _mapper;
        public ScoreService(IScoreRepository repository, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ScoreDto> SelectAsync(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ScoreDto>(entity);
        }

        public async Task<IEnumerable<ScoreDto>> SelectAsync()
        {
            var entities = await _repository.SelectAsync();
            var models = _mapper.Map<IEnumerable<ScoreModel>>(entities);
            return _mapper.Map<IEnumerable<ScoreDto>>(models);
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _repository.ExistAsync(id);
        }

        public async Task<ScoreDtoCreateResult> InsertAsync(ScoreDtoCreate item)
        {
            var model = _mapper.Map<ScoreModel>(item);
            var entity = _mapper.Map<ScoreEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<ScoreDtoCreateResult>(result);
        }

        public async Task<ScoreDtoUpdateResult> UpdateAsync(ScoreDtoUpdate item)
        {
            var model = _mapper.Map<ScoreModel>(item);
            var entity = _mapper.Map<ScoreEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<ScoreDtoUpdateResult>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
