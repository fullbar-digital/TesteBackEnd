using AutoMapper;
using MediatR;
using Teste.Domain.Common.Repositories;
using Teste.Domain.Cursos.Entitites;

namespace Teste.Application.Cursos.Alteracao
{
    public class AlterarCursoCommandHandler : IRequestHandler<AlterarCursoCommand, AlterarCursoResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AlterarCursoCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<AlterarCursoResponse> Handle(AlterarCursoCommand request, CancellationToken cancellationToken)
        {
            var curso = _mapper.Map<Curso>(request);

            _repositoryManager.DisciplinaRepository.Alterar(disciplina);
            await _repositoryManager.SaveAsync(cancellationToken);

            return new AlterarCursoResponse();
        }
    }
}
