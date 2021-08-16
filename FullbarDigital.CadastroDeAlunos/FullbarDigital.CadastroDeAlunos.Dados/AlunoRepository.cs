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
            Salvar();
        }

        public List<Aluno> GetAlunos(string nome, string ra, string curso, string status)
        {
            IQueryable<Aluno> alunos = _cadastroContext.Alunos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
                alunos = alunos.Where(_ => _.Nome.Contains(nome));

            if (!string.IsNullOrWhiteSpace(ra))
                alunos = alunos.Where(_ => _.Ra.Contains(ra));

            if (!string.IsNullOrWhiteSpace(curso))
                alunos = alunos.Where(_ => _.Curso.Contains(curso));

            if (!string.IsNullOrWhiteSpace(status))
                alunos = alunos.Where(_ => _.Status.Equals(status));

            return alunos.ToList();
        }

        public List<Diciplina> GetDiciplinas(long idCurso)
        {
            return _cadastroContext.Diciplinas.Where(_ => _.CursoId == idCurso).ToList();
        }

        public  Diciplina GetDiciplina(long idDiciplina)
        {
            return _cadastroContext.Diciplinas.Find(idDiciplina);
        }

        public List<Historico> GetHistorico(long idAluno)
        {
            return _cadastroContext.Historicos.Where(_ => _.AlunoId == idAluno).ToList();
        }

        public long InsertAluno(Aluno aluno)
        {
            var result = _cadastroContext.Add(aluno);
            Salvar();
            return result.Entity.Id;
        }

        public long InsertCurso(Curso curso)
        {
            var result = _cadastroContext.Add(curso);
            Salvar();
            return result.Entity.Id;
        }

        public long InsertDiciplina(Diciplina diciplina)
        {
            var result = _cadastroContext.Add(diciplina);
            Salvar();
            return result.Entity.Id;
        }

        public void UpdateAluno(Aluno aluno)
        {
            _cadastroContext.Update(aluno);
            Salvar();

        }

        public void UpdateHistorico(Historico historico)
        {
            _cadastroContext.Update(historico);
            Salvar();
        }

        public void Salvar()
        {
            _cadastroContext.SaveChanges();
        }
    }
}
