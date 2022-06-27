using MediatR;
using Teste.Domain.Common.Repositories;

namespace Teste.Application.Disciplinas.Remocao
{
    public class RemoverDisciplinaCommandHandler : IRequestHandler<RemoverDisciplinaCommand, RemoverDisciplinaResponse>
    {
        private readonly IRepositoryManager _repositoryManager;

        public RemoverDisciplinaCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<RemoverDisciplinaResponse> Handle(RemoverDisciplinaCommand request, CancellationToken cancellationToken)
        {
            var disciplinaId = new Guid(request.Id);

            _repositoryManager.DisciplinaRepository.Remover(disciplinaId);
            await _repositoryManager.SaveAsync(cancellationToken);

            return new RemoverDisciplinaResponse();
        }
    }
}
