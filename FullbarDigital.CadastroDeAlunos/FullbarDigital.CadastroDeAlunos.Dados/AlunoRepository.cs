using FullbarDigital.CadastroDeAlunos.Dominio.Interfaces;
using FullbarDigital.CadastroDeAlunos.Dominio.Models;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public List<Aluno> GetAlunos(string nome, string ra, string curso, string status)
        {
            throw new NotImplementedException();
        }

        public List<Diciplina> GetDiciplinas(long idCurso)
        {
            throw new NotImplementedException();
        }

        public long InsertAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public long InsertCurso(Curso curso)
        {
            throw new NotImplementedException();
        }

        public long InsertDiciplina(Diciplina diciplina)
        {
            throw new NotImplementedException();
        }

        public void UpdateAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public void UpdateHistorico(Historico historico)
        {
            throw new NotImplementedException();
        }
    }
}
