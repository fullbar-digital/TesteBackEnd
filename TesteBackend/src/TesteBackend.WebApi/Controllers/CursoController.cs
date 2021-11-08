using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using TesteBackend.Domain.Exceptions;
using TesteBackend.Domain.Models;
using TesteBackend.Domain.Repositories;
using TesteBackend.WebApi.Dtos;
using TesteBackend.WebApi.Dtos.CursoDtos;

namespace TesteBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICursoRepository _cursoRepository;

        public CursoController(IMapper mapper, ICursoRepository cursoRepository)
        {
            this._mapper = mapper;
            this._cursoRepository = cursoRepository;
        }

        /// <summary>
        /// Cadastrar curso
        /// </summary>
        /// <param name="cursoCreateDto">Modelo de curso para cadastro</param>
        /// <returns>Retorna curso cadastrado</returns>
        /// <remarks>
        /// 
        /// Exemplo:
        /// 
        ///     {
        ///     	"nome": "Nome da disciplina"
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Retorna o novo curso cadastrado</response>
        /// <response code="400">Falha ao tentar cadastrar item</response>
        /// <response code="500">Falha do servidor</response>
        [HttpPost]
        [ProducesResponseType(typeof(CursoDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult AddCurso([FromBody] CursoCreateDto cursoCreateDto)
        {
            try
            {
                Curso curso = this._mapper.Map<Curso>(cursoCreateDto);

                this._cursoRepository.Add(curso);

                CursoDto cursoDto = this._mapper.Map<CursoDto>(curso);
                return StatusCode((int)HttpStatusCode.Created, cursoDto);
            }
            catch (ArgumentNullException ex)
            {
                return Problem(statusCode: (int)HttpStatusCode.BadRequest, title: ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(statusCode: (int)HttpStatusCode.InternalServerError, title: ex.Message);
            }
        }

        /// <summary>
        /// Editar curso
        /// </summary>
        /// <param name="cursoEditDto">Modelo para alteração do curso</param>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     {
        ///         "id": 3,
	    ///         "nome": "Novo nome do curso"
        ///     }
        ///     
        /// </remarks>
        /// <returns>Retorna o curso após alteração</returns>
        /// <response code="200">Retorna curso</response>
        /// <response code="404">Curso não encontrado</response>
        /// <response code="400">Falha ao tentar alterar o item</response>
        [HttpPut]
        [ProducesResponseType(typeof(CursoDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult EditCurso([FromBody] CursoEditDto cursoEditDto)
        {
            try
            {
                Curso curso = this._mapper.Map<Curso>(cursoEditDto);

                var cursoDb = this._cursoRepository.Edit(curso);

                CursoDto cursoDto = this._mapper.Map<CursoDto>(cursoDb);

                return Ok(cursoDto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(statusCode: (int)HttpStatusCode.BadRequest, title: ex.Message);
            }
        }

        /// <summary>
        /// Retornar curso
        /// </summary>
        /// <param name="cursoId">Identificador do curso</param>
        /// <returns>Retorna os dados do curso</returns>
        /// <response code="200">Retorna curso</response>
        /// <response code="404">Curso não encontrado</response>
        [HttpGet("{cursoId}")]
        [ProducesResponseType(typeof(CursoFullDto), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetCursoByid(int cursoId)
        {
            Curso cursoDb = this._cursoRepository.Get(cursoId);

            if (cursoDb is null)
                return NotFound();

            CursoFullDto cursoReadFullDto = this._mapper.Map<CursoFullDto>(cursoDb);
            return Ok(cursoReadFullDto);
        }

        /// <summary>
        /// Remover curso
        /// </summary>
        /// <param name="cursoId">Identificador do curso</param>
        /// <response code="200">Curso removido</response>
        /// <response code="404">Curso não encontrado</response>
        /// <response code="400">Falha ao tentar remover</response>
        [HttpDelete("{cursoId}")]
        public IActionResult DeleteCurso(int cursoId)
        {
            try
            {
                this._cursoRepository.Delete(cursoId);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(statusCode: (int)HttpStatusCode.BadRequest, title: ex.Message);
            }
        }

    }
}
