using Servico.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Interfaces
{
    public interface IDisciplinaServico
    {
        Task<DisciplinaDTO> Create(DisciplinaDTO disciplinaDTO);
        Task<DisciplinaDTO> Update(DisciplinaDTO disciplinaDTO);
        Task Remove(int codigo);
        Task<DisciplinaDTO> Get(int codigo);
        Task<List<DisciplinaDTO>> Get();
    }
}
