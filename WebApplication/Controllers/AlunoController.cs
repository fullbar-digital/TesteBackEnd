using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces.Service.Aluno.Aluno;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public IAlunoService _alunoService { get; set; }
        private readonly IMapper _mapper;

        public AlunoController(IAlunoService alunoService, IMapper mapper)
        {
            _alunoService = alunoService;
            _mapper = mapper;
        }

        #region Especifico

        [Route("ListarAlunos")]
        [HttpGet]
        public ActionResult<IEnumerable<ConvertAlunoDados>> ListarAlunos()
        {
            var alunos = _alunoService.ListarAlunos();

            var listAlunos = new List<ConvertAlunoDados>();

            foreach (var aluno in alunos)
            {
                listAlunos.Add(new ConvertAlunoDados(aluno));
            }

            return Ok(listAlunos);
        }

        [Route("FiltrarAlunos")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConvertAlunoDados>>> FiltrarAlunos(string filtrar, string parametro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrEmpty(filtrar) || string.IsNullOrEmpty(parametro))
                return BadRequest();
            try
            {
                var alunos = await _alunoService.FiltrarAlunos(filtrar, parametro);

                var listAlunos = new List<ConvertAlunoDados>();

                foreach (var aluno in alunos)
                {
                    listAlunos.Add(new ConvertAlunoDados(aluno));
                }

                return Ok(listAlunos);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion Especifico

        #region CRUD

        // GET: /Alunos/5
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> GetAluno(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _alunoService.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST api/<AlunoController>
        [HttpPost]
        public async Task<ActionResult> PostAluno([FromBody] AlunoDtoCreate aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _alunoService.Post(aluno);
                if (result != null)
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
                else
                    return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // PUT api/<AlunoController>/5
        [HttpPut]
        public async Task<ActionResult> PutAluno([FromBody] AlunoDtoUpdate aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _alunoService.Put(aluno);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAluno(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _alunoService.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion CRUD
    }
}