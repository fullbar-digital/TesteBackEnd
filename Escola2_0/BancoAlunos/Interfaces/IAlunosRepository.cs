using BancoAlunos.Models;
using System;
using System.Collections.Generic;

namespace BancoAlunos.Interfaces
{
    public interface IAlunosRepository : IDisposable
    {
        List<Alunos> GetAllData();
        Alunos GetAlunosByIdData(int id);
        void PostAlunoData(Alunos aluno);
        void PutAlunoData(Alunos aluno);
        void DeleteAlunoData(Alunos aluno);
        void SaveChangesAlunoData();
        bool AlunoExistsData(int id);
    }

}
