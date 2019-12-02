using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BancoAlunos.Models;
using BancoAlunos.Interfaces;
using System;

namespace BancoAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        #region Injecao de Dependencia
        private readonly IAlunosRepository _context;

        public AlunosController(IAlunosRepository context)
        {
            _context = context;
        }
        #endregion

        #region Apis
        // GET: api/Alunos
        [HttpGet]
        public List<Alunos> GetAllAlunos()
        {
            return _context.GetAllData();
        }

        // GET: api/Alunos/id
        [HttpGet("{id}")]
        public ActionResult<Alunos> GetAlunosById(int id)
        {
            var alunos = _context.GetAlunosByIdData(id);

            if (alunos == null)
            {
                return NotFound();
            }

            return alunos;
        }

        // PUT: api/Alunos/id
        [HttpPut("{id}")]
        public IActionResult PutAlunos(int id, Alunos aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.PutAlunoData(aluno);

            try
            {
                _context.SaveChangesAlunoData();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Alunos
        [HttpPost]
        public ActionResult<Alunos> PostAlunos(Alunos aluno)
        {
            try
            {
                _context.PostAlunoData(aluno);

                _context.SaveChangesAlunoData();

                return CreatedAtAction("GetAllAlunos", new { id = aluno.Id }, aluno);
            }
            catch (Exception)
            {

                return StatusCode(500, "'Error Code 500 - Internal Server Error'");
            }
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public ActionResult<Alunos> DeleteAlunos(int id)
        {
            var aluno = _context.GetAlunosByIdData(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.DeleteAlunoData(aluno);
            _context.SaveChangesAlunoData();

            return NoContent();
        }
        #endregion

        private bool AlunoExists(int id)
        {
            return _context.AlunoExistsData(id);
        }
    }
}
