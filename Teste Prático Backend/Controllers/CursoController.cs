using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Teste_Prático_Backend.Controllers 
{
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        ICursoService cursos = new CursoService();

        private readonly ILogger<CursoController> _logger;

        public CursoController(ILogger<CursoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "CursoDetalhes")]
        public IEnumerable<Curso> GetCurso()
        {
            IEnumerable<Curso> curso = new List<Curso>();
            try
            {
                curso = cursos.GetAll();
            }
            catch (ApplicationException ex)
            {
                new HttpRequestException(ex.Message);
            }

            return curso;
        }

        [HttpPost(Name = "InserirCurso")]
        public string IserirCurso(Curso curso)
        {
            //string alunos1;
            try
            {
                this.cursos.Create(curso);
            }
            catch (ApplicationException ex)
            {
                new HttpRequestException(ex.Message);
            }

            return Ok(curso.Id).ToString();
        }

        [HttpPut(Name = "UpdateCurso")]
        public string UpdatreCurso(Curso curso)
        {
            try
            {
                this.cursos.Update(curso);
            }
            catch (Exception ex)
            {
                new HttpRequestException(ex.Message);
            }

            return Ok(curso.Id).ToString();
        }

        [HttpDelete(Name = "ExcluirCurso")]
        public string DeleteCurso(int id)
        {
            try
            {
                this.cursos.Delete(id);
            }
            catch (Exception ex)
            {
                new HttpRequestException(ex.Message);
            }

            return Ok(cursos).ToString();

        }
    }
}
