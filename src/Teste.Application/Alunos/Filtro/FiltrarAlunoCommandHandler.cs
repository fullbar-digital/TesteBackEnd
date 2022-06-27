using AutoMapper;
using LinqKit;
using MediatR;
using Teste.Application.Alunos.Dtos;
using Teste.Domain.Alunos.Dto;
using Teste.Domain.Alunos.Entities;
using Teste.Domain.Common.Repositories;

namespace Teste.Application.Alunos.Filtro
{
    public class FiltrarAlunoCommandHandler : IRequestHandler<FiltrarAlunoCommand, FiltrarAlunoResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public FiltrarAlunoCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<FiltrarAlunoResponse> Handle(FiltrarAlunoCommand request, CancellationToken cancellationToken)
        {
            var filter = _mapper.Map<FilterAlunoDto>(request);

            var alunosDb = await _repositoryManager.AlunoRepository.GetByConditionAsync(filter);

            var alunos = _mapper.Map<List<AlunoDto>>(alunosDb);

            return new FiltrarAlunoResponse(alunos);
        }
    }
}
