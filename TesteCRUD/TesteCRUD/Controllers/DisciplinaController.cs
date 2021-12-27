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
    public class DisciplinaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDisciplinaServico _disciplinaServico;

        public DisciplinaController(IMapper mapper, IDisciplinaServico disciplinaServico)
        {
            _mapper = mapper;
            _disciplinaServico = disciplinaServico;
        }

        [HttpPost]
        [Route("/v1/disciplina/criar")]
        public async Task<IActionResult> Criar([FromBody] DisciplinaVm disciplinaVMO)
        {
            try
            {
                var disciplinaDTO = _mapper.Map<DisciplinaDTO>(disciplinaVMO);
                var disciplinaCriada = await _disciplinaServico.Create(disciplinaDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Disciplina criada com sucesso!",
                    Success = true,
                    Data = disciplinaCriada
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
        [Route("/v1/disciplina/editar")]
        public async Task<IActionResult> Editar([FromBody] DisciplinaDTO disciplinaDTO)
        {
            try
            {
                var disciplinaEditada = await _disciplinaServico.Update(disciplinaDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Disciplina Editada!",
                    Success = true,
                    Data = disciplinaEditada
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
        [Route("/v1/disciplina/apaga")]
        public async Task<IActionResult> Apaga(int codigo)
        {
            try
            {
                await _disciplinaServico.Remove(codigo);

                return Ok(new ResultViewModel
                {
                    Message = "Disciplina Apagada!",
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
        [Route("/v1/disciplina/Lista")]
        public async Task<IActionResult> Lista(int codigo)
        {
            try
            {
                var disciplina = await _disciplinaServico.Get(codigo);

                return Ok(new ResultViewModel
                {
                    Message = "Disciplina Achada com sucesso!",
                    Success = true,
                    Data = disciplina
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
        [Route("/v1/disciplina/ListaTodas")]
        public async Task<IActionResult> ListaTodas()
        {
            try
            {
                var listaDisciplina = await _disciplinaServico.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Disciplina Achada com sucesso!",
                    Success = true,
                    Data = listaDisciplina
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
