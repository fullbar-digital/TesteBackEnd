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
    public class DiciplinasController : ControllerBase
    {
        private readonly IDiciplinaService diciplinaService;

        public DiciplinasController(IDiciplinaService _diciplinaService)
        {
            diciplinaService = _diciplinaService;
        }
       [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var diciplina = await diciplinaService.GetAllDiciplinasAsync();
                if (diciplina == null) return NotFound("Nenhum diciplina encontrado.");

                return Ok(diciplina);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Cursos. Erro{ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Diciplina model)
        {
            try
            {
                var diciplina = await diciplinaService.AddDiciplinas(model);
                if (diciplina == null) return BadRequest("Erro ao Adicionar.");

                return Ok(diciplina);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao salvar dados. Erro{ex.Message}");
            };
        }
    }
}