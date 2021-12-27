using API.Utilities;
using API.ViewModel.Aluno;
using API.ViewModel.Disciplina;
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

namespace API.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAlunoServico _alunoServico;
        public AlunoController(IMapper mapper, IAlunoServico alunoServico)
        {
            _mapper = mapper;
            _alunoServico = alunoServico;
        }

        [HttpPost]
        [Route("/v1/aluno/criar")]
        public async Task<IActionResult> Criar([FromBody] CriarAlunoVM criarAlunoVM)
        {
            try
            {
                var alunoDTO = _mapper.Map<AlunoDTO>(criarAlunoVM);
                var alunoCriado = await _alunoServico.Create(alunoDTO);

                return Ok(new ResultViewModel 
                { 
                    Message = "Aluno criado com sucesso",
                    Success = true,
                    Data = alunoCriado
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
        [Route("/v1/aluno/editar")]
        public async Task<IActionResult> Editar ([FromBody] AlunoDTO alunoDTO)
        {
            try
            {
                var alunoEditado = await _alunoServico.Update(alunoDTO);

                return Ok(new ResultViewModel 
                {
                    Message =  "Aluno Editado com sucesso",
                    Success = true,
                    Data = alunoDTO
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
        [Route("/v1/aluno/apaga")]
        public async Task<IActionResult> Apaga(int codigo)
        {
            try
            {
                await _alunoServico.Remove(codigo);

                return Ok(new ResultViewModel
                {
                    Message = "Aluno Apagado!",
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
        [Route("/v1/aluno/Lista")]
        public async Task<IActionResult> Lista(int codigo)
        {
            try
            {
                var aluno = await _alunoServico.Get(codigo);

                return Ok(new ResultViewModel
                {
                    Message = "aluno Achado com sucesso!",
                    Success = true,
                    Data = aluno
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
        [Route("/v1/aluno/ListaPorNome")]
        public async Task<IActionResult> ListaPorNome(string nome)
        {
            try
            {
                var aluno = await _alunoServico.ListaPorNome(nome);

                return Ok(new ResultViewModel
                {
                    Message = "aluno Achado com sucesso!",
                    Success = true,
                    Data = aluno
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
        [Route("/v1/aluno/ListaPorRA")]
        public async Task<IActionResult> ListaPorRA(string ra)
        {
            try
            {
                var aluno = await _alunoServico.ListaPorRA(ra);

                return Ok(new ResultViewModel
                {
                    Message = "aluno Achado com sucesso!",
                    Success = true,
                    Data = aluno
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

        //
        [HttpGet]
        [Route("/v1/aluno/ListaPorCurso")]
        public async Task<IActionResult> ListaPorCurso(string NomeCurso)
        {
            try
            {
                var aluno = await _alunoServico.ListaPorCurso(NomeCurso);

                return Ok(new ResultViewModel
                {
                    Message = "aluno Achado com sucesso!",
                    Success = true,
                    Data = aluno
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
        [Route("/v1/aluno/ListaPorStatus")]
        public async Task<IActionResult> ListaPorStatus(string status)
        {
            try
            {
                var aluno = await _alunoServico.ListaPorStatus(status);

                return Ok(new ResultViewModel
                {
                    Message = "aluno Achado com sucesso!",
                    Success = true,
                    Data = aluno
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
        [Route("/v1/aluno/ListaTodas")]
        public async Task<IActionResult> ListaTodas()
        {
            try
            {
                var listaAluno = await _alunoServico.Get();

                return Ok(new ResultViewModel
                {
                    Message = "aluno Achado com sucesso!",
                    Success = true,
                    Data = listaAluno
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

        /*---------------------------------------------------------------------------*/
        [HttpPut]
        [Route("/v1/aluno/adicionaNota")]
        public async Task<IActionResult> AdicionaNota([FromBody] AlunoDisciplinaVM adicionaDisciplinaDTO)
        {
            try
            {
                var alunoDisciplina = _mapper.Map<AlunoDisciplinaDTO>(adicionaDisciplinaDTO);
                var DisciplinaAdicionada = await _alunoServico.AdicionaNota(alunoDisciplina);

                return Ok(new ResultViewModel
                {
                    Message = "Nota Adicionada com sucesso",
                    Success = true,
                    Data = DisciplinaAdicionada
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
