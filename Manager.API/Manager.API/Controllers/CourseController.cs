using Manager.API.commands;
using Manager.API.Model;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TesteCRUD.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICourseSer _cursoServico;

        public CursoController(IMapper mapper, ICourseSer cursoServico)
        {
            _mapper = mapper;
            _cursoServico = cursoServico;
        }

        [HttpPost]
        [Route("/v1/Course/Create")]
        public async Task<IActionResult> Create([FromBody] CreateCourse cursoVM)
        {
            try
            {
                var cursoDTO = _mapper.Map<CourseDto>(cursoVM);
                var cursoCriado = await _cursoServico.Create(cursoDTO);

                return Ok(new ModelResult
                {
                    Message = "Curso criado com sucesso",
                    Success = true,
                    Data = cursoCriado
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
            }
        }

        [HttpPut]
        [Route("/v1/Course/Update")]
        public async Task<IActionResult> Update([FromBody] CourseDto cursoDTO)
        {
            try
            {
                var cursoEditado = await _cursoServico.Update(cursoDTO);

                return Ok(new ModelResult
                {
                    Message = "Curso Editado com sucesso",
                    Success = true,
                    Data = cursoEditado
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
            }
        }

        [HttpDelete]
        [Route("/v1/Course/Delete")]
        public async Task<IActionResult> Apaga(int codigo)
        {
            try
            {
                await _cursoServico.Remove(codigo);

                return Ok(new ModelResult
                {
                    Message = "Curso Apagado com sucesso",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
            }
        }
        [HttpGet]
        [Route("/v1/Course/List")]
        public async Task<IActionResult> List(int codigo)
        {
            try
            {
                var curso = await _cursoServico.Get(codigo);

                return Ok(new ModelResult
                {
                    Message = "Consulta feita com sucesso",
                    Success = true,
                    Data = curso
                });
            }
            catch (DomainException ex)
            {
                return (BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors)));
            }
            catch (Exception ex)
            {
                return (StatusCode(500, CommandsResult.ApplicationErrorMessage(ex)));
            }
        }

        [HttpGet]
        [Route("/v1/Course/ListAll")]
        public async Task<IActionResult> ListAll()
        {
            try
            {
                var cursos = await _cursoServico.Get();

                return Ok(new ModelResult
                {
                    Message = "Consulta feita com sucesso",
                    Success = true,
                    Data = cursos
                });
            }
            catch (DomainException ex)
            {
                return (BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors)));
            }
            catch (Exception ex)
            {
                return (StatusCode(500, CommandsResult.ApplicationErrorMessage(ex)));
            }
        }

        [HttpDelete]
        [Route("/v1/Course/DeleteSubject")]
        public async Task<IActionResult> DeleteSubject([FromBody] CourseSubjectDto cursoDisciplinaDTO)
        {
            try
            {
                await _cursoServico.DeleteSubject(cursoDisciplinaDTO);

                return Ok(new ModelResult
                {
                    Message = "Disciplina removida com sucesso",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
            }
        }
    }
}
