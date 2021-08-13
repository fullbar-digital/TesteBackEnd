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

        [HttpPost("curso")]
        public ActionResult<long> AddCurso(Curso curso)
        {
            return _alunoService.InsertCurso(curso);
        }
    }
}
