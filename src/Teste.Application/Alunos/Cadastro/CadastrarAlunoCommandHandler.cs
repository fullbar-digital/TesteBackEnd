using AutoMapper;
using MediatR;
using Teste.Domain.Alunos.Entities;
using Teste.Domain.Common.Repositories;

namespace Teste.Application.Alunos.Cadastro
{
    public class CadastrarAlunoCommandHandler : IRequestHandler<CadastrarAlunoCommand, CadastrarAlunoResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CadastrarAlunoCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CadastrarAlunoResponse> Handle(CadastrarAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = _mapper.Map<Aluno>(request);

            _repositoryManager.AlunoRepository.Inserir(aluno);
            await _repositoryManager.SaveAsync(cancellationToken);

            return new CadastrarAlunoResponse(aluno.Id);
        }
    }
}
