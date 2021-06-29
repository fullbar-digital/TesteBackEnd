using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.API.Services.Interfaces;
using TesteFullBar.API.ViewModels.Disciplina;

namespace TesteFullBar.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/disciplinas")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService _disciplinaService;

        public DisciplinaController(IDisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        /// <summary>
        /// Disciplinas.
        /// </summary>        
        /// <response code="200">Retorna objeto disciplinas.</response>
        /// <response code="204">Não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(IEnumerable<DisciplinaViewModel>), 200)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplinaViewModel>>> GetAll()
        {
            return Ok(await _disciplinaService.GetAll());
        }

        /// <summary>
        /// Disciplina por Id.
        /// </summary>
        /// <param name="disciplina">Parâmetro "Id" do Disciplina.</param>
        /// <response code="200">Retorna objeto Disciplina.</response>
        /// <response code="204">Não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(DisciplinaViewModel), 200)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplinaViewModel>> GetById([FromQuery] DisciplinaIdViewModel disciplina)
        {
            var disciplinaVM = await _disciplinaService.GetByIdAsync(disciplina);

            if (disciplinaVM == null)
            {
                return NoContent();
            }

            return Ok(disciplinaVM);
        }

        /// <summary>
        /// Disciplina por nome.
        /// </summary>
        /// <param name="disciplina">Parâmetro "nome" do Disciplina.</param>
        /// <response code="200">Retorna objeto Disciplina.</response>
        /// <response code="204">Não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(DisciplinaViewModel), 200)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpGet("descricao/{descricao}")]
        public async Task<ActionResult<DisciplinaViewModel>> GetByDescricao([FromQuery] DisciplinaDescricaoViewModel disciplina)
        {
            var disciplinaVM = await _disciplinaService.GetByDescricaoAsync(disciplina);

            if (disciplinaVM == null)
            {
                return NoContent();
            }

            return Ok(disciplinaVM);
        }

        /// <summary>
        /// Criação de Disciplina.
        /// </summary>
        /// <param name="disciplina">Parâmetro "Disciplina".</param>
        /// <response code="201">Registro criado.</response>
        /// <response code="204">Disciplina não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(DisciplinaViewModel), 201)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpPost]
        public ActionResult<DisciplinaViewModel> PostDisciplina([FromBody] DisciplinaViewModel disciplina)
        {
            if (disciplina == null || string.IsNullOrWhiteSpace(disciplina.Descricao))
            {
                //teste
                return NoContent();
            }

            return Created(nameof(GetByDescricao), _disciplinaService.Add(disciplina));
        }

        /// <summary>
        /// Atualização de Disciplina.
        /// </summary>
        /// <param name="id">Parâmetro "id" do Disciplina.</param>
        /// <param name="disciplina">Parâmetro "Disciplina".</param>
        /// <response code="202">Registro criado.</response>
        /// <response code="204">Disciplina não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(void), 202)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutDisciplina(int id, [FromBody] DisciplinaViewModel disciplina)
        {
            if (disciplina == null || disciplina.Id != id)
            {
                return BadRequest();
            }

            var disciplinaVM = await _disciplinaService.GetByIdAsync(new DisciplinaIdViewModel(id));

            if (disciplinaVM == null)
            {
                return NoContent();
            }

            _disciplinaService.Update(disciplina);

            return Accepted();
        }

        /// <summary>
        /// Exclusão de Disciplina.
        /// </summary>
        /// <param name="disciplina">Parâmetro "id" do Disciplina.</param>
        /// <response code="202">Registro criado.</response>
        /// <response code="204">Disciplina não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(void), 202)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDisciplina([FromQuery] DisciplinaIdViewModel disciplina)
        {
            var disciplinaVM = await _disciplinaService.GetByIdAsync(disciplina);

            if (disciplinaVM == null)
            {
                return NoContent();
            }

            _disciplinaService.Remove(disciplinaVM);

            return Accepted();
        }
    }
}