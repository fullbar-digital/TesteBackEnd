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
    public class CursoController : MainController
    {
        private readonly ICursoService _cursoService;
        private readonly IMapper _mapper;

        public CursoController(ICursoService cursoService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _cursoService = cursoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarCurso([FromBody] CursoDTO cursoDto)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);

                var curso = _mapper.Map<Curso>(cursoDto);

                var result = await _cursoService.Adicionar(curso, cursoDto.DisciplinasDoCurso);

                if (!result) return BadRequest();

                return Ok(curso);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
