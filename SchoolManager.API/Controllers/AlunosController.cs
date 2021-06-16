using Microsoft.AspNetCore.Mvc;
using School_Manager.Domain;
using School_Manager.Application.Interface;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace School_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunosService alunoService;

        public AlunosController(IAlunosService _alunoService)
        {
            alunoService = _alunoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var alunos = await alunoService.GetAllAlunosAsync();
                if (alunos == null) return NotFound("Nenhum Aluno encontrado.");

                return Ok(alunos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Alunos. Erro{ex.Message}");
            }
        }

        [HttpGet("/buscar")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var aluno = await alunoService.GetAllAlunosAsync();
                if (aluno == null) return NotFound("Nenhum Aluno encontrado.");

                return Ok(aluno);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Alunos. Erro{ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
        {
            try
            {
                var aluno = await alunoService.AddAlunos(model);
                if (aluno == null) return BadRequest("Erro ao Adicionar.");

                return Ok(aluno);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao salvar dados. Erro{ex.Message}");
            };
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Aluno model)
        {
             try
            {
                var aluno = await alunoService.UpdateAluno(id, model);
                if (aluno == null) return BadRequest("Erro ao Adicionar.");

                return Ok(aluno);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar dados. Erro{ex.Message}");
            };
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Deletado(int id)
        {
              try
            {
               return await alunoService.DeleteAluno(id) ?
                    Ok("Aluno foi Removido.") :
                    BadRequest("Aluno não foi Deletado.");
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao remover dados. Erro{ex.Message}");
            };
        }
    }
}