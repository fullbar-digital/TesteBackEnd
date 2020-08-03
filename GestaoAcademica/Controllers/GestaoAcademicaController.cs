using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAcademica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestaoAcademicaController : ControllerBase
    {
        private readonly GestaoAcademicaContext _gaContext;
        public GestaoAcademicaController(GestaoAcademicaContext gaContext)
        {
            _gaContext = gaContext;
        }

        private bool AlunoExists(int id) => _gaContext.Alunos.Any(e => e.AlunoId == id);

        public ActionResult Default()
        {
            return Ok();
        }

        [Route("ListarAlunos")]
        [HttpGet]
        public ActionResult<IEnumerable<AlunoDTO>> ListarAlunos()
        {
            List<AlunoDTO> alunosDto = new List<AlunoDTO>();
            var alunos = _gaContext.Alunos
                .Include(x => x.Curso)
                .Include(x => x.Curso.Disciplinas)
                .Include(x => x.AlunosDisciplinas).ToList();
            foreach (var aluno in alunos)
            {
                alunosDto.Add(Conversao.AlunoToAlunoDTO(aluno));
            }
            return  alunosDto;
        }

        [Route("FiltrarAlunos")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> FiltrarAlunos(string filtrarPor, string parametro)
        {
            if (string.IsNullOrEmpty(parametro) || string.IsNullOrEmpty(filtrarPor))
                return BadRequest();

            return filtrarPor switch
            {
                "nome" => await _gaContext.Alunos
                    .Where(x => x.Nome.Contains(parametro)).Include(x => x.Curso).ToListAsync(),
                "ra" => await _gaContext.Alunos
                    .Where(x => x.Ra.Contains(parametro)).Include(x => x.Curso).ToListAsync(),
                "curso" => await _gaContext.Alunos
                    .Where(x => x.Curso.Nome.Contains(parametro)).Include(x => x.Curso).ToListAsync(),
                "status" => await _gaContext.Alunos
                    .Where(x => x.Status == Convert.ToInt32(parametro)).Include(x => x.Curso).ToListAsync(),
                _ => BadRequest()
            };
        }

        [Route("AlterarDadosAluno")]
        [HttpPatch]
        public async Task<ActionResult<Aluno>> AlterarDadosAluno(Aluno aluno)
        {
            var alunoBd = await _gaContext.Alunos.FindAsync(aluno.AlunoId);
            if (alunoBd == null)
                return NotFound();

            alunoBd.Nome = aluno.Nome;
            alunoBd.Ra = aluno.Ra;
            aluno.Periodo = aluno.Periodo;
            alunoBd.CursoId = aluno.CursoId;
            alunoBd.Foto = aluno.Foto;

            try
            {
                await _gaContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!AlunoExists(aluno.AlunoId))
            {
                return NotFound();
            }
            return Ok();
        }

        [Route("ExcluirAluno")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> ExcluirAluno([FromQuery] int id)
        {
            var aluno = await _gaContext.Alunos.FindAsync(id);
            if (aluno == null)
                return NotFound();
            var alunosDisciplinas = _gaContext.AlunosDisciplinas.Where(x => x.AlunoId == id);
            foreach (var ad in alunosDisciplinas)
            {
                _gaContext.AlunosDisciplinas.Remove(ad);
            }
            _gaContext.Alunos.Remove(aluno);
            await _gaContext.SaveChangesAsync();
            return Ok();
        }
    }
}
