using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunosContext _context;

        public AlunoController(AlunosContext context)
        {
            _context = context;
        }

        // GET /Aluno/PaginateAll
        //[HttpGet]
        //[Route("PaginateAll")]
        //public IHttpActionResult PaginateAll([FromUri] AlunosFilter filter, [FromUri] int page = 1, [FromUri] int itensPerPage = 30)
        //{
        //    var paginator = PaginateAll(filter, page, itensPerPage);

        //     var AlunoDAO = new AlunoContext(connectionString, Dao.Db);

        //}

        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> Get()
        {
            return Ok(await _context.Alunos.ToListAsync());
        }   

        [HttpGet("{id}")]
        
        public async Task<ActionResult<Aluno>> Get(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return BadRequest("Aluno not found.");
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<List<Aluno>>> AddAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return Ok(await _context.Alunos.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Aluno>>> UpdateAluno(Aluno request)
        {
            var dbAluno = await _context.Alunos.FindAsync(request.AlunoID);
            if (dbAluno == null)
                return BadRequest("Aluno not found.");

            
            if (dbAluno == dbAluno)
            {
                dbAluno.AlunoID = request.AlunoID;
                dbAluno.Nome = request.Nome;
                dbAluno.RA = request.RA;
                dbAluno.Periodo = request.Periodo;
                dbAluno.Status = request.Status;
                dbAluno.Foto = request.Foto;
                dbAluno.Curso = request.Curso;
                dbAluno.CursoID = request.CursoID;

                if (dbAluno.CursoID != dbAluno.CursoID)
                {
                    dbAluno.Disciplinas = request.Disciplinas;
                }
            }

            await _context.SaveChangesAsync();

            return Ok(await _context.Alunos.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Aluno>>> Delete(int id)
        {
            var dbAluno = await _context.Alunos.FindAsync(id);
            if (dbAluno == null)
                return BadRequest("Aluno not found.");

            _context.Alunos.Remove(dbAluno);
            await _context.SaveChangesAsync();

            return Ok(await _context.Alunos.ToListAsync());
        }

    }
}
