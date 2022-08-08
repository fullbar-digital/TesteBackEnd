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
    public class AlunosController : ControllerBase
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

        [HttpPost]
        public async Task<ActionResult<AlunoVO>> Create(AlunoVO vo)
        {
            
            if (vo == null) return BadRequest();
            var aluno = await _repository.Create(vo);
            return Ok(aluno);
        }

        [HttpPut]
        public async Task<ActionResult<AlunoVO>> Update(AlunoVO vo)
        {

            if (vo == null) return BadRequest();
            var aluno = await _repository.Update(vo);
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
