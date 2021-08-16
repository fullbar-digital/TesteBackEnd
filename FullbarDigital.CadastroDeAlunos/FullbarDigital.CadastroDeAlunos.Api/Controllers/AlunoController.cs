using FullbarDigital.CadastroDeAlunos.Dominio.Interfaces;
using FullbarDigital.CadastroDeAlunos.Dominio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullbarDigital.CadastroDeAlunos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet("alunos")]
        public ActionResult<List<Aluno>> GetAlunos(string nome, string ra, string curso, string status)
        {
            var result = _alunoService.GetAlunos(nome, ra, curso, status);
            return result;
        } 
        
        [HttpPut("aluno")]
        public ActionResult<long> UpdateAluno(Aluno aluno)
        {
            _alunoService.UpdateAluno(aluno);
            return Ok();
        }

        [HttpPut("historico")]
        public ActionResult<long> UpdateHistorico(Historico historico)
        {
            _alunoService.UpdateHistorico(historico);
            return Ok();
        }

        [HttpGet("historico/{idAluno}")]
        public ActionResult<List<Historico>> GetHistorico(long idAluno)
        {
            return Ok(_alunoService.GetHistorico(idAluno));
        }

        [HttpDelete("deletar/{id}")]
        public ActionResult DeleteAluno(long id)
        {
            _alunoService.DeleteAluno(id);
            return Ok();
        }
    }
}
