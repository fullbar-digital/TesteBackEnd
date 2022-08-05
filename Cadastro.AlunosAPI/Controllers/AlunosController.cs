using Cadastro.AlunosAPI.Data.ValueObject;
using Cadastro.AlunosAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.AlunosAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    class AlunosController : ControllerBase
    {
        private readonly IAlunosRepository _repository;

        public AlunosController(IAlunosRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("api/get-customer")]
        public async Task<ActionResult<IEnumerable<AlunoVO>>> FindAll()
        {
            var alunos = await _repository.FindAll();
            return Ok(alunos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoVO>> FindById(long id)
        {
            var aluno = await _repository.FindById(id);
            if (aluno == null) return NotFound();
            return Ok(aluno);
        }
    }
}
