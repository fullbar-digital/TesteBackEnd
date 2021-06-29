using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.API.ViewModels.Disciplina;

namespace TesteFullBar.API.Services.Interfaces
{
    public interface IDisciplinaService
    {
        Task<IEnumerable<DisciplinaViewModel>> GetAll();
        Task<DisciplinaViewModel> GetByIdAsync(DisciplinaIdViewModel disciplinaVM);

        Task<DisciplinaViewModel> GetByDescricaoAsync(DisciplinaDescricaoViewModel disciplinaVM);
        DisciplinaViewModel Add(DisciplinaViewModel disciplinaVM);
        void Update(DisciplinaViewModel disciplinaVM);
        void Remove(DisciplinaViewModel disciplinaVM);
    }
}
