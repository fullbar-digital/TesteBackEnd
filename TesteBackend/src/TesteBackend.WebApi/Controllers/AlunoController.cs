using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using TesteBackend.Domain.Exceptions;
using TesteBackend.Domain.Models;
using TesteBackend.Domain.Repositories;
using TesteBackend.WebApi.Dtos.AlunoDtos;

namespace TesteBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IMapper mapper, IAlunoRepository alunoRepository,
            ICursoRepository cursoRepository)
        {
            this._mapper = mapper;
            this._alunoRepository = alunoRepository;
        }

        /// <summary>
        /// Cadastrar aluno, matricular no curso e lançar nota nas disciplinas
        /// </summary>
        /// <param name="alunoCreateDto">Modelo do aluno para cadastro</param>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     {
        ///         "nome": "Nome do aluno",
        ///     	"periodo": 1,
        ///     	"cursoid": 2,
        ///     	"matricula": [
        ///     		{
        ///     			"disciplinaid": 2,
        ///     			"nota": 7.0
        ///             }
        ///     	],
        ///     	"foto": "http://meusite/fotodoaluno.jpg"
        ///     }
        ///     
        /// </remarks>
        /// <returns>Novo aluno cadastrado</returns>
        /// <response code="201">Retorna o novo aluno cadastrado</response>
        /// <response code="404">Curso e/ou nota de disciplina não encontrada</response>
        /// <response code="400">Falha ao tentar cadastrar item</response>
        [HttpPost]
        [ProducesResponseType(typeof(AlunoDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult AddAluno([FromBody] AlunoCreateDto alunoCreateDto)
        {
            try
            {
                Aluno alunoModel = this._mapper.Map<Aluno>(alunoCreateDto);

                Aluno alunoNovo = this._alunoRepository.Add(alunoModel);

                var alunoDto = this._mapper.Map<AlunoDto>(alunoNovo);

                return StatusCode((int)HttpStatusCode.Created, alunoDto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return Problem(statusCode: (int)HttpStatusCode.BadRequest, title: ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(statusCode: (int)HttpStatusCode.BadRequest, title: ex.Message);
            }
        }

        /// <summary>
        /// Lista os dados do aluno
        /// </summary>
        /// <param name="ra">Registro Acadêmico (RA) do aluno</param>
        /// <returns>Dados do aluno</returns>
        /// <response code="200">Retorna dados do aluno</response>
        /// <response code="404">Aluno não localizado</response>
        [HttpGet("{ra}")]
        [ProducesResponseType(typeof(AlunoDto), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetAluno([FromRoute]int ra)
        {
            var alunoDb = this._alunoRepository.Get(ra);

            if (alunoDb is null)
                return NotFound();

            AlunoDto alunoDto = this._mapper.Map<AlunoDto>(alunoDb);
            return Ok(alunoDto);
        }

        /// <summary>
        /// Lista os dados dos alunos consultados
        /// </summary>
        /// <param name="ra">Registro Acadêmico (RA) do aluno</param>
        /// <param name="nome">Nome do aluno</param>
        /// <param name="cursoId">Identificador do curso</param>
        /// <param name="status">Status do aluno</param>
        /// <returns>Lista de aluno consultados</returns>
        /// <response code="200">Retorna lista de alunos consultados</response>
        /// <response code="404">Dados não localizados</response>
        [HttpGet]
        [ProducesResponseType(typeof(IList<AlunoDto>), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetAluno([FromQuery] int? ra, string nome, int? cursoId, StatusResult? status)
        {
            Func<Aluno, bool> filtro = a => a.Ra > 0;
            
            if (ra is not null)
                filtro = a => a.Ra == ra;

            if (nome is not null)
                filtro += a => a.Nome.Contains(nome);

            if (cursoId is not null)
                filtro += a => a.CursoId == cursoId;

            if (status is not null)
                filtro += a => a.Status == status;

            var alunosList = this._alunoRepository.GetAluno(filtro);

            if (alunosList.Count == 0)
                return NotFound();
            
            var alunosCtoList = this._mapper.Map<IList<AlunoDto>>(alunosList);
            return Ok(alunosCtoList);
        }

        /// <summary>
        /// Altera os dados do aluno
        /// </summary>
        /// <param name="alunoEditDto">Modelo do aluno para alteração</param>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     {
        ///         "ra": 1,
        ///         "nome": "Novo nome do aluno",
        ///     	"periodo": 1,
        ///     	"matricula": [
        ///     		{
        ///     			"disciplinaid": 1,
        ///     			"nota": 7
        ///             }
        ///     	],
        ///     	"foto": "http://google.com/foto/joelma.jpg"
        ///     }
        ///     
        /// </remarks>
        /// <returns>Retorna aluno com os dados alterados</returns>
        /// <response code="200">Retorna o aluno alterado</response>
        /// <response code="404">Aluno não encontrado</response>
        /// <response code="400">Falha ao tentar alterar item</response>
        [HttpPut]
        [ProducesResponseType(typeof(AlunoDto),404)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult EditAluno([FromBody] AlunoEditDto alunoEditDto)
        {
            try
            {
                Aluno alunoEdit = this._mapper.Map<Aluno>(alunoEditDto);
                Aluno alunoDb = this._alunoRepository.Edit(alunoEdit);
                AlunoDto alunoDto = this._mapper.Map<AlunoDto>(alunoDb);
                return Ok(alunoDto);
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
        /// Remove aluno
        /// </summary>
        /// <param name="ra">Registro Acadêmico (RA) do aluno</param>
        /// <response code="200">Aluno removido com sucesso</response>
        /// <response code="404">Aluno não encontrado</response>
        /// <response code="400">Falha ao tentar remover item</response>
        [HttpDelete("{ra}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult RemoveAluno(int ra)
        {
            try
            {
                if (ra <= 0)
                    return Problem(statusCode: (int)HttpStatusCode.BadRequest, title: "Valor inválido para RA");

                this._alunoRepository.Remove(ra);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return Problem(statusCode: (int)HttpStatusCode.NotFound, title: ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(statusCode: (int)HttpStatusCode.BadRequest, title: ex.Message);
            }
        }
    }
}
