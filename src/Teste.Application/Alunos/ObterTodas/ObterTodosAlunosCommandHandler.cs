using AutoMapper;
using MediatR;
using Teste.Application.Alunos.Dtos;
using Teste.Domain.Common.Repositories;

namespace Teste.Application.Alunos.ObterTodas
{
    public class ObterTodosAlunosCommandHandler : IRequestHandler<ObterTodosAlunosCommand, ObterTodosAlunosResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ObterTodosAlunosCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ObterTodosAlunosResponse> Handle(ObterTodosAlunosCommand request, CancellationToken cancellationToken)
        {
            var alunosDb = await _repositoryManager.AlunoRepository.ObterTodos();

            var alunos = _mapper.Map<List<AlunoDto>>(alunosDb);

            return new ObterTodosAlunosResponse(alunos);
        }
    }
}