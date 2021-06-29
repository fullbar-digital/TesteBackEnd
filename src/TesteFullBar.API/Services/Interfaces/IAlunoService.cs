using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.API.ViewModels.Aluno;
using TesteFullBar.API.ViewModels.Aluno.Query;

namespace TesteFullBar.API.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoQueryViewModel>> GetByFilterAsync(AlunoFilterViewModel filter);
        Task<AlunoViewModel> GetByIdAsync(AlunoIdViewModel alunoVM);

        Task<AlunoViewModel> GetByRaAsync(AlunoRaViewModel alunoVM);
        AlunoViewModel Add(AlunoViewModel alunoVM);
         
        void Update(AlunoViewModel alunoVM);
        void Remove(AlunoViewModel alunoVM);
    }
}
