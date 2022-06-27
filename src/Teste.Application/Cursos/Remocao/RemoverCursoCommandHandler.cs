using MediatR;
using Teste.Domain.Common.Repositories;

namespace Teste.Application.Cursos.Remocao
{
    public class RemoverCursoCommandHandler : IRequestHandler<RemoverCursoCommand, RemoverCursoResponse>
    {
        private readonly IRepositoryManager _repositoryManager;

        public RemoverCursoCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;            
        }

        public async Task<RemoverCursoResponse> Handle(RemoverCursoCommand request, CancellationToken cancellationToken)
        {
            var cursoId = new Guid(request.Id);

            _repositoryManager.CursoRepository.Remover(cursoId);
            await _repositoryManager.SaveAsync(cancellationToken);

            return new RemoverCursoResponse();
        }
    }
}
