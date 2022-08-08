using Cadastro.web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro.web.Services.IServices
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoModel>> FindAll();
        Task<AlunoModel> FindAlunoById(long id);
        Task<AlunoModel> CreateAluno(AlunoModel model);
        Task<AlunoModel> UpdateAluno(AlunoModel model);
        Task<bool> DeleteAlunoById(long id);
    }
}
