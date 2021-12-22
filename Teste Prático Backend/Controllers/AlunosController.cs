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
    public class AlunosController : ControllerBase
    {
        IAlunosService alunos = new AlunosService();

        private readonly ILogger<AlunosController> _logger;

        public AlunosController(ILogger<AlunosController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "AlunosDetalhes")]
        public IEnumerable<Alunos> GetAlunos()
        {
            IEnumerable<Alunos> aluno = new List<Alunos>();
            try
            {
                aluno = alunos.GetAll();
            }
            catch (ApplicationException ex)
            {
                new HttpRequestException(ex.Message);
            }

            return aluno;
        }

        [HttpPost(Name = "InserirAlunos")]
        public string IserirAlunos(Alunos alunos)
        {
            //string alunos1;
            try
            {
                this.alunos.Create(alunos);
            }
            catch (ApplicationException ex)
            {
                new HttpRequestException(ex.Message);
            }

            return Ok(alunos.Id).ToString();
        }

        [HttpPut(Name = "UpdateAlunos")]
        public string UpdatreAlunos(Alunos alunos)
        {
            try
            {
                this.alunos.Update(alunos);
            }
            catch (Exception ex)
            {
                new HttpRequestException(ex.Message);
            }

            return Ok(alunos.Id).ToString();
        }

        [HttpDelete(Name = "ExcluirAlunos")]
        public string DeleteAluno(int id)
        {
            try
            {
                this.alunos.Delete(id);
            }
            catch (Exception ex)
            {
                new HttpRequestException(ex.Message);
            }

            return Ok(alunos).ToString();

        }
    }
}
