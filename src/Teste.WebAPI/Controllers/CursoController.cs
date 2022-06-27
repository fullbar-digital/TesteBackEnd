using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teste.Application.Cursos.Alteracao;
using Teste.Application.Cursos.Cadastro;
using Teste.Application.Cursos.ObterTodas;
using Teste.Application.Cursos.Remocao;
using Teste.WebAPI.Controllers.Base;

namespace Teste.WebAPI.Controllers
{
    [ApiController]
    [Route("api/curso")]
    public class CursoController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CursoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("cadastrar")]
        public Task<ActionResult<CadastrarCursoResponse>> Cadastrar(CadastrarCursoCommand command, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(command, cancellationToken);
            return Task.FromResult(CreateResponse(result));
        }

        [HttpPut]
        [Route("alterar")]
        public Task<ActionResult<AlterarCursoResponse>> Alterar(AlterarCursoCommand command, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(command, cancellationToken);
            return Task.FromResult(CreateResponse(result));
        }

        [HttpDelete]
        [Route("remover")]
        public Task<ActionResult<RemoverCursoResponse>> Remover(RemoverCursoCommand command, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(command, cancellationToken);
            return Task.FromResult(CreateResponse(result));
        }

        [HttpGet]
        [Route("cursos")]
        public Task<ActionResult<ObterTodosCursosResponse>> ObterTodas(CancellationToken cancellationToken)
        {
            var result = _mediator.Send(new ObterTodosCursosCommand(), cancellationToken);
            return Task.FromResult(CreateResponse(result));
        }

    }
}
