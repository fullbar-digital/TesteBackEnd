using MediatR;
using Teste.Domain.Common.Repositories;

namespace Teste.Application.Disciplinas.Remocao
{
    public class ObterTodasDisciplinasCommandHandler : IRequestHandler<RemoverDisciplinaCommand, RemoverDisciplinaResponse>
    {
        private readonly IRepositoryManager _repositoryManager;

        public ObterTodasDisciplinasCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;            
        }

        public async Task<RemoverDisciplinaResponse> Handle(RemoverDisciplinaCommand request, CancellationToken cancellationToken)
        {
            var disciplinaId = new Guid(request.DisciplinaId);

            _repositoryManager.DisciplinaRepository.Remover(disciplinaId);
            await _repositoryManager.SaveAsync(cancellationToken);

            return new RemoverDisciplinaResponse();
        }
    }
}
