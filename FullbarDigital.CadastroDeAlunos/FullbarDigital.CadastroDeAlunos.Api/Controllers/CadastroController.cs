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
    public class CadastroController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public CadastroController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost("aluno")]
        public ActionResult<long> AddAluno(Aluno aluno)
        {
            var result = _alunoService.InsertAluno(aluno);
            return result;
        }

        [HttpPost("curso")]
        public ActionResult<long> AddCurso(Curso curso)
        {
            var result = _alunoService.InsertCurso(curso);
            return result;
        }

        [HttpPost("diciplina")]
        public ActionResult<long> AddDiciplina(Diciplina diciplina)
        {
            var result = _alunoService.InsertDiciplina(diciplina);
            return result;
        }
    }
}
