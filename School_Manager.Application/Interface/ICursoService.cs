using System;
using System.Threading.Tasks;
using School_Manager.Domain;

namespace School_Manager.Application.Interface
{
    public interface ICursoService
    {
        Task<Curso> AddCurso(Curso model);
        Task<Curso[]> GetAllCursosAsync();
        Task<Curso> GetAllCursoByIDAsync(int id);

    }
}