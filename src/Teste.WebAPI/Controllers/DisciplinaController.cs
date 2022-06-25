using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teste.Application.Disciplinas.Alteracao;
using Teste.Application.Disciplinas.Cadastro;
using Teste.Application.Disciplinas.ObterTodas;
using Teste.Application.Disciplinas.Remocao;
using Teste.WebAPI.Controllers.Base;

namespace Teste.WebAPI.Controllers
{
    [ApiController]
    [Route("api/disciplina")]
    public class DisciplinaController : BaseApiController
    {
        private readonly IMediator _mediator;

        public DisciplinaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("cadastrar")]
        public Task<ActionResult<CadastrarDisciplinaResponse>> Cadastrar(CadastrarDisciplinaCommand command, CancellationToken cancellationToken)
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
        public Task<ActionResult<RemoverDisciplinaResponse>> Remover(RemoverDisciplinaCommand command, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(command, cancellationToken);
            return Task.FromResult(CreateResponse(result));
        }

        [HttpGet]
        [Route("disciplinas")]
        public Task<ActionResult<ObterTodasDisciplinasResponse>> ObterTodas(CancellationToken cancellationToken)
        {
            var result = _mediator.Send(new ObterTodasDisciplinasCommand(), cancellationToken);
            return Task.FromResult(CreateResponse(result));
        }

    }
}
