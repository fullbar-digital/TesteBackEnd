using AutoMapper;
using Domain.Entities;
using Manager.API.commands;
using Manager.API.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISubjectSer _disciplinaServico;

        public SubjectController(IMapper mapper, ISubjectSer disciplinaServico)
        {
            _mapper = mapper;
            _disciplinaServico = disciplinaServico;
        }

        [HttpPost]
        [Route("/v1/subject/Create")]
        public async Task<IActionResult> Create([FromBody] SubjectVm subjectVMO)
        {
            try
            {
                var disciplinaDTO = _mapper.Map<SubjectDto>(subjectVMO);
                var disciplinaCriada = await _disciplinaServico.Create(disciplinaDTO);

                return Ok(new ModelResult
                {
                    Message = "Disciplina criada com sucesso!",
                    Success = true,
                    Data = disciplinaCriada
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
        [Route("/v1/subject/Edit")]
        public async Task<IActionResult> Edit([FromBody] SubjectDto subjectDTO)
        {
            try
            {
                var disciplinaEditada = await _disciplinaServico.Update(subjectDTO);

                return Ok(new ModelResult
                {
                    Message = "Disciplina Editada!",
                    Success = true,
                    Data = disciplinaEditada
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
        [Route("/v1/subject/Delete")]
        public async Task<IActionResult> Delete(int codigo)
        {
            try
            {
                await _disciplinaServico.Remove(codigo);

                return Ok(new ModelResult
                {
                    Message = "Disciplina Apagada!",
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
        [Route("/v1/subject/List")]
        public async Task<IActionResult> List(int codigo)
        {
            try
            {
                var disciplina = await _disciplinaServico.Get(codigo);

                return Ok(new ModelResult
                {
                    Message = "Disciplina Achada com sucesso!",
                    Success = true,
                    Data = disciplina
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
        [Route("/v1/subject/ListAll")]
        public async Task<IActionResult> ListAll()
        {
            try
            {
                var listSubject = await _disciplinaServico.Get();

                return Ok(new ModelResult
                {
                    Message = "Disciplina Achada com sucesso!",
                    Success = true,
                    Data = listSubject
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
