using FullbarDigital.CadastroDeAlunos.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FullbarDigital.CadastroDeAlunos.Dominio.Interfaces
{
    public interface IAlunoService
    {
        long InsertAluno(Aluno aluno);
        long InsertCurso(Curso curso);
        long InsertDiciplina(Diciplina diciplina);
        List<Aluno> GetAlunos(string nome, string ra, string curso, string status);
        void UpdateAluno(Aluno aluno);
        void DeleteAluno(long id);
        void UpdateHistorico(Historico historico);
    }
}
