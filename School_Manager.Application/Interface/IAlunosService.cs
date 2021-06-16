using System;
using System.Threading.Tasks;
using School_Manager.Domain;

namespace School_Manager.Application.Interface
{
    public interface IAlunosService
    {
        Task<Aluno> AddAlunos(Aluno model);

        Task<Aluno> UpdateAluno(int alunoId, Aluno model);
        Task<bool> DeleteAluno(int alunoId);
        Task<Aluno> GetAllAlunoByNomeAsync(String nome);
        Task<Aluno> GetAllAlunoByRAAsync(int ra);
        Task<Aluno> GetAllAlunoByIDAsync(int id);
        Task<Aluno[]> GetAllAlunosByStatusAsync(bool status);

        Task<Aluno[]> GetAllAlunosAsync();
    }
}