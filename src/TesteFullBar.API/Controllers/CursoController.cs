using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.API.Services.Interfaces;
using TesteFullBar.API.ViewModels.Curso;

namespace TesteFullBar.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/cursos")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }


        /// <summary>
        /// Curso por nome.
        /// </summary>
        /// <param name="curso">Parâmetro "nome" do Curso.</param>
        /// <response code="200">Retorna objeto curso.</response>
        /// <response code="204">Não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(CursoViewModel), 200)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpGet("descricao/{descricao}")]
        public async Task<ActionResult<CursoViewModel>> GetByDescricao([FromQuery] CursoDescricaoViewModel curso)
        {
            var cursoVM = await _cursoService.GetByDescricaoAsync(curso);

            if (cursoVM == null)
            {
                return NoContent();
            }

            return Ok(cursoVM);
        }

        /// <summary>
        /// Cursos.
        /// </summary>        
        /// <response code="200">Retorna objeto cursos.</response>
        /// <response code="204">Não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(IEnumerable<CursoViewModel>), 200)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoViewModel>>> GetAll()
        {
            return Ok(await _cursoService.GetAll());
        }

        /// <summary>
        /// Curso por Id.
        /// </summary>
        /// <param name="curso">Parâmetro "Id" do Curso.</param>
        /// <response code="200">Retorna objeto aluno.</response>
        /// <response code="204">Não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(CursoViewModel), 200)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CursoViewModel>> GetById([FromQuery] CursoIdViewModel curso)
        {
            var cursoVM = await _cursoService.GetByIdAsync(curso);

            if (cursoVM == null)
            {
                return NoContent();
            }

            return Ok(cursoVM);
        }

        /// <summary>
        /// Criação de Curso.
        /// </summary>
        /// <param name="curso">Parâmetro "Curso".</param>
        /// <response code="201">Registro criado.</response>
        /// <response code="204">Curso não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(CursoViewModel), 201)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpPost]
        public ActionResult<CursoViewModel> PostCurso([FromBody] CursoViewModel curso)
        {
            if (curso == null || string.IsNullOrWhiteSpace(curso.Descricao))
            {
                //teste
                return NoContent();
            }

            return Created(nameof(GetByDescricao), _cursoService.Add(curso));
        }

        /// <summary>
        /// Atualização de Curso.
        /// </summary>
        /// <param name="id">Parâmetro "id" do Curso.</param>
        /// <param name="curso">Parâmetro "Curso".</param>
        /// <response code="202">Registro criado.</response>
        /// <response code="204">Curso não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(void), 202)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCurso(int id, [FromBody] CursoViewModel curso)
        {
            if (curso == null || curso.Id != id)
            {
                return BadRequest();
            }

            var cursoVM = await _cursoService.GetByIdAsync(new CursoIdViewModel(id));

            if (cursoVM == null)
            {
                return NoContent();
            }

            _cursoService.Update(curso);

            return Accepted();
        }

        /// <summary>
        /// Exclusão de Curso.
        /// </summary>
        /// <param name="curso">Parâmetro "id" do Curso.</param>
        /// <response code="202">Registro criado.</response>
        /// <response code="204">Curso não encontrado.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(void), 202)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCurso([FromQuery] CursoIdViewModel curso)
        {
            var cursoVM = await _cursoService.GetByIdAsync(curso);

            if (cursoVM == null)
            {
                return NoContent();
            }

            _cursoService.Remove(cursoVM);

            return Accepted();
        }
    }
}