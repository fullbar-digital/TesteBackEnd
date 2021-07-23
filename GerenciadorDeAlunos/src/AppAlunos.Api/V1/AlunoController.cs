using AppAlunos.Api.Controllers;
using AppAlunos.Api.DTO;
using AppAlunos.Api.Models.Request;
using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Models;
using AppAlunos.Business.Models.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAlunos.Api.V1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AlunoController : MainController
    {
        private readonly IAlunoService _alunoService;
        private readonly IMapper _mapper;


        public AlunoController(IAlunoService alunoService,
            IMapper mapper, INotificador notificador) : base(notificador)
        {
            _alunoService = alunoService;
            _mapper = mapper;
        }

        [Route("ListarAlunos")]
        [HttpGet]
        public ActionResult<IEnumerable<AlunoResponse>> ListarAlunos()
        {
            try
            {
                var alunos = _alunoService.ListarAlunos();

                return CustomResponse(alunos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("filtro")]
        [HttpGet]
        public ActionResult<IEnumerable<AlunoResponse>> ListarPorFiltro(string filtro, string valor)
        {
            try
            {
                var alunos = _alunoService.ListarPorFiltro(filtro, valor);

                return CustomResponse(alunos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarAluno(AlunoRequest alunoRequest)
        {
            try
            {

                if (!ModelState.IsValid) return BadRequest();

                var result = await _alunoService.Adicionar(alunoRequest);

                if (result == null) return BadRequest();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult> AtualizarAluno(Guid id, [FromBody] AlunoDTO alunoDto)
        {
            try
            {
                if (id != alunoDto.Id)
                {
                    NotificarErro("O id informado não é o mesmo que foi passado na query");
                    return CustomResponse(alunoDto);
                }

                if (!ModelState.IsValid) return CustomResponse(ModelState);

                var aluno = _mapper.Map<Aluno>(alunoDto);

                var result = await _alunoService.Atualizar(aluno);

                if (!result) return NotFound();

                return CustomResponse(aluno);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> DeletarAluno(Guid id)
        {
            try
            {
                var result = await _alunoService.Remover(id);

                if (!result) return BadRequest();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
