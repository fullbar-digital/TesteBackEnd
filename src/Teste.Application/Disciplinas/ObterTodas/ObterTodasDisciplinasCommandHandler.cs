using AutoMapper;
using MediatR;
using Teste.Application.Disciplinas.Dtos;
using Teste.Domain.Common.Repositories;

namespace Teste.Application.Disciplinas.ObterTodas
{
    public class ObterTodasDisciplinasCommandHandler : IRequestHandler<ObterTodasDisciplinasCommand, ObterTodasDisciplinasResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ObterTodasDisciplinasCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ObterTodasDisciplinasResponse> Handle(ObterTodasDisciplinasCommand request, CancellationToken cancellationToken)
        {
            var disciplinasDb = await _repositoryManager.DisciplinaRepository.ObterTodos();

            var disciplinas = _mapper.Map<List<DisciplinaDto>>(disciplinasDb);

            return new ObterTodasDisciplinasResponse(disciplinas);
        }
    }
}