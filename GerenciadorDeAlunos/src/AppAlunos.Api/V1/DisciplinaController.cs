using AppAlunos.Api.Controllers;
using AppAlunos.Api.DTO;
using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppAlunos.Api.V1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DisciplinaController : MainController
    {
        private readonly IDisciplinaService _disciplinaService;
        private readonly IMapper _mapper;

        public DisciplinaController(IDisciplinaService disciplinaService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _disciplinaService = disciplinaService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarDisciplina(DisciplinaDTO disciplinaDto)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);

                var disciplina = _mapper.Map<Disciplina>(disciplinaDto);

                var result = await _disciplinaService.Adicionar(disciplina);

                if (!result) return BadRequest();

                return Ok(disciplina);
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
