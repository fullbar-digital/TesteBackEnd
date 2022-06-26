using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teste.Application.Alunos.Alteracao;
using Teste.Application.Alunos.Cadastro;
using Teste.Application.Alunos.Filtro;
using Teste.Application.Alunos.ObterTodas;
using Teste.Application.Alunos.Remocao;
using Teste.WebAPI.Controllers.Base;

namespace Teste.WebAPI.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AlunoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("cadastrar")]
        public Task<ActionResult<CadastrarAlunoResponse>> Cadastrar(CadastrarAlunoCommand command, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(command, cancellationToken);
            return Task.FromResult(CreateResponse(result));
        }

        [HttpPut]
        [Route("alterar")]
        public Task<ActionResult<AlterarAlunoResponse>> Alterar(AlterarAlunoCommand command, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(command, cancellationToken);
            return Task.FromResult(CreateResponse(result));
        }

        [HttpDelete]
        [Route("remover")]
        public Task<ActionResult<RemoverAlunoResponse>> Remover(RemoverAlunoCommand command, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(command, cancellationToken);
            return Task.FromResult(CreateResponse(result));
        }

        [HttpGet]
        [Route("alunos")]
        public Task<ActionResult<ObterTodosAlunosResponse>> ObterTodas(CancellationToken cancellationToken)
        {
            var result = _mediator.Send(new ObterTodosAlunosCommand(), cancellationToken);
            return Task.FromResult(CreateResponse(result));
        }
        /// <summary>
        /// Método que realiza a filtragem dos Alunos
        /// </summary>
        /// <param name="curso">Informe o nome do curso</param>
        /// <param name="nome">Informe o nome do aluno</param>
        /// <param name="registroAcademico">Informe o registro acadêmico</param>
        /// <param name="status">Para pesquisar por um Status específico, digite [Aprovado/Reprovado](a) em: [NomeDisciplina] </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("filtrar")]        
        public Task<ActionResult<FiltrarAlunoResponse>> Filtrar(string? curso,string? nome,string? registroAcademico,string? status,CancellationToken cancellationToken)
        {
            var command = new FiltrarAlunoCommand { Curso = curso, Nome = nome, RegistroAcademico = registroAcademico, Status = status };

            var result = _mediator.Send(command, cancellationToken);
            return Task.FromResult(CreateResponse(result));
        }

    }
}
