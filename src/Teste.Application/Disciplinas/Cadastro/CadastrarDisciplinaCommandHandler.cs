using AutoMapper;
using MediatR;
using Teste.Domain.Common.Repositories;
using Teste.Domain.Disciplinas.Entities;

namespace Teste.Application.Disciplinas.Cadastro
{
    public class CadastrarDisciplinaCommandHandler : IRequestHandler<CadastrarDisciplinaCommand, CadastrarDisciplinaResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CadastrarDisciplinaCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CadastrarDisciplinaResponse> Handle(CadastrarDisciplinaCommand request, CancellationToken cancellationToken)
        {
            var disciplina = _mapper.Map<Disciplina>(request);

            _repositoryManager.DisciplinaRepository.Inserir(disciplina);
            await _repositoryManager.SaveAsync(cancellationToken);

            return new CadastrarDisciplinaResponse(disciplina.Id);
        }
    }
}
