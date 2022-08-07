using Microsoft.AspNetCore.Mvc;
using System;
using Teste_BackEnd.Interfaces;
using Teste_BackEnd.Models;

namespace Teste_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : IController<Curso>
    {
        private readonly ICursoRepository _cursoRepository;
        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        [HttpPost]
        public void Add([FromBody] Curso curso)
        {
            var cursoBD = _cursoRepository.GetByNome(curso.Nome);

            if (cursoBD != null)
                throw new Exception("Curso já cadastrado!");

            if (curso != null)
                _cursoRepository.Add(curso);
        }
    }
}
