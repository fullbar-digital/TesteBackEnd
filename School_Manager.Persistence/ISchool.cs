using System;
using System.Threading.Tasks;
using School_Manager.Domain;

namespace School_Manager.Persistence
{
    public interface ISchool
    {
        Task<Aluno> GetAllAlunoByNomeAsync(String nome);
        Task<Aluno> GetAllAlunoByRAAsync(int ra);
        Task<Aluno[]> GetAllAlunosByStatusAsync(bool status);
        Task<Aluno> GetAllAlunoByIDAsync(int id);
        Task<Aluno[]> GetAllAlunosAsync();
        Task<Curso[]> GetAllCursosAsync();
        Task<Curso> GetAllCursoByIDAsync(int id);
        Task<Diciplina[]> GetAllDiciplinasAsync();
        Task<Diciplina> GetAllDiciplinaByIDAsync(int id);


    }
}