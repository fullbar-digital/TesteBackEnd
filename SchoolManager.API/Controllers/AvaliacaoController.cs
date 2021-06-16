using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School_Manager.Application.Interface;
using Microsoft.AspNetCore.Http;
using School_Manager.Domain;

namespace School_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IDiciplinaAlunoService diciplinaAlunoService;
        private readonly IAlunosService alunosService;
        private readonly IDiciplinaService diciplinaService;

        public AvaliacaoController(IDiciplinaAlunoService _diciplinaAlunoService, IAlunosService _alunosService, IDiciplinaService _diciplinaService)
        {
            diciplinaAlunoService = _diciplinaAlunoService;
            alunosService = _alunosService;
            diciplinaService = _diciplinaService;
        }
       
        
        [HttpPost]
        public async Task<IActionResult> Post(DiciplinaAluno model)
        {
            try
            {
                var diciplinaAluno = await diciplinaAlunoService.AddDiciplinaAlunos(model);
                if (diciplinaAluno == null) return BadRequest("Erro ao Adicionar.");
                var diciplina = await diciplinaService.GetAllDiciplinaByIDAsync(model.DiciplinaId);
                if(diciplina.Nota_min > model.Nota)
                {
                    var dados = await alunosService.GetAllAlunoByIDAsync(model.AlunoId);
                    dados.SetStatus(true);
                    var aluno = await alunosService.UpdateAluno(model.AlunoId, dados);
                }

                return Ok(diciplinaAluno);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao salvar dados. Erro{ex.Message}");
            };
        }
    }
}