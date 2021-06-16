using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School_Manager.Domain;
using School_Manager.Application.Interface;
using Microsoft.AspNetCore.Http;

namespace School_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService cursoService;

        public CursosController(ICursoService _cursoService)
        {
            cursoService = _cursoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Curso = await cursoService.GetAllCursosAsync();
                if (Curso == null) return NotFound("Nenhum Curso encontrado.");

                return Ok(Curso);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Cursos. Erro{ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Curso model)
        {
            try
            {
                var curso = await cursoService.AddCurso(model);
                if (curso == null) return BadRequest("Erro ao Adicionar.");

                return Ok(curso);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao salvar dados. Erro{ex.Message}");
            };
        }
    }
}