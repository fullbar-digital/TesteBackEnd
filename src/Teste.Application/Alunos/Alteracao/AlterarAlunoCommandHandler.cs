using AutoMapper;
using MediatR;
using Teste.Domain.Alunos.Entities;
using Teste.Domain.Common.Repositories;

namespace Teste.Application.Alunos.Alteracao
{
    public class AlterarAlunoCommandHandler : IRequestHandler<AlterarAlunoCommand, AlterarAlunoResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AlterarAlunoCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<AlterarAlunoResponse> Handle(AlterarAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = _mapper.Map<Aluno>(request);

            _repositoryManager.AlunoRepository.Alterar(aluno);
            await _repositoryManager.SaveAsync(cancellationToken);

            return new AlterarAlunoResponse();
        }
    }
}
