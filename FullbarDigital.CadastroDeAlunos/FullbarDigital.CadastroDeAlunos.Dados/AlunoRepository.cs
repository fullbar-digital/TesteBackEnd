using FullbarDigital.CadastroDeAlunos.Dominio.Interfaces;
using FullbarDigital.CadastroDeAlunos.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullbarDigital.CadastroDeAlunos.Dados
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly CadastroContext _cadastroContext;

        public AlunoRepository(CadastroContext cadastroContext)
        {
            _cadastroContext = cadastroContext;
        }

        public void DeleteAluno(long id)
        {
            var delete = _cadastroContext.Alunos.Find(id);
            _cadastroContext.Alunos.Remove(delete);
        }

        public List<Aluno> GetAlunos(string nome, string ra, string curso, string status)
        {
            throw new NotImplementedException();
        }

        public List<Diciplina> GetDiciplinas(long idCurso)
        {
            return _cadastroContext.Diciplinas.Where(_ => _.IdCurso == idCurso).ToList();
        }

        public long InsertAluno(Aluno aluno)
        {
            return _cadastroContext.Add(aluno).Entity.Id;
        }

        public long InsertCurso(Curso curso)
        {
            return _cadastroContext.Add(curso).Entity.Id;
        }

        public long InsertDiciplina(Diciplina diciplina)
        {
            return _cadastroContext.Add(diciplina).Entity.Id;
        }

        public void UpdateAluno(Aluno aluno)
        {
            _cadastroContext.Update(aluno);
        }

        public void UpdateHistorico(Historico historico)
        {
            _cadastroContext.Update(historico);
        }
    }
}
