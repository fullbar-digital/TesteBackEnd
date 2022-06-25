using AutoMapper;
using MediatR;
using Teste.Domain.Common.Repositories;
using Teste.Domain.Cursos.Entitites;

namespace Teste.Application.Cursos.Cadastro
{
    public class CadastrarCursoCommandHandler : IRequestHandler<CadastrarCursoCommand, CadastrarCursoResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CadastrarCursoCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CadastrarCursoResponse> Handle(CadastrarCursoCommand request, CancellationToken cancellationToken)
        {
            var curso = _mapper.Map<Curso>(request);

            _repositoryManager.CursoRepository.Inserir(curso);
            await _repositoryManager.SaveAsync(cancellationToken);

            return new CadastrarCursoResponse(curso.Id);
        }
    }
}
