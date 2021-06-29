using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.API.ViewModels.Curso;

namespace TesteFullBar.API.Services.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<CursoViewModel>> GetAll();
        Task<CursoViewModel> GetByIdAsync(CursoIdViewModel cursoVM);

        Task<CursoViewModel> GetByDescricaoAsync(CursoDescricaoViewModel cursoVM);
        CursoViewModel Add(CursoViewModel cursoVM);
        void Update(CursoViewModel cursoVM);
        void Remove(CursoViewModel cursoVM);
    }
}
