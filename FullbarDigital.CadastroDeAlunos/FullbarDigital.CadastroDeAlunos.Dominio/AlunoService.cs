using FullbarDigital.CadastroDeAlunos.Dominio.Interfaces;
using FullbarDigital.CadastroDeAlunos.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FullbarDigital.CadastroDeAlunos.Dominio
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void DeleteAluno(long id)
        {
            _alunoRepository.DeleteAluno(id);
        }

        public List<Aluno> GetAlunos(string nome, string ra, string curso, string status)
        {
            return _alunoRepository.GetAlunos(nome, ra, curso, status);
        }

        public long InsertAluno(Aluno aluno)
        {
            var diciplinas = _alunoRepository.GetDiciplinas(aluno.IdCurso);
            return _alunoRepository.InsertAluno(aluno);
        }

        public long InsertCurso(Curso curso)
        {
            return _alunoRepository.InsertCurso(curso);
        }

        public long InsertDiciplina(Diciplina diciplina)
        {
            return _alunoRepository.InsertDiciplina(diciplina);
        }

        public void UpdateAluno(Aluno aluno)
        {
            _alunoRepository.UpdateAluno(aluno);
        }

        public void UpdateHistorico(Historico historico) 
        {
            _alunoRepository.UpdateHistorico(historico);
        }
    }
}
