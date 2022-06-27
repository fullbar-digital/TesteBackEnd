using AutoMapper;
using MediatR;
using Teste.Domain.Common.Repositories;
using Teste.Domain.Disciplinas.Entities;

namespace Teste.Application.Disciplinas.Alteracao
{
    public class AlterarDisciplinaCommandHandler : IRequestHandler<AlterarDisciplinaCommand, AlterarDisciplinaResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AlterarDisciplinaCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<AlterarDisciplinaResponse> Handle(AlterarDisciplinaCommand request, CancellationToken cancellationToken)
        {
            var disciplina = _mapper.Map<Disciplina>(request);

            _repositoryManager.DisciplinaRepository.Alterar(disciplina);
            await _repositoryManager.SaveAsync(cancellationToken);

            return new AlterarDisciplinaResponse();
        }
    }
}
