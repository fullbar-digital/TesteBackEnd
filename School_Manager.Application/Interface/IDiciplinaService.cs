using System;
using System.Threading.Tasks;
using School_Manager.Domain;

namespace School_Manager.Application.Interface
{
    public interface IDiciplinaService
    {
        Task<Diciplina> AddDiciplinas(Diciplina model);
        Task<Diciplina[]> GetAllDiciplinasAsync();
        Task<Diciplina> GetAllDiciplinaByIDAsync(int id);
    }
}