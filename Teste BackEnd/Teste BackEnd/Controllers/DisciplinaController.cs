using Microsoft.AspNetCore.Mvc;
using System;
using Teste_BackEnd.Interfaces;
using Teste_BackEnd.Models;

namespace Teste_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController
    {
        private readonly IDisciplinaRepository _disciplinaRepository;

        public DisciplinaController(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        [HttpPost]
        public void Add([FromBody] Disciplina disciplina, int cursoId)
        {
            var disciplinaBD = _disciplinaRepository.GetByNome(disciplina.Nome, cursoId);

            if (disciplinaBD != null)
                throw new Exception("Disciplina já cadastrada!");

            if (disciplina != null)
                _disciplinaRepository.Add(disciplina);
        }
    }
}
