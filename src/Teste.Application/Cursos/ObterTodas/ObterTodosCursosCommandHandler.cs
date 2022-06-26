using AutoMapper;
using MediatR;
using Teste.Application.Cursos.Dtos;
using Teste.Domain.Common.Repositories;

namespace Teste.Application.Cursos.ObterTodas
{
    public class ObterTodosCursosCommandHandler : IRequestHandler<ObterTodosCursosCommand, ObterTodosCursosResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ObterTodosCursosCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ObterTodosCursosResponse> Handle(ObterTodosCursosCommand request, CancellationToken cancellationToken)
        {
            var cursoDb = await _repositoryManager.CursoRepository.ObterTodos();

            var curso = _mapper.Map<List<CursoDto>>(cursoDb);

            return new ObterTodosCursosResponse(curso);
        }
    }
}