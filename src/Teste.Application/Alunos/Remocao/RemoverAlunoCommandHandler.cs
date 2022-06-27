using MediatR;
using Teste.Domain.Common.Repositories;

namespace Teste.Application.Alunos.Remocao
{
    public class RemoverAlunoCommandHandler : IRequestHandler<RemoverAlunoCommand, RemoverAlunoResponse>
    {
        private readonly IRepositoryManager _repositoryManager;

        public RemoverAlunoCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;            
        }

        public async Task<RemoverAlunoResponse> Handle(RemoverAlunoCommand request, CancellationToken cancellationToken)
        {
            var alunoId = new Guid(request.Id);

            _repositoryManager.AlunoRepository.Remover(alunoId);
            await _repositoryManager.SaveAsync(cancellationToken);

            return new RemoverAlunoResponse();
        }
    }
}
