using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Teste_BackEnd.Interfaces;
using Teste_BackEnd.Models;

namespace Teste_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : IController<Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        // Adicionar aluno. Verificação se aluno já existe.
        [HttpPost]
        public void Add([FromBody] Aluno aluno)
        {
            var alunoBD = _alunoRepository.GetByNome(aluno.Nome);

            if (alunoBD != null)
                throw new Exception("Aluno já cadastrado!");

            if (aluno != null)
                _alunoRepository.Add(aluno);
        }

        [HttpDelete("{id}")]
        // Excluir o aluno selecionado 
        public void Delete(int id)
        {
            _alunoRepository.Delete(id);
        }

        // Buscar todos os alunos.
        [HttpGet]
        [Route("all")]
        public IList<Aluno> Get()
        {
            var alunos = _alunoRepository.GetAll();
            return alunos;
        }

        // Buscar aluno pelo nome.
        [HttpGet]
        [Route("get-by-nome")]
        public Aluno GetByNome([FromQuery] string nome)
        {
            var aluno = _alunoRepository.GetByNome(nome);
            return aluno;
        }

        // Buscar aluno pelo RA.
        [HttpGet]
        [Route("get-by-ra")]
        public Aluno GetByRA([FromQuery] string RA)
        {
            var aluno = _alunoRepository.GetByRA(RA);
            return aluno;
        }

        // Buscar aluno pelo curso.
        [HttpGet]
        [Route("get-by-curso")]
        public IList<Aluno> GetByCurso([FromQuery] int cursoId)
        {
            var alunos = _alunoRepository.GetByCurso(cursoId);
            return alunos;
        }

        // Buscar aluno pelo status.
        [HttpGet]
        [Route("get-by-status")]
        public IList<Aluno> GetByStatus([FromQuery] string status)
        {
            var alunos = _alunoRepository.GetByStatus(status);
            return alunos;
        }

        // Atualizar informações do Aluno
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Aluno aluno)
        {
            _alunoRepository.Update(id, aluno);
        }
    }
}

