using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using TesteBackend.Domain.Exceptions;
using TesteBackend.Domain.Models;
using TesteBackend.Domain.Repositories;
using TesteBackend.WebApi.Dtos.DisciplinaDtos;

namespace TesteBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly ICursoRepository _cursoRepository;

        public DisciplinaController(IMapper mapper, IDisciplinaRepository disciplinaRepository,
            ICursoRepository cursoRepository)
        {
            this._mapper = mapper;
            this._disciplinaRepository = disciplinaRepository;
            this._cursoRepository = cursoRepository;
        }

        /// <summary>
        /// Cadastrar disciplina
        /// </summary>
        /// <param name="disciplinaCreateDto">Modelo da disciplina para cadastro</param>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     {
        ///         "nome": "Nome da disciplina",
        ///         "cursoid": 1
        ///     }
        ///     
        /// </remarks>
        /// 
        /// <returns>Retorna disciplina cadastrada</returns>
        /// <response code="201">Retorna a nova disciplina cadastrada</response>
        /// <response code="404">Curso e/ou nota de disciplina não encontrada</response>
        /// <response code="400">Falha ao tentar cadastrar item</response>
        /// <response code="500">Falha do servidor</response>
        [HttpPost]
        [ProducesResponseType(typeof(DisciplinaFullDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult AdicionarDisciplina([FromBody] DisciplinaCreateDto disciplinaCreateDto)
        {
            try
            {
                var cursoDb = this._cursoRepository.Get(disciplinaCreateDto.CursoId);

                if (cursoDb is null)
                    return Problem(statusCode: (int)HttpStatusCode.NotFound, title: "Curso não encontrado para vincular disciplina");

                var disciplinaNova = new Disciplina(disciplinaCreateDto.Nome, cursoDb);
                this._disciplinaRepository.Add(disciplinaNova);

                DisciplinaFullDto disciplinaFullDto = this._mapper.Map<DisciplinaFullDto>(disciplinaNova);
                return StatusCode((int)HttpStatusCode.Created, disciplinaFullDto);
            }
            catch (OperationCanceledException ex)
            {
                return Problem(statusCode: (int)HttpStatusCode.BadRequest, title: ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(statusCode: (int)HttpStatusCode.InternalServerError, title: ex.Message);
            }
        }

        /// <summary>
        /// Lista disciplina consultada
        /// </summary>
        /// <param name="disciplinaId">Identificador da disciplina</param>
        /// <returns>Retorna disciplina</returns>
        /// <response code="200">Retorna dados da disciplina</response>
        /// <response code="404">Disciplina não localizada</response>
        [HttpGet("{disciplinaId}")]
        [ProducesResponseType(typeof(DisciplinaFullDto), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetDisciplinaById(int disciplinaId)
        {
            Disciplina disciplinaDb = this._disciplinaRepository.Get(disciplinaId);

            if (disciplinaDb is null)
                return Problem(statusCode: (int)HttpStatusCode.NotFound, title: "Disciplina não encontrada");

            DisciplinaFullDto disciplinaFullDto = this._mapper.Map<DisciplinaFullDto>(disciplinaDb);
            
            return Ok(disciplinaFullDto);
        }

        /// <summary>
        /// Excluir disciplina
        /// </summary>
        /// <param name="disciplinaId">Identificador da disciplina</param>
        /// <response code="200">Disciplina excluída</response>
        /// <response code="404">Disciplina não localizada</response>
        /// <response code="400">Operação não permitida</response>
        /// <response code="500">Problema interno</response>
        [HttpDelete("{disciplinaId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult DeleteDisciplina(int disciplinaId)
        {
            try
            {
                this._disciplinaRepository.Delete(disciplinaId);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return Problem(statusCode: (int)HttpStatusCode.NotFound, title: ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(statusCode: (int)HttpStatusCode.InternalServerError, title: ex.Message);
            }
        }

    }
}
