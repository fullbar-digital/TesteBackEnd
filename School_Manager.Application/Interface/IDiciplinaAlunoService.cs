using System;
using System.Threading.Tasks;
using School_Manager.Domain;

namespace School_Manager.Application.Interface
{
    public interface IDiciplinaAlunoService
    {
        Task<DiciplinaAluno> AddDiciplinaAlunos(DiciplinaAluno model);
        Task<DiciplinaAluno> GetAllDiciplinaAlunoByIDAsync(int id);
    }
}