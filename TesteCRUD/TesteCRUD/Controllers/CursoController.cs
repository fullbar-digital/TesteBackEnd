using API.Utilities;
using API.ViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Servico.DTO;
using Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCRUD.ViewModel;

namespace TesteCRUD.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICursoServico _cursoServico;

        public CursoController(IMapper mapper, ICursoServico cursoServico)
        {
            _mapper = mapper;
            _cursoServico = cursoServico;
        }

        [HttpPost]
        [Route("/v1/curso/criar")]
        public async Task<IActionResult> Criar([FromBody] CriarCursoVM cursoVM)
        {
            try
            {
                var cursoDTO = _mapper.Map<CursoDTO>(cursoVM);
                var cursoCriado = await _cursoServico.Create(cursoDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Curso criado com sucesso",
                    Success = true,
                    Data = cursoCriado
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage(ex));
            }
        }

        [HttpPut]
        [Route("/v1/curso/atualiza")]
        public async Task<IActionResult> Editar([FromBody] CursoDTO cursoDTO)
        {
            try
            {
                var cursoEditado = await _cursoServico.Update(cursoDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Curso Editado com sucesso",
                    Success = true,
                    Data = cursoEditado
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage(ex));
            }
        }

        [HttpDelete]
        [Route("/v1/curso/apaga")]
        public async Task<IActionResult> Apaga(int codigo)
        {
            try
            {
                await _cursoServico.Remove(codigo);

                return Ok(new ResultViewModel
                {
                    Message = "Curso Apagado com sucesso",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage(ex));
            }
        }
        [HttpGet]
        [Route("/v1/curso/lista")]
        public async Task<IActionResult> Lista(int codigo)
        {
            try
            {
                var curso = await _cursoServico.Get(codigo);

                return Ok(new ResultViewModel 
                { 
                    Message = "Consulta feita com sucesso",
                    Success = true,
                    Data = curso
                });
            }
            catch (DomainException ex)
            {
                return (BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors)));
            }
            catch (Exception ex)
            {
                return (StatusCode(500, Responses.ApplicationErrorMessage(ex)));
            }
        }

        [HttpGet]
        [Route("/v1/curso/listaTodos")]
        public async Task<IActionResult> ListaTodos()
        {
            try
            {
                var cursos = await _cursoServico.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Consulta feita com sucesso",
                    Success = true,
                    Data = cursos
                });
            }
            catch (DomainException ex)
            {
                return (BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors)));
            }
            catch (Exception ex)
            {
                return (StatusCode(500, Responses.ApplicationErrorMessage(ex)));
            }
        }

        [HttpDelete]
        [Route("/v1/curso/removerDisciplina")]
        public async Task<IActionResult> RemoverDisciplina([FromBody] CursoDisciplinaDTO cursoDisciplinaDTO)
        {
            try
            {
                await _cursoServico.DelDisciplina(cursoDisciplinaDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Disciplina removida com sucesso",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage(ex));
            }
        }
    }
}
