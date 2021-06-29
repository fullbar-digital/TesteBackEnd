using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TesteFullBar.API.Services.Interfaces;
using TesteFullBar.API.ViewModels.Aluno;
using TesteFullBar.API.ViewModels.Aluno.Query;

namespace TesteFullBar.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/alunos")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        /// <summary>
        /// Aluno por Id.
        /// </summary>
        /// <param name="aluno">Parâmetro "Id" do Aluno.</param>
        /// <response code="200">Retorna objeto aluno.</response>
        /// <response code="204">Não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(AlunoViewModel), 200)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoViewModel>> GetById([FromQuery] AlunoIdViewModel aluno)
        {
            var alunoVM = await _alunoService.GetByIdAsync(aluno);

            if (alunoVM == null)
            {
                return NoContent();
            }

            return Ok(alunoVM);
        }

        /// <summary>
        /// Aluno por RA.
        /// </summary>
        /// <param name="aluno">Parâmetro "ra" do Aluno.</param>
        /// <response code="200">Retorna objeto aluno.</response>
        /// <response code="204">Não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(AlunoViewModel), 200)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpGet("ra/{ra}")]
        public async Task<ActionResult<AlunoViewModel>> GetByRa([FromQuery] AlunoRaViewModel aluno)
        {
            var alunoVM = await _alunoService.GetByRaAsync(aluno);

            if (alunoVM == null)
            {
                return NoContent();
            }

            return Ok(alunoVM);
        }

        /// <summary>
        /// Criação de Aluno.
        /// </summary>
        /// <param name="aluno">Parâmetro "Aluno".</param>
        /// <param name="formFile">Parâmetro "Arquivo foto".</param>
        /// <response code="201">Registro criado.</response>
        /// <response code="204">Aluno não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(AlunoViewModel), 201)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpPost]
        public ActionResult<AlunoViewModel> PostAluno([FromBody] AlunoViewModel aluno)
        {
            if (aluno == null || string.IsNullOrWhiteSpace(aluno.Nome))
            {
                return BadRequest();
            }            

            return Created(nameof(GetByRa), _alunoService.Add(aluno));
        }

        /// <summary>
        /// Busca de alunos por filtros
        /// </summary>
        /// <param name="alunoFilter">Parâmetro "Aluno Filtos".</param>
        /// <response code="201">Registro criado.</response>
        /// <response code="204">Aluno não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(IEnumerable<AlunoQueryViewModel>), 200)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpPost("filtros")]
        public async Task<ActionResult<IEnumerable<AlunoQueryViewModel>>> PostFilters([FromBody] AlunoFilterViewModel alunoFilter)
        {
            if (alunoFilter == null)
            {
                return BadRequest();
            }

            return Ok(await _alunoService.GetByFilterAsync(alunoFilter));
        }

        /// <summary>
        /// Atualização de Aluno.
        /// </summary>
        /// <param name="id">Parâmetro "id" do Aluno.</param>
        /// <param name="aluno">Parâmetro "Aluno".</param>
        /// <response code="202">Registro criado.</response>
        /// <response code="204">Aluno não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(void), 202)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAluno(int id, [FromBody] AlunoViewModel aluno)
        {
            if (aluno == null || aluno.Id != id)
            {
                return BadRequest();
            }

            var alunoVM = await _alunoService.GetByIdAsync(new AlunoIdViewModel(id));

            if (alunoVM == null)
            {
                return NoContent();
            }

            _alunoService.Update(aluno);

            return Accepted();
        }

        /// <summary>
        /// Exclusão de aluno.
        /// </summary>
        /// <param name="aluno">Parâmetro "id" do aluno.</param>
        /// <response code="202">Registro criado.</response>
        /// <response code="204">Aluno não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(void), 202)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAluno([FromQuery] AlunoIdViewModel aluno)
        {
            var alunoVM = await _alunoService.GetByIdAsync(aluno);

            if (alunoVM == null)
            {
                return NoContent();
            }

            _alunoService.Remove(alunoVM);

            return Accepted();
        }
    }
}